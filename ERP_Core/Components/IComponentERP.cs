using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Core.Components
{
    public interface IComponentERP
    {
        ComponentInfo ComponentInfo { get; }


        IComponentView GetInstansComponent();


        IComponentView GetComponent();


        
    }
}
