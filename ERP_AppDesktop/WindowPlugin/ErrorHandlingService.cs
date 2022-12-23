
using PluginHosting;
using PluginInterfaces;
using System;
using System.Windows;

namespace ERP_AppDesktop.WindowPlugin
{
    public class ErrorHandlingService
    {
        private readonly ILog _log;

        public ErrorHandlingService(ILog log)
        {
            _log = log;
        }

        public void ShowError(string message, Exception ex)
        {
            _log.Error(message, ex);

            var text = (ex == null) ? message : message + GetSeparator(message) + ExceptionUtil.GetUserMessage(ex);

            var mainWindow = GetMainWindow();
            if (mainWindow == null)
            {
                MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(mainWindow, text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LogError(string message, Exception ex)
        {   
            _log.Error(message, ex);    
        }   

        public bool Confirm(string message) 
        {
            return MessageBox.Show(message, "Please confirm", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK;  
        }

        private static Window GetMainWindow()   
        {   
            if (Application.Current == null) return null;   
            return Application.Current.MainWindow;  
        }   

        private static string GetSeparator(string message)
        {
            if (message.EndsWith(".")) return " ";
            if (message.EndsWith("\n")) return "";
            return ". ";
        }
    }
}
