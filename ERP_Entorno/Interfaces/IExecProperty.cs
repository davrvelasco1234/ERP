
namespace ERP_Entorno.Interfaces
{
    public interface IExecProperty
    {
        string FechaHoy(bool connection);
        string Fecha24(bool connection);
        string Fecha48(bool connection);
        string Fecha72(bool connection);
        string Fecha96(bool connection);
        string FechaAntier(bool connection);
        string FechaAyer(bool connection);
        string FechaAnioAnt(bool connection);
        string FechaMesAntDos(bool connection);
        string FechaMesAntUno(bool connection);
    }
}
