
namespace ERP_Entorno.Data
{
    public class Querys
    {
        public static string Select_FechaHoy => "select fec_fecha from fechas where fec_clave = 'FECHA000'";
        public static string Select_Fecha24 => "select fec_fecha from fechas where fec_clave = 'FECHA024'";
        public static string Select_Fecha48 => "select fec_fecha from fechas where fec_clave = 'FECHA048'";
        public static string Select_Fecha72 => "select fec_fecha from fechas where fec_clave = 'FECHA072'";
        public static string Select_Fecha96 => "select fec_fecha from fechas where fec_clave = 'FECHA096'";
        public static string Select_FechaAntier => "select fec_fecha from fechas where fec_clave = 'FECHA2AY'";
        public static string Select_FechaAyer => "select fec_fecha from fechas where fec_clave = 'FECHAAYE'";
        public static string Select_FechaAnioAnt => "select fec_fecha from fechas where fec_clave = 'FECIANIO'";
        public static string Select_FechaMesAntDos => "select fec_fecha from fechas where fec_clave = 'FECIE2ME'";
        public static string Select_FechaMesAntUno => "select fec_fecha from fechas where fec_clave = 'FECIEMAN'";
    }
}


