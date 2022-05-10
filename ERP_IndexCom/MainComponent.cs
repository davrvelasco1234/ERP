
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using ERP_Components;
using ERP_MVVM.Helpers;

namespace ERP_IndexCom
{
    [Export(typeof(IComponent))]
    public class MainComponent : IComponent
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.IndexViewModel, Views.IndexControl>();
        }

        public string ComponentName => "ERP_IndexCom";

        public object ComponentContent => "Menu ERP";

        public string ComponentCode => "ERP_IndexCom";

        public ComponentInfo ComponentInfo() => new ComponentInfo
        {
            Code = "ERP",
            Name = "ERP_IndexCom"
        };

        public IComponentView GetComponent() => new ViewModels.IndexViewModel();
        public UserControl GetControl() => new Views.IndexControl();

        public UserControl GetControlView() => new Views.IndexControl();
        public object GetControlViewModel() => new ViewModels.IndexViewModel();
        public string Title => "Titulo";

        public Func<UserControl> FuncControlView(object param) => null;
        public Func<object> FuncViewModel() => () => null;
    }
}
