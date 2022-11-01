

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ERP_Common;
using ERP_MVVM.BaseMVVM;
using ERP_Security.Models;
using Microsoft.Toolkit.Mvvm.Input;



namespace ERP_Security.Login
{
    internal class LoginViewModel : BaseViewModel<LoginRequest>
    {
        private static IEnumerable<LoginRequest> UserList { get; set; }

        private string user;
        public string User
        {
            get => user; 
            set => SetProperty(ref user, value); 
        }

        private string rol;
        public string Rol
        {
            get => rol;
            set => SetProperty(ref rol, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private ObservableCollection<Servidor> servidorList;
        public ObservableCollection<Servidor> ServidorList
        {
            get => servidorList;
            set => SetProperty(ref servidorList, value);
        }

        private Servidor servidorSelected;
        public Servidor ServidorSelected
        {
            get => servidorSelected;
            set => SetProperty(ref servidorSelected, value);
        }

        private bool userIsFocused;
        public bool UserIsFocused
        {
            get => userIsFocused;
            set => SetProperty(ref userIsFocused, value);
        }
        

        public ICommand LoadedCommand => new RelayCommand(Loaded);
        public ICommand PasswordChangedCommand => new RelayCommand<PasswordBox>(PasswordChanged);
        public ICommand LoginCommand => new RelayCommand<Window>(Login);


        static LoginViewModel()
        {
            UserList = new List<LoginRequest>()
            {
                new LoginRequest("admin",   "Usuario Administrador",    "admin",    "123", false),
                new LoginRequest("dev",     "Usuario Developer",        "dev",      "456", false),
                new LoginRequest("test",    "Usuario Tester",           "test",     "789", false),
                new LoginRequest("user",    "Usuario",                  "user",     "000", false),
            };
        }

        public LoginViewModel()
        {
            this.ServidorList = new ObservableCollection<Servidor>()
            {
                new Servidor{ Server="Produccion", IP="127.0.0.1", Puerto = "1800"},
                new Servidor{ Server="QA", IP="127.0.0.1", Puerto = "1801"}
            };
            this.User = "admin";
            this.Rol = "admin";
            this.Password = "123";
            this.ServidorSelected = this.ServidorList.FirstOrDefault();
        }


        public void Loaded()
        {
            //admin admin 123 QA 127.0.0.1 1801
            this.UserIsFocused = true;
        }


        public ErpResponse<LoginRequest> InicializaArgs(string[] param)
        {
            if (param.Count() == 6)
            {
                string user = param[0];
                string rol = param[1];
                string password = param[2];
                string server = param[3];
                string ip = param[4];
                string puerto = param[5];
                return InicializaArgs(user, rol, password, server, ip, puerto);
            }
            else if (param.Count() == 2)
            {
                string user = param[0];
                string password = param[1];
                return InicializaArgs(user, password, "J");
            }
            else
            {
                return new ErpResponse<LoginRequest>("Error en parametros ", ERP_Common.Helpers.Constantes.MessageCodeParamArg);
            }
        }



        internal ErpResponse<LoginRequest> InicializaArgs(string user, string password, string origen)
        {
            this.User = user;
            this.Password = password;
            this.Rol = "ROL";
            var app = Assembly.GetEntryAssembly().GetName().Name;
            var terminal = System.Net.Dns.GetHostName();
            var resp = Data.Querys.sppValidaSeguridad(new { Usuario = User, Contrasena = Password, Pantalla = app, Terminal= terminal, Origen = origen});

            if (resp is null)
            {
                return new ErpResponse<LoginRequest>("Error en parametros ", ERP_Common.Helpers.Constantes.MessageCodeParamArg);
            }
            if (resp.Clave != "0")
            {
                return new ErpResponse<LoginRequest>("Error Log " + resp.Descripcion, ERP_Common.Helpers.Constantes.MessageCodeErrorLog);
            }

            //si el login es correcto se retorna la respuesta
            var respLog = new LoginRequest(this.user, this.User, this.Rol, this.Password, true);
            return new ErpResponse<LoginRequest>(respLog);   
        }


        internal ErpResponse<LoginRequest> InicializaArgs(string user, string rol, string pass, string server, string ip, string puerto)
        {
            this.User = user;
            this.Rol = rol;
            this.Password = pass;
            this.ServidorSelected = new Servidor
            {
                Server = server,
                IP = ip,
                Puerto = puerto
            };

            
            var resp = UserList.Where(W => W.User == this.User && W.Rol == this.Rol && W.Password == this.Password).FirstOrDefault();
            if (resp is null)
            {
                return new ErpResponse<LoginRequest>("Error en parametros ", ERP_Common.Helpers.Constantes.MessageCodeParamArg);
            }

            //si el login es correcto se retorna la respuesta
            var respLog = new LoginRequest(this.User, this.User, this.Rol, this.Password, true);
            return new ErpResponse<LoginRequest>(respLog);
        }

        private void Login(Window window)   
        {
            var resp = InicializaArgs(this.User, this.Password, "V");
            
            if (!resp.IsSuccess)
            {
                MessageBox.Show("datos invalidos");
                return;
            }

            //si el login es correcto se retorna la respuesta
            var respLog = new LoginRequest(this.User, this.User, this.Rol, this.Password, true);
            this.CloseDialogWithResult(window, new ErpResponse<LoginRequest>(respLog));
        }

        private void PasswordChanged(PasswordBox obj) 
            => this.Password = obj.Password;
        
    }
}


