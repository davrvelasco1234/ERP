
using ERP_Common;           
using ERP_MVVM.BaseMVVM;    
using ERP_MVVM.Helpers;     
using ERP_Security.Models;  
using System.Linq;          
using System.Windows;       

namespace ERP_Security
{
    public class LoginERP
    {
        public static LoginRequest LoginRequest { get; internal set; } = new LoginRequest("", "", "", "", false);
        static LoginERP()
        {
            DataTemplateManager.RegisterDataTemplate<Login.LoginViewModel, Login.LoginControl>();
        }

        public static (bool resp, LoginRequest LoginRequest) Log(string[] paramsArg)
        {
            var resp = LoginERP.ShowLogin(paramsArg);

            if (resp is null) //se cerro la ventana del login
            {
                return (false, null);
            }
            if (!resp.IsSuccess)
            {
                if (!(paramsArg is null) || resp.MessageCode == ERP_Common.Helpers.Constantes.MessageCodeParamArg) //los datos que se enviaron en los argumentos son erroneos y se cierra la app    
                {
                    System.Windows.Application.Current.Shutdown();
                    return (false, resp.Result);
                }
                else
                {
                    MessageBox.Show(resp.Message); //se capturaron datos erroneos
                }
            }

            if (!resp.Result.StatusLog)
            {
                return (false, resp.Result);
            }
            return (true, resp.Result);
        }
        

        internal static ErpResponse<LoginRequest> ShowLogin(string[] param)
        {
            if (param is null)
            {
                BaseViewModelDialog<LoginRequest> dialog = new Login.LoginViewModel();
                var resp = DialogService<LoginRequest>.OpenDialog(dialog, "Login");
                if (!(resp is null)) LoginRequest = resp.Result;
                return resp;
            }
            else if (param.Count() == 6 || param.Count() == 2)
            {
                var log = new Login.LoginViewModel();
                var resp = log.InicializaArgs(param);
                LoginRequest = resp.Result;
                return resp;
            }
            else
            {
                return new ErpResponse<LoginRequest>("Cantidad de parametros Erroneos", ERP_Common.Helpers.Constantes.MessageCodeParamArg);
            }
        }

        public static void UnLog()
        {
            LoginRequest = new LoginRequest("","","","",false);
        }


    }
}
