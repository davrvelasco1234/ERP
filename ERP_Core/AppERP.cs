﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ERP_Common.Helpers;



namespace ERP_Core
{

    public class AppERP : Application
    {
        private readonly object _lock = new object();
        public static string DirectorioBase;
        private AppDomain domain;


        protected AppERP()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            //DispatcherUnhandledException += App_DispatcherUnhandledException;
            //TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            this.Exit += Application_Exit;
        }


        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            lock (_lock)
            {
                var resp = "UnobservedTaskException" + Environment.NewLine + e.Exception.FnxGetMessage();
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    SendMessage(resp)
                ), DispatcherPriority.Normal);
            }
        }
        

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            lock (_lock)
            {
                var resp = "DispatcherUnhandledException" + Environment.NewLine + e.Exception.FnxGetMessage();
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    SendMessage(resp)
                ), DispatcherPriority.Normal);
            }
        }
        

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            lock (_lock)
            {
                var resp = ((Exception)e.ExceptionObject).FnxGetMessage();
                SendMessage(resp);
            }   
        }
        

        private void SendMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void Application_Exit(Object sender, System.Windows.ExitEventArgs e)
        {
            //Funcion para guardar/salvar configuraciónes, logs de cierre.
        }

        

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

    }

}




