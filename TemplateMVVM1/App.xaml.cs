using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;


namespace TemplateMVVM1
{
    public partial class App : Application
    {

        public static Entorno entorno;

        public static string DirectorioBase;

        private AppDomain domain;

        public static Boolean MuestraPantallaSeguridad = true;

        public App()
        {
            domain = AppDomain.CurrentDomain;
            AppDomain.CurrentDomain.AssemblyResolve += MyResolveEventHandler;
            DirectorioBase = AppDomain.CurrentDomain.BaseDirectory;
            domain.UnhandledException += domain_UnhandledException;
            this.Exit += Application_Exit;

        }

        [MTAThread()]
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

            if (e.Args.Count() > 0)
            {
                entorno = new Entorno(e);
            }
            else
            {
                entorno = new Entorno();
            }

            if (Entorno.Conexion == null)
            {
                System.Windows.MessageBox.Show("La configuración de la aplicación esta mal, comunicarse con sistemas: " + Entorno.UltimoError);
                System.Windows.Application.Current.Shutdown();
                return;
            }

            if (entorno.argumentos.Count() >= 2)
            {
                MuestraPantallaSeguridad = false;
            }

            //No se debe mover esta linea, por que si no la aplicación terminaria si se muestra la ventana de login primero
            var Main = new View.MainWindow();

            ValidaUsuario(e.Args);

            Main.Show();
        }

        public void ValidaUsuario(string[] args)
        {
            if (App.MuestraPantallaSeguridad)
            {
                var Seguridad = new Seguridad();
                Seguridad.ShowDialog();
                if (!Seguridad.Seguridad == true) System.Windows.Application.Current.Shutdown();
            }
            else
            {
                var usuario = args[0];
                var contraseña = string.Empty;

                if (args.Count() >= 1) contraseña = args[0];

                var mensajeError = string.Empty;
                var numeroError = string.Empty;
                var aux = "J";

                if (!Entorno.EjecutaSeguridad(usuario, contraseña, ref aux, ref mensajeError, ref numeroError))
                {
                    MessageBox.Show("Se produjo el siguiente error al intentar validar los datos: \n" + mensajeError);
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        private void Application_Exit(Object sender, System.Windows.ExitEventArgs e)
        {
            //Funcion para guardar/salvar configuraciónes, logs de cierre.
        }

        /*
    ''' <summary>
    ''' Esta funcion carga las dlls de un directorio designado. se debe implementar en caso de que alguna dll de problemas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="args"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
         * */
        public Assembly MyResolveEventHandler(Object sender, ResolveEventArgs args)
        {
            //This handler is called only when the common language runtime tries to bind to the assembly and fails.        

            //Retrieve the list of referenced assemblies in an array of AssemblyName.
            Assembly objExecutingAssemblies;
            objExecutingAssemblies = Assembly.GetExecutingAssembly();
            AssemblyName[] arrReferencedAssmbNames;
            arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

            //Loop through the array of referenced assembly names.
            foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
            {

                //Look for the assembly names that have raised the "AssemblyResolve" event.
                if ((strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(","))))
                {
                    //Build the path of the assembly from where it has to be loaded.
                    String strTempAssmbPath;
                    String nombreLibreria = args.Name.Substring(0, args.Name.IndexOf(","));

                    strTempAssmbPath = @"..\dll\" + nombreLibreria + ".dll";

                    Assembly MyAssembly = null;

                    //Load the assembly from the specified path. 
                    try
                    {
                        MyAssembly = Assembly.LoadFrom(strTempAssmbPath);
                    }
                    catch (ArgumentNullException ex)
                    {
                        var mensaje = formateaMiensajeExcepcion(ex, "No se encontró una libreria: " + nombreLibreria);
                        MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                    }
                    catch (System.IO.FileNotFoundException ex)
                    {
                        var mensaje = formateaMiensajeExcepcion(ex, "No se encontró una libreria: " + nombreLibreria);
                        MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                    }
                    catch (System.IO.FileLoadException ex)
                    {
                        var mensaje = formateaMiensajeExcepcion(ex, "No se pudo cargar una libreria: " + nombreLibreria);
                        MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                    }
                    catch (BadImageFormatException ex)
                    {
                        var mensaje = formateaMiensajeExcepcion(ex, "La libreria no es valida: " + nombreLibreria);
                        MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                    }
                    catch (System.Security.SecurityException ex)
                    {
                        var mensaje = formateaMiensajeExcepcion(ex, "No se pudo cargar una libreria por problemas de seguridad: " + nombreLibreria);
                        MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                    }
                    catch (ArgumentException ex)
                    {
                        var mensaje = formateaMiensajeExcepcion(ex, "Path a libreria invalido: '" + strTempAssmbPath + "'");
                        MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                    }
                    catch (System.IO.PathTooLongException ex)
                    {
                        var mensaje = formateaMiensajeExcepcion(ex, "El path de ejecucion es demasiado largo. " + strTempAssmbPath);
                        MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                    }
                    return MyAssembly;

                    //Return the loaded assembly.

                }
            }

            return null;

        }

        public void MyHandler(Object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
        }

        public void domain_UnhandledException(Object sender, System.UnhandledExceptionEventArgs e)
        {
            //Manipular la excepcion no controlada
            var Excepcion = (Exception)e.ExceptionObject;

            var mensaje = formateaMiensajeExcepcion(Excepcion, string.Empty);

            MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
        }

        public static string formateaMiensajeExcepcion(Exception Excepcion, String msgBase)
        {
            return formateaMiensajeExcepcion(Excepcion, msgBase, true);
        }

        public static string formateaMiensajeExcepcion(Exception Excepcion, String msgBase, Boolean MuestraStackTrace)
        {
            if (String.IsNullOrWhiteSpace(msgBase))
            {
                msgBase = "Ocurrio un error inesperado en la aplicación, comunicarse a sistemas.\n";
            }

            var MensajeError = msgBase + Excepcion.Message;

            if (MuestraStackTrace)
            {
                MensajeError += "\n" + Excepcion.StackTrace;
            }

            if (Excepcion.InnerException != null)
            {
                MensajeError += "\n" + Excepcion.InnerException.Message;

                if (MuestraStackTrace) MensajeError += "\n" + Excepcion.InnerException.StackTrace;

                if (Excepcion.InnerException is SqlException)
                {
                    var excepcionSQL = (SqlException)Excepcion.InnerException;

                    MensajeError += "\n" + "Codigo de error: " + excepcionSQL.ErrorCode;

                    MensajeError += "\n" + "Linea: " + excepcionSQL.LineNumber;

                    if (!String.IsNullOrWhiteSpace(excepcionSQL.Procedure)) MensajeError += "\n" + "Procedimiento: " + excepcionSQL.Procedure;

                    if (!String.IsNullOrWhiteSpace(excepcionSQL.Server)) MensajeError += "\n" + "Servidor:  " + excepcionSQL.Server;

                }
            }

            return MensajeError;

        }
    }
}
