using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Security.Interfaces
{
    public interface ILoginRequest
    {
        string User { get; }
        string UserName { get; }
        string Rol { get; }
        bool StatusLog { get; } 
    }
}
