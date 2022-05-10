    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ERP_AppDesktop.Models
{
    public class TabControlItem
    {
        public string UserControlName { get; set; }

        public UserControl UserControl { get; set; }
    }


    public static class Extencion
    {
        public static TabControlItem ToTabControlItem(this UserControl userControl) 
            => new TabControlItem { UserControlName = "Nombre item", UserControl = userControl };
    }
}
