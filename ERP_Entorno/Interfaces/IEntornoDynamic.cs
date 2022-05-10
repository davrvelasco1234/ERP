using System;


namespace ERP_Entorno.Interfaces
{
    public interface IEntornoDynamic
    {
        IExecQuery ExecQuery { get; }
        IExecProperty GetProperty { get; }
        ISqlConnection SqlConnection { get; }
    }
}
