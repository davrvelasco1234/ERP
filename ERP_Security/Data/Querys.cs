using ERP_Common;
using System;

namespace ERP_Security.Data
{
    internal class Querys
    {
        public static ErpDictionary sppValidaSeguridad(object param) => 
            ERP_Entorno.Entorno.ExecQuery.QuerySingle<ErpDictionary>(Scripts.sppValidaSeguridad_Script, param);
    }
}
