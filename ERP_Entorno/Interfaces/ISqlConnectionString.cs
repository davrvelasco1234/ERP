
namespace ERP_Entorno.Interfaces
{
    public interface ISqlConnection
    {
        string DataSource { get; }
        string InitialCatalog { get; }
        string UserID { get; }
        string Password { get; }
        string ApplicationName { get; }
        string ConnectionString { get; }

    }
}
