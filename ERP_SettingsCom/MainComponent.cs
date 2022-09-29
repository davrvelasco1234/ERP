using System.ComponentModel.Composition;
using ERP_Core.Components;
using ERP_MVVM.Helpers;

namespace ERP_SettingsCom
{
    [Export(typeof(IComponentERP))]
    public class MainComponent : ComponentERP
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.SettingsViewModel, Views.SettingsControl>();
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
            return new ViewModels.SettingsViewModel();
        }


    }
}
