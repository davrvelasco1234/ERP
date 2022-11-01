
namespace ERP_Entorno.Data
{
    public class Script
    {
        //FECHAS
        public static string Select_FechaHoy =>         "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECHA000'";
        public static string Select_Fecha24 =>          "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECHA024'";
        public static string Select_Fecha48 =>          "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECHA048'";
        public static string Select_Fecha72 =>          "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECHA072'";
        public static string Select_Fecha96 =>          "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECHA096'";
        public static string Select_FechaAntier =>      "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECHA2AY'";
        public static string Select_FechaAyer =>        "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECHAAYE'";
        public static string Select_FechaAnioAnt =>     "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECIANIO'";
        public static string Select_FechaMesAntDos =>   "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECIE2ME'";
        public static string Select_FechaMesAntUno =>   "SELECT fec_clave AS Clave, fec_fecha AS Descripcion, '' AS Opcion FROM fechas WHERE fec_clave = 'FECIEMAN'";


        //SERVIDOR
        public static string Select_ServidorProd => "SELECT 'SERVIDOR_PRODUCCION' AS Clave, substring(tab_desc3,3,27) AS Descripcion, '' AS Opion FROM tab_gral WHERE tab_cve='CARTCONF00'";


        //TODOS
        public static string Select_Data =>
            Select_FechaHoy + UNION +
            Select_Fecha24 + UNION +
            Select_Fecha48 + UNION +
            Select_Fecha72 + UNION +
            Select_Fecha96 + UNION +
            Select_FechaAntier + UNION +
            Select_FechaAyer + UNION +
            Select_FechaAnioAnt + UNION +
            Select_FechaMesAntDos + UNION +
            Select_FechaMesAntUno + UNION +
            Select_ServidorProd;


        private static string UNION => " UNION ";
    }
}
