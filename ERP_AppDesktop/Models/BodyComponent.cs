using System;
using System.Windows;
using ERP_Core.Components;
using ERP_MVVM.BaseMVVM;

namespace ERP_AppDesktop.Models
{
    public class BodyComponent : BaseViewModel
    {
        public string Name { get; set; }
        public IComponentView ComponentView { get; set; }


        public string NameSpace { get; set; }

        private Visibility isVisibilityItemsControl = Visibility.Visible;
        public Visibility IsVisibilityItemsControl
        {
            get => isVisibilityItemsControl;
            set => SetProperty(ref this.isVisibilityItemsControl, value);
        }
    }
}
