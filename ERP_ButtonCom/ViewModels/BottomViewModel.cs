
using System.Reflection;
using ERP_MVVM.Helpers;
using ERP_Common.Interfaces;
using ERP_ButtonCom.Views;
using ERP_Components;

namespace ERP_ButtonCom.ViewModels
{
    public class BottomViewModel : IBottomTemplate, IComponentView
    {
        public string System { get; }
        public string Server { get; }
        public string DataBase { get; }
        public string AssemblyName { get; }
        public string KeyUser { get; }
        public string Date { get; }
        public double FontSize { get; }

        static BottomViewModel()
        {
            //var manager = new DataTemplateManager();
            //manager.RegisterDataTemplate<BottomViewModel, BottomControl>();
        }

        public BottomViewModel()
        {
            System = "ERP";
            if ("SERVIDOR ACTUAL" == "SERVIDOR PRODUCCION")
            {
                Server = "PRODUCCION";
                DataBase = "PRODUCCION";
            }
            else
            {
                Server = "Servidor";
                DataBase = "BaseDatos";
            }
            AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            KeyUser = "Usuario: " + "000000";
            Date = "Fecha: " + "00/00/0000";
            FontSize = ERP_Common.Helpers.Constantes.FontSizeMedium;
        }
    }
}
