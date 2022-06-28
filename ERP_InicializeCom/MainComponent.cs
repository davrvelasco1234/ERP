
using System.ComponentModel.Composition;
using ERP_Core.Components;
using ERP_MVVM.Helpers;

namespace ERP_InicializeCom
{
    [Export(typeof(IComponentERP))]
    public class MainComponent : ComponentERP
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.InicializeViewModel, Views.InicializeControl>();
        }


        public override ComponentInfo ComponentInfo => new ComponentInfo
        {
            ComponentName = "Name",
            ComponentContent = "Content",
            ComponentCode = "Code",
            Title = "Title"
        };


        public override IComponentView GetInstansComponent()
        {
            return new ViewModels.InicializeViewModel();
        }


    }
}
