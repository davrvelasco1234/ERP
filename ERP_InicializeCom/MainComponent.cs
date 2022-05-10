
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using ERP_Components;
using ERP_MVVM.Helpers;

namespace ERP_InicializeCom
{
    [Export(typeof(IComponent))]
    public class MainComponent : IComponent
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.InicializeViewModel, Views.InicializeControl>();
        }

        public string ComponentName => "MainComponent";

        public object ComponentContent => "Menu Inicialize";

        public string ComponentCode => "ERP_InicializeCom";

        public ComponentInfo ComponentInfo() => new ComponentInfo
        {
            Code = "ERP",
            Name = "ERP_InicializeCom"
        };

        public IComponentView GetComponent() => new ViewModels.InicializeViewModel();

        public UserControl GetControl() => new Views.InicializeControl();


        public UserControl GetControlView() => new Views.InicializeControl();
        public object GetControlViewModel() => new ViewModels.InicializeViewModel();
        public string Title => "Titulo";


        public Func<UserControl> FuncControlView(object param) => null;
        public Func<object> FuncViewModel() => () => null;
    }
}
