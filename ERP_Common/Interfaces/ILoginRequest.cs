using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Common.Interfaces
{
    public interface ILoginRequest
    {
        string User { get; set; }
        string UserName { get; set; }
        string Rol { get; set; }
        string Password { get; set; }
        bool StatusLog { get; set; }
    }
}
