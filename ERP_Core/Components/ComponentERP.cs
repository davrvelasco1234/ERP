using System;
using System.Windows;
using ERP_Common.Helpers;
using ERP_Core.Components;


namespace ERP_Core.Components
{
    public abstract class ComponentERP : IComponentERP
    {
        public virtual ComponentInfo ComponentInfo => new ComponentInfo
        {
            ComponentName = "Name",
            ComponentContent = "Content",
            ComponentCode = "Code",
            Title = "Title"
        };

        public abstract IComponentView GetInstansComponent();


        public IComponentView GetComponent()
        {
            try
            {
                return GetInstansComponent();
            }
            catch (Exception e)
            {
                SendMessage(e.FnxGetMessage());
                return null;
            }
        }

        private void SendMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        
    }
}
