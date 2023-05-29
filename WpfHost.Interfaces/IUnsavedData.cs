using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHost.Interfaces
{
    /// <summary>
    /// Interface for plugins that may have unsaved data
    /// </summary>
    public interface IUnsavedData
    {
        /// <summary>
        /// Get list of currently unsaved data items
        /// </summary>
        /// <returns>Array of unsaved data item names</returns>
        string[] GetNamesOfUnsavedItems();
    }
}
