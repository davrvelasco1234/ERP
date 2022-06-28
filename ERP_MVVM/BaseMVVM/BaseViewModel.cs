
using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Toolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ERP_MVVM.BaseMVVM
{
    public class BaseViewModel : BaseViewModelDialog
    {
        //protected IMessenger Messenger { get; } = WeakReferenceMessenger.Default;

        /// <summary>
        /// Indica si hay o no error en alguna propiedad
        /// </summary>
        public bool HasErrorsProperties => this.HasErrors || this.ErroresListTextBoxType.Count > 0 ? true : false;
        /// <summary>
        /// Obtiene una cadena con los errores de captura
        /// </summary>
        public string GetErrorsProperties(string propertyName = null) => string.Join(Environment.NewLine, from ValidationResult e in GetErrors(propertyName) select e.ErrorMessage) +
                                                Environment.NewLine +
                                                string.Join(Environment.NewLine, from ERP_Common.ErpDictionary e in this.ErroresListTextBoxType select e.Descripcion);
        /// <summary>
        /// cadena con todos los errores de captura esta propiedad ya notifica los cambios a la pantalla
        /// </summary>
        public string GetErrorsMessage => GetErrorsProperties(null);





        private string textBoxTypeIsValid;
        public string TextBoxTypeIsValid
        {
            get => this.textBoxTypeIsValid;
            set
            {
                SetProperty(ref this.textBoxTypeIsValid, value);
                ValidaTextBoxType(this.textBoxTypeIsValid);
                OnPropertyChanged("GetErrorsMessage");
            }
        }


        private List<ERP_Common.ErpDictionary> ErroresListTextBoxType;



        private void Suspect_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(HasErrors))
            {
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        private void Suspect_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            OnPropertyChanged(nameof(GetErrorsMessage));
        }

        public BaseViewModel()
        {
            ErrorsChanged += Suspect_ErrorsChanged;
            PropertyChanged += Suspect_PropertyChanged;
            ErroresListTextBoxType = new List<ERP_Common.ErpDictionary>();
        }

        ~BaseViewModel()
        {
            ErrorsChanged -= Suspect_ErrorsChanged;
            PropertyChanged -= Suspect_PropertyChanged;
        }

        public void CallGarbageCollector()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }



        public void ValidaTextBoxType(string value)
        {
            /*
                col 0 == TRUE o FALSE 
                col 1 == id de campo 
                col 2 == message
                col 3 == nombre del campo, cuando el campo no tiene nombre el default es "Campo"
                col 4 == type al que se intento convertir
            */
            var paramss = value.Split('|');
            string status = paramss[0];
            string uid = paramss[1];
            string message = paramss[2];
            string name = paramss[3];
            string type = paramss[4];

            if (status == "TRUE")
            {
                var item = this.ErroresListTextBoxType.Where(W => W.Clave == uid).FirstOrDefault();
                if (!(item is null))
                {
                    this.ErroresListTextBoxType.Remove(item);
                }
            }
            else if (status == "FALSE")
            {
                var item = this.ErroresListTextBoxType.Where(W => W.Clave == uid).FirstOrDefault();
                if (item is null)
                {
                    this.ErroresListTextBoxType.Add(new ERP_Common.ErpDictionary { Clave = uid, Descripcion = "Conversión de tipo no válida en " + name });
                }
            }
        }



    }






    public class BaseViewModel<T> : BaseViewModelDialog<T>
    {
        //protected IMessenger Messenger { get; } = WeakReferenceMessenger.Default;

        /// <summary>
        /// Indica si hay o no error en alguna propiedad
        /// </summary>
        public bool HasErrorsProperties => this.HasErrors || this.ErroresListTextBoxType.Count > 0 ? true : false;
        /// <summary>
        /// Obtiene una cadena con los errores de captura
        /// </summary>
        public string GetErrorsProperties(string propertyName = null) => string.Join(Environment.NewLine, from ValidationResult e in GetErrors(propertyName) select e.ErrorMessage) +
                                                Environment.NewLine + 
                                                string.Join(Environment.NewLine, from ERP_Common.ErpDictionary e in this.ErroresListTextBoxType select e.Descripcion);
        /// <summary>
        /// cadena con todos los errores de captura esta propiedad ya notifica los cambios a la pantalla
        /// </summary>
        public string GetErrorsMessage => GetErrorsProperties(null);



        
        
        private string textBoxTypeIsValid;
        public string TextBoxTypeIsValid
        {
            get => this.textBoxTypeIsValid;
            set
            {
                SetProperty(ref this.textBoxTypeIsValid, value);
                ValidaTextBoxType(this.textBoxTypeIsValid);
                OnPropertyChanged("GetErrorsMessage");
            }
        }


        private List<ERP_Common.ErpDictionary> ErroresListTextBoxType;



        private void Suspect_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(HasErrors))
            {
                OnPropertyChanged(nameof(HasErrors));
            }
        }
        
        private void Suspect_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            OnPropertyChanged(nameof(GetErrorsMessage));
        }

        public BaseViewModel() 
        {
            ErrorsChanged += Suspect_ErrorsChanged;
            PropertyChanged += Suspect_PropertyChanged;
            ErroresListTextBoxType = new List<ERP_Common.ErpDictionary>();
        }

        ~BaseViewModel()
        {
            ErrorsChanged -= Suspect_ErrorsChanged;
            PropertyChanged -= Suspect_PropertyChanged;
        }

        public void CallGarbageCollector()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }



        public void ValidaTextBoxType(string value)
        {
            /*
                col 0 == TRUE o FALSE 
                col 1 == id de campo 
                col 2 == message
                col 3 == nombre del campo, cuando el campo no tiene nombre el default es "Campo"
                col 4 == type al que se intento convertir
            */
            var paramss = value.Split('|');
            string status = paramss[0];
            string uid = paramss[1];
            string message = paramss[2];
            string name = paramss[3];
            string type = paramss[4];

            if (status == "TRUE")
            {
                var item = this.ErroresListTextBoxType.Where(W => W.Clave == uid).FirstOrDefault();
                if (!(item is null))
                {
                    this.ErroresListTextBoxType.Remove(item);
                }
            }
            else if (status == "FALSE")
            {
                var item = this.ErroresListTextBoxType.Where(W => W.Clave == uid).FirstOrDefault();
                if (item is null)
                {
                    this.ErroresListTextBoxType.Add(new ERP_Common.ErpDictionary { Clave = uid, Descripcion = "Conversión de tipo no válida en " + name });
                }
            }
        }



        //private bool isActive;
        //
        //public bool IsActive
        //{
        //    get => this.isActive;
        //    set
        //    {
        //        if (SetProperty(ref this.isActive, value, true))
        //        {
        //            if (value)
        //            {
        //                OnActivated();
        //            }
        //            else
        //            {
        //                OnDeactivated();
        //            }
        //        }
        //    }
        //}
        //
        //protected virtual void OnActivated()
        //{
        //    Messenger.RegisterAll(this);
        //}
        //
        //protected virtual void OnDeactivated()
        //{
        //    Messenger.UnregisterAll(this);
        //}
        //
        //protected virtual void Broadcast<T>(T oldValue, T newValue, string propertyName)
        //{
        //    PropertyChangedMessage<T> message = new PropertyChangedMessage<T>(this, propertyName, oldValue, newValue);
        //
        //    _ = Messenger.Send(message);
        //}
        //
        //
        //











    }
    
}



