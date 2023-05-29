
using FirstFloor.ModernUI.Windows.Controls;
using System.Reflection;
using System.Windows;

namespace ERP_Core
{
    public class WindowDialogERP : ModernWindow
    {
        private bool IsEnabledWindow { get; set; } = true;
        

        public string textLabel { get; set; }


        public WindowDialogERP()
        {

            //Messenger.Default.Register<bool>(this, "IsEnabledWindowFinamex", IsEnabledWindowFinamex);
            this.textLabel = "Pruebas label";
            

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = Assembly.GetEntryAssembly().GetName().Name;
            this.Title = this.Title.ToUpper();
            this.Closing += WindowERP_Closing;
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



        //public object TemplateBottom
        //{
        //    get { return GetValue(TemplateBottomProperty); }
        //    set { SetValue(TemplateBottomProperty, value); }
        //}

    }
}
