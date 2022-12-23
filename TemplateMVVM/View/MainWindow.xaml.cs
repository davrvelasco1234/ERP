using ERP_Core;

namespace TemplateMVVM.View
{
    public partial class MainWindow : WindowAppErp
    {
        public MainWindow() : base()
        {

            InitializeComponent();
        }
        /*
        private void WindowERP_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SetFocusIndex();
        }

        private void WindowERP_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == System.Windows.Input.Key.Escape)
                {
                    SetFocusIndex();
                }
            }
            catch (System.Exception)
            {


            }
        }
        private void SetFocusIndex()
        {
            //index.Focus();
            //index.Focusable = true;
            //index.ForceCursor = true;
        }
        */
    }
}
