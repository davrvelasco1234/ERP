using ERP_Entorno.Data;
using ERP_Entorno.Interfaces;

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


        internal ExecProperty(ISqlConnection sqlConnection)
        {
            this.SqlConnection = sqlConnection;

            _fechaHoy           = GetFechaHoy(this.SqlConnection.ConnectionString);
            _fecha24            = GetFecha24(this.SqlConnection.ConnectionString);
            _fecha48            = GetFecha28(this.SqlConnection.ConnectionString);
            _fecha72            = GetFecha72(this.SqlConnection.ConnectionString);
            _fecha96            = GetFecha96(this.SqlConnection.ConnectionString);
            _fechaAntier        = GetFechaAntier(this.SqlConnection.ConnectionString);
            _fechaAyer          = GetFechaAyer(this.SqlConnection.ConnectionString);
            _fechaAnioAnt       = GetFechaAnioAnt(this.SqlConnection.ConnectionString);
            _fechaMesAntDos     = GetFechaMesAntDos(this.SqlConnection.ConnectionString);
            _fechaMesAntUno     = GetFechaMesAntUno(this.SqlConnection.ConnectionString);
        }                         

        public string FechaHoy(bool connection = false)         => (!connection) ? _fechaHoy       : GetFechaHoy(this.SqlConnection.ConnectionString);
        public string Fecha24(bool connection = false)          => (!connection) ? _fecha24        : GetFecha24(this.SqlConnection.ConnectionString);
        public string Fecha48(bool connection = false)          => (!connection) ? _fecha48        : GetFecha28(this.SqlConnection.ConnectionString);
        public string Fecha72(bool connection = false)          => (!connection) ? _fecha72        : GetFecha72(this.SqlConnection.ConnectionString);
        public string Fecha96(bool connection = false)          => (!connection) ? _fecha96        : GetFecha96(this.SqlConnection.ConnectionString);
        public string FechaAntier(bool connection = false)      => (!connection) ? _fechaAntier    : GetFechaAntier(this.SqlConnection.ConnectionString);
        public string FechaAyer(bool connection = false)        => (!connection) ? _fechaAyer      : GetFechaAyer(this.SqlConnection.ConnectionString);
        public string FechaAnioAnt(bool connection = false)     => (!connection) ? _fechaAnioAnt   : GetFechaAnioAnt(this.SqlConnection.ConnectionString);
        public string FechaMesAntDos(bool connection = false)   => (!connection) ? _fechaMesAntDos : GetFechaMesAntDos(this.SqlConnection.ConnectionString);
        public string FechaMesAntUno(bool connection = false)   => (!connection) ? _fechaMesAntUno : GetFechaMesAntUno(this.SqlConnection.ConnectionString);


        private string GetFechaHoy(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_FechaHoy, null, this.SqlConnection.ConnectionString);
        private string GetFecha24(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_Fecha24, null, this.SqlConnection.ConnectionString);
        private string GetFecha28(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_Fecha48, null, this.SqlConnection.ConnectionString);
        private string GetFecha72(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_Fecha72, null, this.SqlConnection.ConnectionString);
        private string GetFecha96(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_Fecha96, null, this.SqlConnection.ConnectionString);
        private string GetFechaAntier(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_FechaAntier, null, this.SqlConnection.ConnectionString);
        private string GetFechaAyer(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_FechaAyer, null, this.SqlConnection.ConnectionString);
        private string GetFechaAnioAnt(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_FechaAnioAnt, null, this.SqlConnection.ConnectionString);
        private string GetFechaMesAntDos(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_FechaMesAntDos, null, this.SqlConnection.ConnectionString);
        private string GetFechaMesAntUno(string connectionString) => ExecQueryBase.ExecuteScalar<string>(Querys.Select_FechaMesAntUno, null, this.SqlConnection.ConnectionString);


    }
}
