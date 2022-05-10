
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ERP_IndexCom.Models
{

    public class IndexGroup
    {
        public int IdMenu { get; set; }
        public int IdMenuPabre { get; set; }
        public string DescripcionCorta { get; set; }
        public string Descripcion { get; set; }
        public int Posicion { get; set; }
        public BitmapImage Image { get; set; }
        public IEnumerable<IndexSubGroup> IndexGroupList { get; set; }
    }

    public class IndexSubGroup : IndexGroup
    {
        public BitmapImage ImageOpen { get; set; }
    }

}
