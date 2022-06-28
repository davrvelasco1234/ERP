using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMappingExcel.Models
{
    public class AttributesObject
    {

        public string Name { get; set; }
        public Dictionary<string, string> DictionaryAtt = new Dictionary<string, string>();
    }
}
