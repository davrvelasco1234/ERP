
using System.Collections.ObjectModel;

namespace LibMappingExcel.Models
{
    public class LoadExcelResp<T>
    {
        public ObservableCollection<T> ListObjectT { get; set; }
        public ObservableCollection<T> ListObjectTError { get; set; }
    }

}
