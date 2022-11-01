using System;

namespace ERP_Common
{
    public class ErpException : Exception
    {
        public ErpException(String mensaje) : base("****ERROR*****      " + mensaje)
        {

        }
    }
}
