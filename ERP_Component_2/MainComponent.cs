
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using ERP_Components;
using ERP_MVVM.Helpers;

namespace ERP_Component_2
{
    [Export(typeof(IComponent))]
    public class MainComponent : IComponent
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.ComponentViewModel, Views.ComponentControl>();
        }

        public string ComponentName => "Pruebas Component";

        public object ComponentContent => "Pruebas Component";

        public string ComponentCode => "codigo de pruebas";

        public ComponentInfo ComponentInfo() => new ComponentInfo
        {
            Code = "Pruebas",
            Name = "Pruebas"
        };

        public IComponentView GetComponent() => new ViewModels.ComponentViewModel();

        public UserControl GetControl() => new Views.ComponentControl();


        public UserControl GetControlView() => new Views.ComponentControl();
        public object GetControlViewModel() => new ViewModels.ComponentViewModel();
        public string Title => "Titulo";


        public Func<UserControl> FuncControlView(object param) => null;
        public Func<object> FuncViewModel() => () => null;
    }
}
