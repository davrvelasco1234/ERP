using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static ERP_Common.Helpers.Constantes;

namespace ERP_Controls.Notification
{
    public class Popup
    {
        private static void ExecuteBalloon(Control control, MessageType popType, string Title = "", string Text = "")
        {

        }

        public static void ExecutePopup(MessageType popType, string Title = "", string Text = "")
        {
            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(() =>
            {
                System.Windows.Media.Color StartColor;
                System.Windows.Media.Color EndColor;


                if (popType == MessageType.Bug)
                {
                    StartColor = System.Windows.Media.Color.FromRgb(255, 253, 253);
                    EndColor = System.Windows.Media.Color.FromRgb(255, 0, 0);
                }
                else if (popType == MessageType.Help)
                {
                    StartColor = System.Windows.Media.Color.FromRgb(255, 253, 253);
                    EndColor = System.Windows.Media.Color.FromRgb(50, 80, 210);
                }
                else if (popType == MessageType.Success)
                {
                    StartColor = System.Windows.Media.Color.FromRgb(255, 253, 253);
                    EndColor = System.Windows.Media.Color.FromRgb(80, 240, 80);
                }
                else //if (balloonType == PopType.Warning)
                {
                    StartColor = System.Windows.Media.Color.FromRgb(255, 253, 253);
                    EndColor = System.Windows.Media.Color.FromRgb(240, 230, 60);
                }

                System.Windows.Media.Color BorderColor = System.Windows.Media.Color.FromRgb(169, 169, 169);
                System.Windows.Media.Color FontColor = System.Windows.Media.Color.FromRgb(0, 0, 0);


                //string HyperlinkText = "HyperlinkText";
                byte MaxToast = 150;

                var background = new LinearGradientBrush(StartColor, EndColor, 90);
                var brush = new SolidColorBrush(BorderColor);
                var font = new SolidColorBrush(FontColor);

                var notificationType = (MessageType)Enum.Parse(typeof(MessageType), "1");
                ToastPopUp toast = null;

                if (popType == MessageType.Bug)
                {
                    toast = new ToastPopUp(Title, Text, Properties.Resources.Bug)
                    {
                        Background = background,
                        BorderBrush = brush,
                        FontColor = font,
                        MaxToast = MaxToast
                    };
                }
                else if (popType == MessageType.Help)
                {
                    toast = new ToastPopUp(Title, Text, Properties.Resources.Help)
                    {
                        Background = background,
                        BorderBrush = brush,
                        FontColor = font,
                        MaxToast = MaxToast
                    };
                }
                else if (popType == MessageType.Success)
                {
                    toast = new ToastPopUp(Title, Text, Properties.Resources.Success)
                    {
                        Background = background,
                        BorderBrush = brush,
                        FontColor = font,
                        MaxToast = MaxToast
                    };
                }
                else if (popType == MessageType.Warning)
                {
                    toast = new ToastPopUp(Title, Text, Properties.Resources.Warning)
                    {
                        Background = background,
                        BorderBrush = brush,
                        FontColor = font,
                        MaxToast = MaxToast
                    };

                }

                toast.Show();
            }));
        }

    }
}
