

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ERP_Common;
using ERP_MVVM.BaseMVVM;
using ERP_Security.Models;
using Microsoft.Toolkit.Mvvm.Input;



namespace ERP_Security.Login
{
    public class LoginViewModel : BaseViewModel<LoginRequest>
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
            

            this.UserIsFocused = true;
        }
        //admin admin 123 QA 127.0.0.1 1801


        public ErpResponse<LoginRequest> InicializaArgs(string[] param)
        {
            this.User = param[0];
            this.Rol = param[1];
            this.Password = param[2];
            this.ServidorSelected = new Servidor
            {
                Server = param[3],
                IP = param[4],
                Puerto = param[5],
            };

            var resp = UserList.Where(W => W.User == this.User && W.Rol == this.Rol && W.Password == this.Password).FirstOrDefault();
            if (resp is null)
            {
                return new ErpResponse<LoginRequest>("Error en parametros ", 998);
            }

            //si el login es correcto se retorna la respuesta
            var respLog = new LoginRequest(resp.User, resp.UserName, resp.Rol, resp.Password, true);
            return new ErpResponse<LoginRequest>(respLog);   
        }

        private void Login(Window window)
        {
            var resp = UserList.Where(W => W.User == this.User && W.Rol == this.Rol && W.Password == this.Password).FirstOrDefault();
            if (resp is null)
            {
                MessageBox.Show("datos invalidos");
                return;
            }

            //si el login es correcto se retorna la respuesta
            var respLog = new LoginRequest(resp.User, resp.UserName, resp.Rol, resp.Password, true);
            this.CloseDialogWithResult(window, new ErpResponse<LoginRequest>(respLog));
        }

        private void PasswordChanged(PasswordBox obj) 
            => this.Password = obj.Password;
        
    }
}


