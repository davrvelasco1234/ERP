

using MVVM.BaseMVVM;
using System.Reflection;


namespace Templates.CB.Bottom
{
    public class BottomViewModel
    {
        public string System { get; }
        public string Server { get; }
        public string DataBase { get; }
        public string AssemblyName { get; }
        public string KeyUser { get; }
        public string Date { get; }

        static BottomViewModel()
        {
            var manager = new DataTemplateManager();
            manager.RegisterDataTemplate<BottomViewModel, ButtomControl>();
        }

        public BottomViewModel()
        {
            System = "CASA DE BOLSA";
            if (Entorno.ServidorActual.ToLower().Trim() == Entorno.ServidorProduccion.ToLower().Trim())
            {
                Server = "PRODUCCION";
                DataBase = "PRODUCCION";
            }
            else
            {
                Server = Entorno.ServidorActual;
                DataBase = Entorno.BaseDatos;
            }
            AssemblyName = "Programa: " + Assembly.GetEntryAssembly().GetName().Name;
            KeyUser = "Usuario: " + Entorno.ClaUsuario;
            Date = "Fecha: " + Entorno.FechaHoyFormato.ToShortDateString();
        }
    }
}
