using ERP_Common.Interfaces;
using ERP_Common.Models;
using FirstFloor.ModernUI.Windows.Controls;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ERP_Core
{
    public class WindowERP : ModernWindow
    {
        private bool IsEnabledWindow { get; set; } = true;

        public static readonly DependencyProperty LogoCompanyProperty = DependencyProperty.Register("LogoCompany", typeof(BitmapImage), typeof(ModernWindow));
        public static readonly DependencyProperty HeaderLinksListProperty = DependencyProperty.Register("HeaderLinksList", typeof(List<HeaderLinks>), typeof(ModernWindow));
                                                                                                         
        //public BottomViewModel BottomViewModel { get; }
        public IBottomTemplate IBotoom { get; }
        public WindowERP(IBottomTemplate iBotoom)
        {
            //this.BottomViewModel = new BottomViewModel();   
            this.IBotoom = iBotoom;

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = Assembly.GetEntryAssembly().GetName().Name;
            this.Title = this.Title.ToUpper();
            this.Closing += WindowERP_Closing;


            //this.IsEnabled = false;
        }


        protected void WindowERP_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsEnabledWindow)
            {
                e.Cancel = true;
            }
        }

        protected void IsEnabledWindowERP(bool val)
        {
            this.IsEnabledWindow = val;
        }

        public BitmapImage LogoCompany
        {
            get { return (BitmapImage)GetValue(LogoCompanyProperty); }
            set { SetValue(LogoCompanyProperty, value); }
        }

        public List<HeaderLinks> HeaderLinksList
        {
            get { return (List<HeaderLinks>)GetValue(HeaderLinksListProperty); }
            set { SetValue(HeaderLinksListProperty, value); }
        }

    }
}
