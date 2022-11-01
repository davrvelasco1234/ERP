using ERP_Controls.Helpers;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static ERP_Common.Helpers.Constantes;

namespace ERP_Controls.Notification
{
    public partial class HelpBalloon : UserControl
    {
        #region Members
        private Balloon balloon = null;


        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption", typeof(string), typeof(HelpBalloon));

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(HelpBalloon));

        public static readonly DependencyProperty BalloonTypeProperty =
            DependencyProperty.Register("BalloonType", typeof(MessageType), typeof(HelpBalloon), new PropertyMetadata(OnBalloonTypeChanged));

        public new static readonly DependencyProperty MaxHeightProperty =
            DependencyProperty.Register("MaxHeight", typeof(double), typeof(HelpBalloon));

        public new static readonly DependencyProperty MaxWidthProperty =
            DependencyProperty.Register("MaxWidth", typeof(double), typeof(HelpBalloon));

        public static readonly DependencyProperty AutoWidthProperty =
            DependencyProperty.Register("AutoWidth", typeof(bool), typeof(HelpBalloon));

        public static readonly DependencyProperty ShowCloseButtonProperty =
            DependencyProperty.Register("ShowCloseButton", typeof(bool), typeof(HelpBalloon));
        #endregion


        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpBalloon"/> class.
        /// </summary>
        public HelpBalloon()
        {
            InitializeComponent();
            this.ShowCloseButton = true;
        }

        #endregion


        #region Properties
        [Description("Sets whether the Help Balloon's close button will be visible."), Category("Common Properties")]
        public bool ShowCloseButton
        {
            get
            {
                return (bool)GetValue(ShowCloseButtonProperty);
            }

            set
            {
                this.SetValue(ShowCloseButtonProperty, value);
            }
        }


        [Description("The maximum height of the Balloon caption."), Category("Common Properties")]
        public new double MaxHeight
        {
            get
            {
                return (double)GetValue(MaxHeightProperty);
            }

            set
            {
                this.SetValue(MaxHeightProperty, value);
            }
        }


        [Description("The maximum width of the Balloon caption."), Category("Common Properties")]
        public new double MaxWidth
        {
            get
            {
                return (double)GetValue(MaxWidthProperty);
            }

            set
            {
                this.SetValue(MaxWidthProperty, value);
            }
        }


        [Description("Sets whether the Help Balloon's width will be auto set."), Category("Common Properties")]
        public bool AutoWidth
        {
            get
            {
                return (bool)GetValue(AutoWidthProperty);
            }

            set
            {
                this.SetValue(AutoWidthProperty, value);
            }
        }


        [Description("The caption displayed in the Help Balloon."), Category("Common Properties")]
        public string Caption
        {
            get
            {
                return (string)GetValue(CaptionProperty);
            }

            set
            {
                this.SetValue(CaptionProperty, value);
            }
        }


        [Description("The title displayed in the Help Balloon."), Category("Common Properties")]
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }

            set
            {
                this.SetValue(TitleProperty, value);
            }
        }


        [Description("The type of Balloon to display."), Category("Common Properties")]
        public MessageType BalloonType
        {
            get
            {
                return (MessageType)GetValue(BalloonTypeProperty);
            }

            set
            {
                this.SetValue(BalloonTypeProperty, value);
            }
        }
        #endregion


        #region Event
        private static void OnBalloonTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HelpBalloon helpBalloon = (HelpBalloon)d;

            switch (helpBalloon.BalloonType)
            {
                case MessageType.Bug:
                    helpBalloon.imageControl.Source = Properties.Resources.Bug.ToBitmapImage();
                    break;
                case MessageType.Help:
                    helpBalloon.imageControl.Source = Properties.Resources.Help.ToBitmapImage();
                    break;
                case MessageType.Success:
                    helpBalloon.imageControl.Source = Properties.Resources.Success.ToBitmapImage();
                    break;
                case MessageType.Warning:
                    helpBalloon.imageControl.Source = Properties.Resources.Warning.ToBitmapImage();
                    break;
                default:
                    throw new InvalidOperationException("unsupported BalloonType");
            }
        }

        private void ImageMouseEnter(object sender, MouseEventArgs e)
        {
            if (balloon == null)
            {
                balloon = new Balloon(this, this.Caption, this.BalloonType, this.MaxHeight, this.MaxWidth, this.AutoWidth, true, this.ShowCloseButton, this.Title);
                balloon.Closed += this.BalloonClosed;
                balloon.Show();
            }
        }

        private void BalloonClosed(object sender, EventArgs e)
        {
            this.balloon = null;
        }

        #endregion


    }

}
