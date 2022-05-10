using ERP_Components;
using ERP_MVVM.BaseMVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
