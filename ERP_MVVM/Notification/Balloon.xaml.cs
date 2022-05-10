

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using ERP_MVVM.Helpers;
using static ERP_Common.Helpers.Constantes;

namespace ERP_MVVM.Notification
{
    public partial class Balloon : Window
    {

        #region Attribites
        private readonly Control control;
        private readonly bool placeInCenter;
        public static readonly DependencyProperty ShowCloseButtonProperty = DependencyProperty.Register(
            "ShowCloseButton", typeof(bool), typeof(Balloon), new PropertyMetadata(OnShowCloseButtonChanged));
        #endregion


        #region Properties
        [Description("Sets whether the Help Balloon's close button will be visible."), Category("Common Properties")]
        public bool ShowCloseButton
        {
            get
            {
                return (bool)GetValue(ShowCloseButtonProperty);
            }

            private set
            {
                this.SetValue(ShowCloseButtonProperty, value);
            }
        }
        #endregion


        #region Constructors
        public Balloon(Control control, string caption, MessageType popType)
            : this(control, caption, popType, 500, 500, true, true, true)
        {
        }

        public Balloon(Control control, string title, string caption, MessageType popType)
            : this(control, caption, popType, 500, 500, true, true, true, title)
        {
        }

        public Balloon(Control control, string caption, MessageType popType, bool placeInCenter, bool showCloseButton)
            : this(control, caption, popType, 0, 0, false, placeInCenter, showCloseButton)
        {
        }

        public Balloon(Control control, string title, string caption, MessageType popType, bool placeInCenter, bool showCloseButton)
            : this(control, caption, popType, 0, 0, false, placeInCenter, showCloseButton, title)
        {

        }


        public Balloon(Control control,
            string caption,
            MessageType popType,
            double maxHeight = 0,
            double maxWidth = 0,
            bool autoWidth = false,
            bool placeInCenter = true,
            bool showCloseButton = true,
            string title = null
            )
        {

            //double maxHeight = 500;
            //double maxWidth = 500;
            //bool autoWidth = true;
            //bool placeInCenter = false;
            //bool showCloseButton = true;


            //this.AnimationIni.Duration = new System.Windows.Duration(TimeSpan.FromSeconds(1));
            //this.AnimationFin.Duration = new System.Windows.Duration(TimeSpan.FromSeconds(1));
            //this.AnimationFin.BeginTime = new System.TimeSpan(0, 0, 1);

            InitializeComponent();
            this.control = control;
            this.placeInCenter = placeInCenter;
            this.ShowCloseButton = showCloseButton;
            //this.Owner = Application.Current.MainWindow;

            if (placeInCenter)
            {
                Application.Current.MainWindow.LocationChanged += this.MainWindowLocationChanged;
                control.LayoutUpdated += this.MainWindowLocationChanged;
            }

            if (showCloseButton)
            {
                this.imageClose.Source = Properties.Resources.Close.ToBitmapImage();
                this.imageClose.Visibility = Visibility.Visible;
            }
            else
            {
                this.imageClose.Visibility = Visibility.Collapsed;
            }

            Application.Current.MainWindow.Closing += this.OwnerClosing;
            LinearGradientBrush brush;

            if (popType == MessageType.Bug)
            {
                this.imageType.Source = Properties.Resources.Bug.ToBitmapImage();
                brush = this.FindResource("BugGradient") as LinearGradientBrush;
            }
            else if (popType == MessageType.Help)
            {
                this.imageType.Source = Properties.Resources.Help.ToBitmapImage();
                brush = this.FindResource("HelpGradient") as LinearGradientBrush;
            }
            else if (popType == MessageType.Success)
            {
                this.imageType.Source = Properties.Resources.Success.ToBitmapImage();
                brush = this.FindResource("SuccessGradient") as LinearGradientBrush;
            }
            else //if (popType == PopType.Warning)
            {
                this.imageType.Source = Properties.Resources.Warning.ToBitmapImage();
                brush = this.FindResource("WarningGradient") as LinearGradientBrush;
            }

            this.borderBalloon.SetValue(Control.BackgroundProperty, brush);

            if (autoWidth)
            {
                this.SizeToContent = SizeToContent.WidthAndHeight;
            }

            this.textBlockCaption.Text = caption;

            if (maxHeight > 0)
            {
                this.scrollViewerCaption.MaxHeight = maxHeight;
            }

            if (maxWidth > 0)
            {
                this.MaxWidth = maxWidth;
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                this.textBlockTitle.Text = title;
            }
            else
            {
                this.textBlockTitle.Visibility = Visibility.Collapsed;
                this.lineTitle.Visibility = Visibility.Collapsed;
            }

            this.CalcPosition();
        }
        #endregion


        #region Event
        private static void OnShowCloseButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Balloon balloon = (Balloon)d;

            if (balloon.ShowCloseButton)
            {
                balloon.imageClose.Visibility = Visibility.Visible;
            }
            else
            {
                balloon.imageClose.Visibility = Visibility.Collapsed;
            }
        }
        private void DoubleAnimationCompleted(object sender, EventArgs e)
        {
            if (!this.IsMouseOver)
            {
                this.Close();
            }
        }
        private void MainWindowLocationChanged(object sender, EventArgs e)
        {
            this.CalcPosition();
        }
        private void OwnerClosing(object sender, CancelEventArgs e)
        {
            string name = typeof(Balloon).Name;

            foreach (Window window in Application.Current.Windows)
            {
                string windowType = window.GetType().Name;
                if (windowType.Equals(name))
                {
                    window.Close();
                }
            }
        }
        private void ImageCloseMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
        #endregion


        #region Methods
        private bool IsVisibleToUser()
        {
            if (!this.control.IsVisible)
            {
                return false;
            }
            var container = (FrameworkElement)VisualTreeHelper.GetParent(this.control);

            Rect bounds = this.control.TransformToAncestor(container).TransformBounds(new Rect(0.0, 0.0, this.control.RenderSize.Width, this.control.RenderSize.Height));
            Rect rect = new Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight);
            return rect.IntersectsWith(bounds);
        }

        private void CalcPosition()
        {
            if (!this.IsVisibleToUser())
            {
                this.Close();
                return;
            }

            PresentationSource source = PresentationSource.FromVisual(this.control);

            if (source != null)
            {
                double captionPointMargin = this.PathPointLeft.Margin.Left;

                Point location = this.control.PointToScreen(new Point(0, 0));

                double leftPosition;

                if (this.placeInCenter)
                {
                    leftPosition = location.X + (this.control.ActualWidth / 2) - captionPointMargin;
                }
                else
                {
                    leftPosition = System.Windows.Forms.Control.MousePosition.X - captionPointMargin;

                    if (leftPosition < location.X)
                    {
                        leftPosition = location.X;
                    }
                    else if (leftPosition > location.X + this.control.ActualWidth)
                    {
                        leftPosition = location.X + this.control.ActualWidth - (captionPointMargin * 2);
                    }
                }

                System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromHandle(new WindowInteropHelper(Application.Current.MainWindow).Handle);

                if ((leftPosition < 0 && screen.WorkingArea.Width + leftPosition + this.Width < screen.WorkingArea.Width) ||
                    leftPosition >= 0 && leftPosition + this.Width < screen.WorkingArea.Width)
                {
                    this.PathPointRight.Visibility = Visibility.Hidden;
                    this.PathPointLeft.Visibility = Visibility.Visible;
                    this.Left = leftPosition;
                }
                else
                {
                    this.PathPointLeft.Visibility = Visibility.Hidden;
                    this.PathPointRight.Visibility = Visibility.Visible;
                    this.Left = location.X + (this.control.ActualWidth / 2) + captionPointMargin - this.Width;
                }

                this.Top = location.Y + (this.control.ActualHeight / 2);
            }
        }

        #endregion

    }
}
