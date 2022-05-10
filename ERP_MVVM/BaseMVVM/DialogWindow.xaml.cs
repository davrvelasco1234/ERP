

using ERP_Core;

namespace ERP_MVVM.BaseMVVM
{
    public partial class DialogWindow : WindowDialogERP
    {
        public bool CloseWindows { get; set; }
        public DialogWindow()
        {
            InitializeComponent();
            CloseWindows = true;

            //falata el mensaje
            //MVVM.Messenger.Messenger.Default.Register<bool>(this, "CloseWindowDialogMVVM", EnabledWindow);
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CloseWindows)
            {
                e.Cancel = true;
            }
        }

        private void EnabledWindow(bool val)
        {
            
            this.CloseWindows = val;
        }
    }
}
