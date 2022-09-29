
using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVM.BaseMVVM;


namespace PluginPruebas.ViewModel
{
    public class Frame2ViewModel : BaseViewModel
    {
        #region Attribites
        private ObservableCollection<object> objectList = new ObservableCollection<object>();
        private object objectSelected = new object();
        #endregion


        #region Properties
        public ObservableCollection<object> ObjectList
        {
            get { return this.objectList; }
            set { SetValue(ref this.objectList, value); }
        }
        public object ObjectSelected
        {
            get { return this.objectSelected; }
            set { SetValue(ref this.objectSelected, value); }
        }
        #endregion


        #region Commands
        public ICommand LoadedCommand { get { return new RelayCommandMVVM(Loaded); } }
        #endregion


        #region Contructors
        public Frame2ViewModel()
        {

        }
        #endregion


        #region Events
        public void Loaded(object param)
        {

        }
        #endregion


        #region Methods

        #endregion

    }
}
