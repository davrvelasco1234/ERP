using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ERP_Components;
using ERP_Entorno;
using ERP_MVVM.BaseMVVM;
using Microsoft.Toolkit.Mvvm.Input;


namespace ERP_Component_2.ViewModels
{
    public class ComponentViewModel : BaseViewModel, IComponentView
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
        public ComponentViewModel()
        {
            //string query = "select count(*) from Autos";
            //var resp = Entorno.ExecQuery.ExecuteScalar<int>(query, null);
            //var asd = "";
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
