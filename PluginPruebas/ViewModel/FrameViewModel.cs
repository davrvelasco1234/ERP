

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using PluginPruebas.Model;
using MVVM.Model;
using MVVM.BaseMVVM;
using MVVM.Notification;
using MVVM.Messenger;

namespace PluginPruebas.ViewModel
{
    public class FrameViewModel : BaseViewModel
    {
        #region Attribites
        private ObservableCollection<object> objectList = new ObservableCollection<object>();
        private object objectSelected = new object();

        private bool panelLoading;
        private string panelMainMessage;
        private string panelSubMessage;

        #endregion


        #region Properties

        public bool PanelLoading
        {
            get { return this.panelLoading; }
            set { SetValue(ref this.panelLoading, value); }
        }
        public string PanelMainMessage
        {
            get { return this.panelMainMessage; }
            set { SetValue(ref this.panelMainMessage, value); }
        }
        public string PanelSubMessage
        {
            get { return this.panelSubMessage; }
            set { SetValue(ref this.panelSubMessage, value); }
        }
        #endregion


        #region Commands
        public ICommand LoadedCommand { get { return new RelayCommandMVVM(Loaded); } }
        public ICommand BookCommand { get { return new RelayCommandMVVM(Book); } }
        public ICommand ExcelCommand { get { return new RelayCommandMVVM(Excel); } }
        public ICommand RefreshCommand { get { return new RelayCommandMVVM(Refresh); } }
        public ICommand AddCommand { get { return new RelayCommandMVVM(Add); } }

        #endregion


        #region Contructors
        public FrameViewModel()
        {




        }
        #endregion


        #region Events
        public void Loaded(object param)
        {


        }
        #endregion



        #region Methods
        public void Book(object param)
        {
            MessageBox.Show("BOOK", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        Balloon Balloon;
        public void Excel(object param)
        {

            //Popup.ExecutePopup(MessageType.Warning, "Botton Seleccionado", "EXCEL");

             //Balloon Balloon;
            //if (!(this.Balloon is null)) { this.Balloon.Close(); }
            //if (!(param is null) && ((Control)param).IsVisible)
            //{
            //    this.Balloon = new Balloon((Control)param,
            //    "Titulo",
            //    "Menssage",
            //    MessageType.Warning);
            //    this.Balloon.Show();
            //}


            Response response = new Response();
            DialogBaseViewModel dialogBaseViewModel = new ViewModel.Dialog.DialogViewModel();
            response = DialogService.OpenDialog(dialogBaseViewModel, "TituloDialogo");
            if (response == null || response.IsSuccess == false)
            {
                return;
            }
            var resp = (object)response.Result;


        }

        public void Refresh(object param)
        {
            this.PanelSubMessage = "Validando....";
            this.PanelLoading = true;
            Messenger.Default.Send<bool>(false, "EnabledWindow");

            BackgroundWorker Background = new BackgroundWorker();
            Background.DoWork += (s, args) =>
            {

                //TAREA EN SEGUNDO PLANO
                Thread.Sleep(10000);

            };
            Background.RunWorkerCompleted += (s, args) =>
            {

                //TAREA EN PRIMER PLANO
                this.PanelLoading = false;
                Messenger.Default.Send<bool>(true, "EnabledWindow");

            };
            if (!Background.IsBusy) Background.RunWorkerAsync();

        }
        public void Add(object param)
        {

            Response response = new Response();
            DialogBaseViewModel dialogBaseViewModel = new DialogBaseViewModel();
            response = DialogService.OpenDialog(dialogBaseViewModel, "TituloDialogo");
            if (response == null || response.IsSuccess == false)
            {
                return;
            }
            Persona resp = (Persona)response.Result;


        }
        #endregion

    }
}
