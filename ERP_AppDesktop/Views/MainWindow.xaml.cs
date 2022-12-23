using ERP_AppDesktop.ViewModels;
using ERP_AppDesktop.WindowPlugin;
using ERP_Common.Interfaces;
using ERP_Core;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ERP_AppDesktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowErp
    {
        private string[] ParamsArg { get; }
        public MainWindow(string[] paramsArg)
        {
            InitializeComponent();
            this.ParamsArg = paramsArg;
        }

        private void WindowERP_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            SetFocusIndex();
        }

        private void WindowERP_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == System.Windows.Input.Key.Escape)
                {
                    SetFocusIndex();
                }
            }
            catch (System.Exception)
            {


            }
        }

        private void SetFocusIndex()
        {
            index.Focus();
            index.Focusable = true;
            index.ForceCursor = true;
        }




        private void OnLoadPluginClick(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel == null) return;

            var menuItem = sender as MenuItem;
            if (menuItem == null) return;

            var catalogEntry = menuItem.CommandParameter as PluginCatalogEntry;
            if (catalogEntry == null) return;

            viewModel.LoadPluginCommand.Execute(catalogEntry);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            var viewModel = DataContext as IDisposable;
            if (viewModel == null) return;
            viewModel.Dispose();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Move tab panel 25 pixels to the right
            // Cannot do it through style, because Margin is hard coded in the TabControl template
            var tabPanel = GetChildOfType<TabPanel>(PluginTabs);
            tabPanel.Margin = new Thickness(25, 2, 2, 2);
        }

        private static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            var count = VisualTreeHelper.GetChildrenCount(depObj);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel == null) return;
            e.Cancel = !viewModel.CanClose();
        }




    }
}
