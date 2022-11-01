

using ERP_Common.Interfaces;

namespace ERP_Security.Models
{

    public class LoginRequest : ILoginRequest
    {
        
        public string User { get; }
        public string UserName { get; }
        public string Rol { get; }
        internal string Password { get; }
        public bool StatusLog { get; } = false;

        

        internal LoginRequest(string user,  string userName, string rol, string password, bool statusLog)
        {
            User = user;
            UserName = userName;
            Rol = rol;
            Password = password;
            StatusLog = statusLog;
        }

        
    }
}



