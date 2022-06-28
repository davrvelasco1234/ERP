
using System.ComponentModel.Composition;
using ERP_MVVM.Helpers;
using ERP_Core.Components;
using ERP_Component_1.Messaging;

namespace ERP_Component_1
{
    [Export(typeof(IComponentERP))]
    public class MainComponent : ComponentERP
    {
        public static Messenger Messenger { get; }


        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.ComponentViewModel, Views.ComponentControl>();
            DataTemplateManager.RegisterDataTemplate<ViewModels.Dialog.AutoMtoViewModel, Views.Dialog.AutoMtoControl>();
            Messenger = new Messenger();
        }


        public override ComponentInfo ComponentInfo => new ComponentInfo
        {
            ComponentName = "Name",
            ComponentContent = "Content",
            ComponentCode = "Code",
            Title = "ERP_Component_1"
        };


        public override IComponentView GetInstansComponent()
        {
            return new ViewModels.ComponentViewModel();
        }



    }
}
