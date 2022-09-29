using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ERP_Core.Components;
using ERP_MVVM.BaseMVVM;
using ERP_MVVM.Notification;
using Microsoft.Toolkit.Mvvm.Input;
using static ERP_Common.Helpers.Constantes;
using TemplateMVVM.Model;
using TemplateMVVM.Data;
using TemplateMVVM.ViewModel.Dialog;

namespace TemplateMVVM.ViewModel
{
    public class FrameViewModel : BaseViewModel
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


        public FrameViewModel()
        {
            WindowLocator.ViewModelLocator.Messenger.SendAutosRegisterMessage(this);
        }

        public void Loaded()
        {
            this.AutoList = new ObservableCollection<Auto>(Querys.Sp_GetAutos());
        }

        #region Methods


        public void DownloadExcel()
        {
            ERP_ExcelGeneric.MainDownloadExcel.Exec<Auto>(this.AutoList, new ERP_ExcelGeneric.Models.ConfigDownloadExcel { NameBook = "Autos" });
        }

        public void RecibeMessage(string mesage)
        {
            Popup.ExecutePopup(MessageType.Warning, "Title", mesage);
        }


        public void SendAutos()
        {
            WindowLocator.ViewModelLocator.Messenger.GetAutosMessage(this.AutoList);
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


            var response = OpenDialogMVVM.Show(new MtoViewModel(), "Inserta Auto");
            if (response.IsSuccess == false) return;

            Data.Querys.Insert_Auto(response.Result);

            Loaded();
        }

        public void Update()
        {
            var response = OpenDialogMVVM.Show(new MtoViewModel(this.AutoSelected), "Mantenimiento Auto");
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
