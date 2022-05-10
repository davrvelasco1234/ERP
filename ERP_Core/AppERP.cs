

using ERP_Common;
using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;



namespace ERP_Core
{

    public class AppERP : Application
    {
        public static string DirectorioBase;
        private AppDomain domain;


        protected AppERP()
        {
            domain = AppDomain.CurrentDomain;
            //AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveHandlerPRUEBAS; 
            DirectorioBase = AppDomain.CurrentDomain.BaseDirectory;
            domain.UnhandledException += domain_UnhandledException;
            this.Exit += Application_Exit;
        }

        /*
        [MTAThread()]
        protected override void OnStartup(System.Windows.StartupEventArgs e)
        {
            base.OnStartup(e);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-MX");

        }
        */


        private void Application_Exit(Object sender, System.Windows.ExitEventArgs e)
        {
            //Funcion para guardar/salvar configuraciónes, logs de cierre.
        }

        /*
        protected Assembly AssemblyResolveHandlerPRUEBAS(Object sender, ResolveEventArgs args)
        {
            Assembly entryAssembly = Assembly.GetEntryAssembly();
            AssemblyName[] assemblyNames = entryAssembly.GetReferencedAssemblies();

            foreach (AssemblyName item in assemblyNames)
            {
                string nombreLibreria = args.Name.Substring(0, args.Name.IndexOf(","));

                string pathCore = @"..\DllCore\" + nombreLibreria + ".dll";
                string pathDev = @"..\dllDev\" + nombreLibreria + ".dll";
                string pathSystem = @"..\dllSystem\" + nombreLibreria + ".dll";
                string pathNuget = @"..\dllNuget\" + nombreLibreria + ".dll";
                string path = "";

                if (System.IO.File.Exists(path))
                    path = pathCore;
                else if (System.IO.File.Exists(path))
                    path = pathDev;
                else if (System.IO.File.Exists(path))
                    path = pathSystem;
                else if (System.IO.File.Exists(path))
                    path = pathNuget;

                //if (path == "") continue;


                Assembly MyAssembly = null;

                try
                {
                    MyAssembly = Assembly.LoadFrom(path);
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
                    var mensaje = formateaMiensajeExcepcion(ex, "Path a libreria invalido: '" + path + "'");
                    MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                }
                catch (System.IO.PathTooLongException ex)
                {
                    var mensaje = formateaMiensajeExcepcion(ex, "El path de ejecucion es demasiado largo. " + path);
                    MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
                }
                return MyAssembly;
            }

            return null;
        }
        */

        /*
        protected Assembly AssemblyResolveHandler(Object sender, ResolveEventArgs args)
        {

            //Retrieve the list of referenced assemblies in an array of AssemblyName.
            Assembly objExecutingAssemblies = Assembly.GetExecutingAssembly();
            
            Assembly objExecutingAssemblies2 = Assembly.GetCallingAssembly();
            Assembly objExecutingAssemblies3 = Assembly.GetEntryAssembly();
            AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies3.GetReferencedAssemblies();

            
            foreach (AssemblyName strAssmbName in arrReferencedAssmbNames)
            {
                var asdf = strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(","));
                var qwe = args.Name.Substring(0, args.Name.IndexOf(","));

                if (strAssmbName.FullName.Substring(0, strAssmbName.FullName.IndexOf(",")) == args.Name.Substring(0, args.Name.IndexOf(",")))
                {
                    //Build the path of the assembly from where it has to be loaded.
                    String strTempAssmbPath;
                    String nombreLibreria = args.Name.Substring(0, args.Name.IndexOf(","));

                

                    strTempAssmbPath = @"..\dll\" + nombreLibreria + ".dll";

                    Assembly MyAssembly = null;

                if ("ERP_AppDesktop.resources" == nombreLibreria) { continue; }

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
                }
            }

            return null;

        }
        */


        protected void MyHandler(Object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
        }

        protected void domain_UnhandledException(Object sender, System.UnhandledExceptionEventArgs e)
        {
            var Excepcion = (Exception)e.ExceptionObject;

            var mensaje = formateaMiensajeExcepcion(Excepcion, string.Empty);

            MessageBox.Show(mensaje, "Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.None);
        }

        protected static string formateaMiensajeExcepcion(Exception Excepcion, String msgBase)
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
