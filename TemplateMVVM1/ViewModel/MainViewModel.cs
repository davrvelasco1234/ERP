

using System.Windows.Input;
using MVVM.BaseMVVM;
using MVVM.Messenger;

namespace TemplateMVVM1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Attribites

        #endregion


        #region Properties
        private bool isEnabledWindow = true;
        public bool IsEnabledWindow
        {
            get { return this.isEnabledWindow; }
            set { SetValue(ref this.isEnabledWindow, value); }
        }
        #endregion


        #region Commands
        public ICommand LoadedCommand { get { return new RelayCommandMVVM(Loaded); } }
        #endregion


        #region Contructors
        public MainViewModel()
        {
            Messenger.Default.Register<bool>(this, "EnabledWindow", EnabledWindow);
        }
        #endregion


        #region Events
        public void Loaded(object param)
        {

        }
        #endregion


        #region Methods
        private void EnabledWindow(bool val)
        {
            this.IsEnabledWindow = val;
        }


        #endregion

    }
}
