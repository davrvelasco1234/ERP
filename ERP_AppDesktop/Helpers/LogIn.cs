using ERP_Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ERP_AppDesktop.Helpers
{
    public class LogIn
    {
        public static bool Log(string[] paramsArg)
        {
            var resp = LoginERP.ShowLogin(paramsArg);   

            if (resp is null) //se cerro la ventana del login
            {
                return false;
            }
            if (!resp.IsSuccess)
            {
                if (resp.MessageCode == ERP_Common.Helpers.Constantes.MessageCodeParamArg) //los datos que se enviaron en los argumentos son erroneos y se cierra la app    
                {
                    System.Windows.Application.Current.Shutdown();
                    return false;
                }
                else
                {
                    MessageBox.Show(resp.Message); //se capturaron datos erroneos
                }
            }

            if (!resp.Result.StatusLog)
            {
                return false;
            }

            return true;

        }
    }
}
