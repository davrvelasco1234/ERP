using System;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

using ERP_MVVM.Helpers;

namespace ERP_MVVM.Notification
{
    public partial class ToastPopUp : Window
    {

        #region Members
        private readonly string name = typeof(ToastPopUp).Name;
        private volatile object lockObject = new object();
        #endregion Members


        #region Constructors
        internal ToastPopUp(string title, string text, ImageSource imageSource)
            : this(title)
        {
            this.TextBoxShortDescription.Text = text;
            this.imageLeft.Source = imageSource;
        }
        internal ToastPopUp(string title, string text, Bitmap imageSource)
            : this(title, text, imageSource.ToBitmapImage())
        {
        }

        internal ToastPopUp(string title)
        {
            this.InitializeComponent();
            System.Windows.Application.Current.MainWindow.Closing += this.MainWindowClosing;

            this.TextBoxTitle.Text = title;
            this.Title = title;
            this.imageClose.Source = Properties.Resources.Close.ToBitmapImage();
        }
        #endregion Constructors


        #region Properties

        public byte MaxToast { get; set; }

        public System.Windows.Media.Brush FontColor
        {
            get
            {
                return this.TextBoxTitle.Foreground;
            }

            set
            {
                this.TextBoxTitle.Foreground = value;
                this.TextBoxShortDescription.Foreground = value;
            }
        }

        public new System.Windows.Media.Brush BorderBrush
        {
            get
            {
                return this.borderBackground.BorderBrush;
            }

            set
            {
                this.borderBackground.BorderBrush = value;
            }
        }

        public new System.Windows.Media.Brush Background
        {
            get
            {
                return this.borderBackground.Background;
            }

            set
            {
                this.borderBackground.Background = value;
            }
        }

        public object HyperlinkObjectForRaisedEvent { get; set; }

        #endregion Public Properties


        #region Methods
        public new void Show()
        {
            int toastCount = System.Windows.Application.Current.Windows.OfType<ToastPopUp>().Count();

            if (this.MaxToast > 0 && toastCount > this.MaxToast)
            {
                this.Close();
                return;
            }

            IInputElement focusedElement = Keyboard.FocusedElement;

            this.Topmost = true;
            base.Show();

            this.Owner = System.Windows.Application.Current.MainWindow;
            this.Closed += this.NotificationWindowClosed;
            this.AdjustWindows();

            if (focusedElement != null)
            {
                focusedElement.Focusable = true;
                Keyboard.Focus(focusedElement);
            }
        }
        #endregion


        #region EventHandler
        public event EventHandler<EventArgs> ClosedByUser;

        public event EventHandler<HyperLinkEventArgs> HyperlinkClicked;
        #endregion Events


        #region Event
        protected virtual void OnClosedByUser(EventArgs e)
        {
            ClosedByUser?.Invoke(this, e);
        }

        protected virtual void OnHyperlinkClicked(HyperLinkEventArgs e)
        {
            HyperlinkClicked?.Invoke(this, e);
        }

        private void ButtonViewClick(object sender, RoutedEventArgs e)
        {
            this.OnHyperlinkClicked(new HyperLinkEventArgs { HyperlinkObjectForRaisedEvent = this.HyperlinkObjectForRaisedEvent });
        }

        private void DoubleAnimationCompleted(object sender, EventArgs e)
        {
            if (!this.IsMouseOver)
            {
                this.Close();
            }
        }

        private void ImageMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.OnClosedByUser(new EventArgs());
            this.Close();
        }

        private void MainWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowType = window.GetType().Name;
                if (windowType.Equals(this.name))
                {
                    window.Close();
                }
            }
        }

        private void NotificationWindowClosed(object sender, EventArgs e)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowName = window.GetType().Name;

                if (windowName.Equals(this.name) && window != this)
                {
                    // Adjust any windows that were above this one to drop down
                    if (window.Top < this.Top && window.Left == this.Left)
                    {
                        window.Top = window.Top + this.ActualHeight;

                        if (!WindowsExistToTheRight(this.Left))
                        {
                            window.Left = window.Left + this.ActualWidth;
                        }
                    }
                }
            }

            this.AdjustWindows();
        }

        private bool WindowsExistToTheRight(double left)
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                string windowName = window.GetType().Name;

                if (windowName.Equals(this.name) &&
                    !Equals(window, this) &&
                    left == Screen.PrimaryScreen.WorkingArea.Width - this.Width)
                {
                    return true;
                }
            }

            return false;
        }

        private void AdjustWindows()
        {
            lock (lockObject)
            {
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;

                this.Left = workingArea.Width - this.ActualWidth;
                double top = workingArea.Height - this.ActualHeight;

                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    string windowName = window.GetType().Name;

                    if (windowName.Equals(this.name) && !Equals(window, this))
                    {
                        window.Topmost = true;

                        if (this.Left == window.Left)
                        {
                            top = top - window.ActualHeight;
                        }

                        if (top < 0)
                        {
                            this.Left = this.Left - this.ActualWidth;
                            top = workingArea.Bottom - this.ActualHeight;
                        }
                    }
                }

                this.Top = top;
            }
        }

        private void SetHyperLinkButton(string hyperlinkText)
        {
            if (!string.IsNullOrWhiteSpace(hyperlinkText))
            {
                this.buttonView.Content = hyperlinkText;
                this.buttonView.Visibility = Visibility.Visible;
            }
        }
        #endregion

    }
}
