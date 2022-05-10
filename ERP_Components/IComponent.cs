
using System;
using System.Windows.Controls;

namespace ERP_Components
{
    public interface IComponent
    {
        string ComponentName { get; }
        object ComponentContent { get; }
        string ComponentCode { get; }

        IComponentView GetComponent();
        ComponentInfo ComponentInfo();
        UserControl GetControl();

        UserControl GetControlView();
        object GetControlViewModel();

        string Title { get; }


        Func<UserControl> FuncControlView(object asdasd);
        Func<object> FuncViewModel();
    }    
}



