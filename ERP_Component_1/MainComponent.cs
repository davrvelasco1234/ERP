
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;

using ERP_Components;
using ERP_MVVM.Helpers;

namespace ERP_Component_1
{
    [Export(typeof(IComponent))]
    public class MainComponent : IComponent
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.ComponentViewModel, Views.ComponentControl>();
        }

        public string ComponentName => "Primer Componente MEF";

        public object ComponentContent => "Pruebas de un componente";

        public string ComponentCode => "codigo de pruebas";


        public ComponentInfo ComponentInfo() => new ComponentInfo
        {
            Code = "code",
            Name = "name"
        };


        public IComponentView GetComponent() => new ViewModels.ComponentViewModel();
        public UserControl GetControl() => new Views.ComponentControl();


        public UserControl GetControlView() => new Views.ComponentControl();
        public object GetControlViewModel() => new ViewModels.ComponentViewModel();

        

        public string Title => "Titulo";

        


        public Func<UserControl> FuncControlView(object dataContext) => () => new Views.ComponentControl() { DataContext = dataContext };
        public Func<object> FuncViewModel() => () => new ViewModels.ComponentViewModel();

        

        //public Func<UserControl> FuncControlView(object asdasd)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
