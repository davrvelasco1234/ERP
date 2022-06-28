using System.Collections.ObjectModel;
using System.Windows.Input;
using ERP_Core.Components;
using ERP_MVVM.BaseMVVM;
using Microsoft.Toolkit.Mvvm.Input;

namespace ERP_InicializeCom.ViewModels
{
    public class InicializeViewModel : BaseViewModel, IComponentView
    {
        #region Fields
        //private string Att;
        #endregion


        #region Properties
        private ObservableCollection<object> objectList;
        public ObservableCollection<object> ObjectList
        {
            get => this.objectList;
            set => SetProperty(ref this.objectList, value);
        }

        private object objectSelected;
        public object ObjectSelected
        {
            get => this.objectSelected;
            set => SetProperty(ref this.objectSelected, value);
        }
        #endregion


        #region Commands
        public ICommand LoadedCommand => new RelayCommand(Loaded);
        #endregion


        #region Services

        #endregion

        #region Contructors
        public InicializeViewModel()
        {

        }
        #endregion


        #region Loaded
        public void Loaded()
        {

        }
        #endregion


        #region Methods

        #endregion
    }
}
