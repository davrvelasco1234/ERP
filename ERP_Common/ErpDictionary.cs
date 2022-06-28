using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ERP_Common
{
    public class ErpDictionary
    {
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public string Opcion { get; set; }
        public ObservableCollection<ErpDictionary> ObservableList { get; set; }
    }
}
