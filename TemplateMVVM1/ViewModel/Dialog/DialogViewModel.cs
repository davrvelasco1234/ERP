

using System.Windows;
using System.Windows.Input;

using TemplateMVVM1.Model;
using MVVM.BaseMVVM;
using MVVM.Model;


namespace TemplateMVVM1.ViewModel.Dialog
{
    public class DialogViewModel : BaseViewModel
    {
        #region Attribites
        private Persona persona = new Persona();
        #endregion


        #region Properties
        public Persona Persona
        {
            get { return this.persona; }
            set { SetValue(ref this.persona, value); }
        }
        #endregion


        #region Commands
        public ICommand LoadedCommand { get { return new RelayCommandMVVM(Loaded); } }
        public ICommand AceptarCommand { get { return new RelayCommandMVVM(Aceptar); } }
        public ICommand CancelarCommand { get { return new RelayCommandMVVM(Cancelar); } }
        #endregion


        #region Contructors
        public DialogViewModel()
        {

        }
        #endregion


        #region Events
        public void Loaded(object param)
        {

        }
        #endregion


        #region Methods
        public void Aceptar(object param)
        {

            Response response = new Response();
            response.IsSuccess = true;
            response.Message = "";
            response.MessageType = MessageType.Success;
            response.Result = this.Persona;
            this.CloseDialogWithResult(param as Window, response);

        }
        public void Cancelar(object param)
        {

            Response response = new Response();
            response.IsSuccess = false;
            response.Message = "Accion Cancelada";
            response.MessageType = MessageType.Warning;
            response.Result = null;
            this.CloseDialogWithResult(param as Window, response);

        }

        #endregion

    }
}
