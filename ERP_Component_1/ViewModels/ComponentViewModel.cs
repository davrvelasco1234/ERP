

using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ERP_Component_1.Data;
using ERP_Component_1.Identity;
using ERP_Component_1.ViewModels.Dialog;
using ERP_Core.Components;
using ERP_MVVM.BaseMVVM;
using ERP_MVVM.Notification;
using Microsoft.Toolkit.Mvvm.Input;
using static ERP_Common.Helpers.Constantes;

namespace ERP_Component_1.ViewModels
{
    public class ComponentViewModel : BaseViewModel, IComponentView
    {

        private ObservableCollection<Auto> autoList;
        public ObservableCollection<Auto> AutoList
        {
            get => this.autoList;
            set => SetProperty(ref this.autoList, value);
        }

        private Auto autoSelected;
        public Auto AutoSelected
        {
            get => this.autoSelected;
            set => SetProperty(ref this.autoSelected, value);
        }


        public ICommand LoadedCommand => new RelayCommand(Loaded);
        public ICommand AddCommand => new RelayCommand(Add);
        public ICommand UpdateCommand => new RelayCommand(Update);
        public ICommand DeleteCommand => new RelayCommand(Delete);
        public ICommand DownloadExcelCommand => new RelayCommand(DownloadExcel);
        

        public ComponentViewModel()
        {
            MainComponent.Messenger.SendAutosRegisterMessage(this);
        }

        public void Loaded()
        {
            this.AutoList = new ObservableCollection<Auto>(Querys.Sp_GetAutos());
        }

        #region Methods

        
        public void DownloadExcel() 
        {
            ERP_ExcelGeneric.MainDownloadExcel.Exec<Auto>(this.AutoList, new ERP_ExcelGeneric.Models.ConfigDownloadExcel { NameBook = "Autos", ColNum = new int[] { 6 }, ColDate = new int[] { 7 } }); 
        }

        public void RecibeMessage(string mesage)
        {
            Popup.ExecutePopup(MessageType.Warning, "Title", mesage);
        }


        public void SendAutos()
        {
            MainComponent.Messenger.GetAutosMessage(this.AutoList);
        }

        public Auto SendAutos2()
        {
            return this.AutoList.FirstOrDefault();
        }

        public void AddItem(Auto auto)
        {
            Data.Querys.Insert_Auto(auto);
            Loaded();
        }

        public void Add()
        {
            var response = OpenDialogMVVM.Show(new AutoMtoViewModel(), "Inserta Auto");
            if (response.IsSuccess == false) return;

            Data.Querys.Insert_Auto(response.Result);

            Loaded();
        }

        public void Update()
        {
            var response = OpenDialogMVVM.Show(new AutoMtoViewModel(this.AutoSelected), "Mantenimiento Auto");
            if (response.IsSuccess == false) return;

            Data.Querys.Update_Auto(response.Result);

            Loaded();
        }

        public void Delete()
        {
            Data.Querys.Delete_Auto(this.AutoSelected);
            Loaded();
        }

        #endregion

    }

}


