
namespace ERP_Security.Data
{
    internal class Scripts
    {
        public static string sppValidaSeguridad_Script => "DECLARE @pError int " +
                    "DECLARE @pMsgerror varchar(100) " +
                    "EXEC spp_valida_seguridad @usuario=@Usuario, @contrasena=@Contrasena, @pantalla=@Pantalla, @terminal=@Terminal, @origen=@Origen, @error = @pError out, @msgerror = @pMsgerror out " +
                    "SELECT @pError AS Clave, @pMsgerror AS Descripcion " + "";
    }
}

