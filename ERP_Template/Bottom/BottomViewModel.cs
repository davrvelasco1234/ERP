using System.Reflection;
using ERP_MVVM.Helpers;
using ERP_Common.Interfaces;
using ERP_Entorno;
using ERP_Entorno.Helpers;

namespace ERP_Template.Bottom
{
    public class BottomViewModel : IBottomTemplate
    {
        public string System { get; }
        public string Server { get; }
        public string DataBase { get; }
        public string AssemblyName { get; }
        public string KeyUser { get; }
        


        public string Date { get; }

        static BottomViewModel()
        {
            DataTemplateManager.RegisterDataTemplate<BottomViewModel, BottomControl>();
        }

        public BottomViewModel()
        {
            System = "ERP";
            if (Entorno.GetProperty.ServidorProduccion() == Entorno.SqlConnection.InitialCatalog)
            {
                Server = "PRODUCCION";
                DataBase = "PRODUCCION";
            }
            else
            {
                Server = Entorno.SqlConnection.DataSource;
                DataBase = Entorno.SqlConnection.InitialCatalog;
            }
            AssemblyName = Entorno.GetProperty.AssemblyName;
            KeyUser = ERP_Security.LoginERP.LoginRequest.User;
            Date = Entorno.GetProperty.FechaHoy().ToDateFormat();
        }

        

    }
}
