﻿
using ERP_AppDesktop.Views;
using ERP_Common.Interfaces;
using ERP_Core;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ERP_AppDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : WindowERP
    {
        private string[] ParamsArg {get;}
        public MainWindow(IBottomTemplate bottom, string[] paramsArg) : base(bottom)
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
    }
}


