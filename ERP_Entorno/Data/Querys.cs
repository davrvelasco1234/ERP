
using ERP_Common;
using ERP_Entorno.Controllers;
using ERP_Entorno.Interfaces;
using System.Collections.Generic;

namespace ERP_Entorno.Data
{
    public class Querys
    {
        /*
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
        */

        //TODOS LOS DATOS
        public static IEnumerable<ErpDictionary> Select_Data(ISqlConnection sqlConnection) => ExecQueryBase.Query<ErpDictionary>(Script.Select_Data, null, sqlConnection.ConnectionString);

        //FECHAS
        public static string Select_FechaHoy(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_FechaHoy, null, sqlConnection.ConnectionString)).Descripcion;
        public static string Select_Fecha24(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_Fecha24, null, sqlConnection.ConnectionString)).Descripcion;
        public static string Select_Fecha48(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_Fecha48, null, sqlConnection.ConnectionString)).Descripcion;
        public static string Select_Fecha72(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_Fecha72, null, sqlConnection.ConnectionString)).Descripcion;
        public static string Select_Fecha96(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_Fecha96, null, sqlConnection.ConnectionString)).Descripcion;
        public static string Select_FechaAntier(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_FechaAntier, null, sqlConnection.ConnectionString)).Descripcion;
        public static string Select_FechaAyer(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_FechaAyer, null, sqlConnection.ConnectionString)).Descripcion;
        public static string Select_FechaAnioAnt(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_FechaAnioAnt, null, sqlConnection.ConnectionString)).Descripcion;
        public static string Select_FechaMesAntDos(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_FechaMesAntDos, null, sqlConnection.ConnectionString)).Descripcion;
        public static string Select_FechaMesAntUno(ISqlConnection sqlConnection) => (ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_FechaMesAntUno, null, sqlConnection.ConnectionString)).Descripcion;

        //SERVIDOR
        public static string Select_ServidorProd(ISqlConnection sqlConnection) => ExecQueryBase.QuerySingleOrDefault<ErpDictionary>(Script.Select_ServidorProd, null, sqlConnection.ConnectionString).Descripcion;

    }
}


