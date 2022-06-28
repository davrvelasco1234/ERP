
using System.Reflection;
using ERP_MVVM.Helpers;
using ERP_Common.Interfaces;



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
        }
    }
}
