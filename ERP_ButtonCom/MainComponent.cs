
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using ERP_Components;
using ERP_MVVM.Helpers;

namespace ERP_ButtonCom
{
    [Export(typeof(IComponent))]
    public class MainComponent : IComponent
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.BottomViewModel, Views.BottomControl>();
        }

        public string ComponentName => "Button Component";

        public object ComponentContent => "Datos de pie de pagina para ERP";

        public string ComponentCode => "ERP";

        public ComponentInfo ComponentInfo() => new ComponentInfo
        {
            Code = "123456",
            Name = "ERP_ButtonCom"
        };

        public IComponentView GetComponent() => new ViewModels.BottomViewModel();
        public UserControl GetControl() => new Views.BottomControl();

        public UserControl GetControlView() => new Views.BottomControl();
        public object GetControlViewModel() => new ViewModels.BottomViewModel();
        public string Title => "Titulo";


        public Func<UserControl> FuncControlView(object param) => null;
        public Func<object> FuncViewModel() => () => null;

    }
}


