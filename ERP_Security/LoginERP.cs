
using ERP_Common;
using ERP_MVVM.BaseMVVM;
using ERP_MVVM.Helpers;
using ERP_Security.Models;
using System.Linq;

namespace ERP_Security
{
    public class LoginERP
    {
        public static LoginRequest LoginRequest { get; internal set; } = new LoginRequest("", "", "", "", false);
        static LoginERP()
        {
            DataTemplateManager.RegisterDataTemplate<Login.LoginViewModel, Login.LoginControl>();
        }
        

        public static ErpResponse<LoginRequest> ShowLogin(string[] param)
        {
            if (param is null)
            {
                BaseViewModelDialog<LoginRequest> dialog = new Login.LoginViewModel();
                var resp = DialogService<LoginRequest>.OpenDialog(dialog, "Login");
                if (!(resp is null)) LoginRequest = resp.Result;
                return resp;
            }
            else if (param.Count() == 6)
            {
                var log = new Login.LoginViewModel();
                var resp = log.InicializaArgs(param);
                LoginRequest = resp.Result;
                return resp;
            }
            else
            {
                return new ErpResponse<LoginRequest>("Cantidad de parametros Erroneos",998);
            }
        }

        public static void UnLog()
        {
            LoginRequest = new LoginRequest("","","","",false);
        }


    }
}
