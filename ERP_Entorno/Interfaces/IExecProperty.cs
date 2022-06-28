
namespace ERP_Entorno.Interfaces
{
    public interface IExecProperty
    {
        string FechaHoy(bool connection = false);
        string Fecha24(bool connection = false);
        string Fecha48(bool connection = false);
        string Fecha72(bool connection = false);
        string Fecha96(bool connection = false);
        string FechaAntier(bool connection = false);
        string FechaAyer(bool connection = false);
        string FechaAnioAnt(bool connection = false);
        string FechaMesAntDos(bool connection = false);
        string FechaMesAntUno(bool connection = false);
    }
}
