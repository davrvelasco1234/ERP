using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ERP_MVVM.BaseMVVM;
using Microsoft.Toolkit.Mvvm.Input;
using static ERP_Common.Helpers.Constantes;
using TemplateMVVM.Model;
using TemplateMVVM.Data;
using TemplateMVVM.ViewModel.Dialog;
using System.Reflection;
using System.IO;
using ERP_Log4Net;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;

namespace TemplateMVVM.ViewModel
{
    public class FrameContentViewModel : BaseViewModel
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

        private bool isVisibleProgress;
        public bool IsVisibleProgress
        {
            get => this.isVisibleProgress;
            set => SetProperty(ref this.isVisibleProgress, value);
        }



        public ICommand LoadedCommand => new RelayCommand(Loaded);
        public ICommand AddCommand => new RelayCommand(Add);
        public ICommand UpdateCommand => new RelayCommand(Update);
        public ICommand DeleteCommand => new RelayCommand(Delete);
        public ICommand DownloadExcelCommand => new RelayCommand(DownloadExcel);


        public FrameContentViewModel()
        {
            WindowLocator.ViewModelLocator.Messenger.SendAutosRegisterMessage(this);
        }


        #region Methods

        public void Loaded()
        {
            this.IsVisibleProgress = true;
            IEnumerable<Auto> resp = null;
            BackgroundWorker Background = new BackgroundWorker();
            Background.DoWork += (s, args) =>
            {
                System.Threading.Thread.Sleep(5000);
                resp = Querys.Sp_GetAutos();
            };
            Background.RunWorkerCompleted += (s, args) =>
            {
                this.AutoList = new ObservableCollection<Auto>(resp);
                this.IsVisibleProgress = false;
            };
            if (!Background.IsBusy) Background.RunWorkerAsync();
            
        }

        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public void DownloadExcel()
        {
            Custom4Net.LogMessage(Custom4Net.TracingLevel.ERROR,"Hello logging world!");

            //ERP_ExcelGeneric.MainDownloadExcel.Exec<Auto>(this.AutoList, new ERP_ExcelGeneric.Models.ConfigDownloadExcel { NameBook = "Autos" });
            //ERP_ExcelGeneric.MainDownloadExcel.Exec<Auto>(this.AutoList, new ERP_ExcelGeneric.Models.ConfigDownloadExcel { NameBook = "AutosTXT",
            //Extencion = ERP_ExcelGeneric.Models.Extencion.TXT, ColumnHeaders = false });
        }

        public void RecibeMessage(string mesage)
        {
            //ERP_Log4Net.Custom4Net.Initialize("FONDOS");

            ERP_Controls.Notification.Popup.ExecutePopup(MessageType.Warning, "Title", mesage);
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
