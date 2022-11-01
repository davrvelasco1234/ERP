using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Common.Interfaces
{
    public interface ILoginRequest
    {
        string User { get; }
        string UserName { get; }
        string Rol { get; }
        bool StatusLog { get; }
    }
}
