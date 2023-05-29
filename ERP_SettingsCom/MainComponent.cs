
using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using ERP_Components;
using ERP_MVVM.Helpers;

namespace ERP_SettingsCom
{
    [Export(typeof(IComponent))]
    public class MainComponent : IComponent
    {
        static MainComponent()
        {
            DataTemplateManager.RegisterDataTemplate<ViewModels.SettingsViewModel, Views.SettingsControl>();
        }

        public string ComponentName => "ERP_SettingsCom";

        public object ComponentContent => "Settings ERP";

        public string ComponentCode => "ERP_SettingsCom";

        public ComponentInfo ComponentInfo() => new ComponentInfo
        {
            Code = "ERP",
            Name = "ERP_SettingsCom"
        };

        public IComponentView GetComponent() => new ViewModels.SettingsViewModel();
        public UserControl GetControl() => new Views.SettingsControl();

        public UserControl GetControlView() => new Views.SettingsControl();
        public object GetControlViewModel() => new ViewModels.SettingsViewModel();
        public string Title => "Titulo";

        public Func<UserControl> FuncControlView(object param) => null;
        public Func<object> FuncViewModel() => () => null;
    }
}
