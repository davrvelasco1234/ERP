
using System.ComponentModel.Composition;
using ERP_Core.Components;
using ERP_MVVM.Helpers;

namespace ERP_Component_2
{
    [Export(typeof(IComponentERP))]
    public class MainComponent : ComponentERP
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.ComponentViewModel, Views.ComponentControl>();
        }


        public override ComponentInfo ComponentInfo => new ComponentInfo
        {
            ComponentName = "Name",
            ComponentContent = "Content",
            ComponentCode = "Code",
            Title = "ERP_Component_2"
        };


        public override IComponentView GetInstansComponent()
        {
            return new ViewModels.ComponentViewModel();
        }

    }
}
