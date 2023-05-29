

using ERP_Common.Interfaces;

namespace ERP_Security.Models
{

    public class LoginRequest 
    {
        public string User { get; private set; }
        public string UserName { get; private set; }
        public string Rol { get; private set; }
        internal string Password { get; private set; }
        public bool StatusLog { get; private set; } = false;
        


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



