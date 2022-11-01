using ERP_Common;
using ERP_Entorno.Data;
using ERP_Entorno.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ERP_Entorno.Controllers
{
    internal class ExecProperty  : IExecProperty
    {
        private ISqlConnection SqlConnection;
        
        private string _fechaHoy { get; }
        private string _fecha24 { get; }
        private string _fecha48 { get; }
        private string _fecha72 { get; }
        private string _fecha96 { get; }
        private string _fechaAntier { get; }
        private string _fechaAyer { get; }
        private string _fechaAnioAnt { get; }
        private string _fechaMesAntDos { get; }
        private string _fechaMesAntUno { get; }

        private string _servidorProduccion { get; }

        private IEnumerable<ErpDictionary> _datos { get; }

        internal ExecProperty(ISqlConnection sqlConnection)
        {
            this.SqlConnection = sqlConnection;

            _datos = Querys.Select_Data(sqlConnection);

            _fechaHoy           = FechaHoy(true);
            _fecha24            = Fecha24(true);
            _fecha48            = Fecha48(true);
            _fecha72            = Fecha72(true);
            _fecha96            = Fecha96(true);
            _fechaAntier        = FechaAntier(true);
            _fechaAyer          = FechaAyer(true);
            _fechaAnioAnt       = FechaAnioAnt(true);
            _fechaMesAntDos     = FechaMesAntDos(true);
            _fechaMesAntUno     = FechaMesAntUno(true);

            _servidorProduccion = ServidorProduccion(true);
        }



        private string GetDato(string clave) => _datos.Where(W => W.Clave == clave).FirstOrDefault().Descripcion;


        //FECAS
        public string FechaHoy(bool connection = false)             => (!connection) ? _fechaHoy        : Querys.Select_FechaHoy(this.SqlConnection);
        public string Fecha24(bool connection = false)              => (!connection) ? _fecha24         : Querys.Select_Fecha24(this.SqlConnection);
        public string Fecha48(bool connection = false)              => (!connection) ? _fecha48         : Querys.Select_Fecha48(this.SqlConnection);
        public string Fecha72(bool connection = false)              => (!connection) ? _fecha72         : Querys.Select_Fecha72(this.SqlConnection);
        public string Fecha96(bool connection = false)              => (!connection) ? _fecha96         : Querys.Select_Fecha96(this.SqlConnection);
        public string FechaAntier(bool connection = false)          => (!connection) ? _fechaAntier     : Querys.Select_FechaAntier(this.SqlConnection);    
        public string FechaAyer(bool connection = false)            => (!connection) ? _fechaAyer       : Querys.Select_FechaAyer(this.SqlConnection);      
        public string FechaAnioAnt(bool connection = false)         => (!connection) ? _fechaAnioAnt    : Querys.Select_FechaAnioAnt(this.SqlConnection);   
        public string FechaMesAntDos(bool connection = false)       => (!connection) ? _fechaMesAntDos  : Querys.Select_FechaMesAntDos(this.SqlConnection); 
        public string FechaMesAntUno(bool connection = false)       => (!connection) ? _fechaMesAntUno  : Querys.Select_FechaMesAntUno(this.SqlConnection); 


        //SERVIDOR
        public string ServidorProduccion(bool connection = false) => (!connection) ? _servidorProduccion : Querys.Select_ServidorProd(this.SqlConnection);
        
        
        //APP
        public string AssemblyName => Assembly.GetEntryAssembly().GetName().Name;
        //public string UsuarioLog(bool connection = false) => "";
        
        
    }
}

