using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ERP_Components
{
    public interface IComponentView
    {
        
    }

    public interface IComponentView2
    {
        Func<UserControl> FuncComponentview { get; set; }
        Func<object> FuncComponentViewModel { get; set; }
        string Title { get; set; }
    }


    

}

