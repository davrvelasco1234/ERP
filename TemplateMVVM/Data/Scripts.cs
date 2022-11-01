
namespace TemplateMVVM.Data
{
    public class Scripts
    {
        public static string Select_MarcaList => "SELECT Mar_IdMarca AS Clave, Mar_Descripcion AS Descripcion FROM Marcas";
        public static string Select_Marca => "SELECT Mar_IdMarca AS Clave, Mar_Descripcion AS Descripcion FROM Marcas WHERE Mar_IdMarca = @Clave";
        public static string Insert_Marca => "INSERT INTO Marcas (Mar_Descripcion) VALUES (@Descripcion)";
        public static string Update_Marca => "UPDATE Marcas SET Mar_Descripcion = @Descripcion FROM Marcas WHERE Mar_IdMarca = @Clave";
        public static string Delete_Marca => "DELETE Marcas WHERE Mar_IdMarca = @Clave";


        public static string Select_CarroceriaList => "SELECT Car_IdCarroceria AS Clave, Car_Descripcion AS Descripcion FROM Carrocerias";
        public static string Select_Carroceria => "SELECT Car_IdCarroceria AS Clave, Car_Descripcion AS Descripcion FROM Carrocerias WHERE Car_IdCarroceria = @Clave";
        public static string Insert_Carroceria => "INSERT INTO Carrocerias (Car_Descripcion) VALUES (@Descripcion)";
        public static string Update_Carroceria => "UPDATE Carrocerias SET Car_Descripcion = @Descripcion FROM Carrocerias WHERE Car_IdCarroceria = @Clave";
        public static string Delete_Carroceria => "DELETE Carrocerias WHERE Car_IdCarroceria = @Clave";


        public static string Select_ModeloList => "SELECT Mod_IdModelo AS Clave, Mod_IdMarca AS Opcion, Mod_Descripcion AS Descripcion FROM Modelos";
        public static string Select_Modelo => "SELECT Mod_IdModelo AS Clave, Mod_IdMarca AS Opcion, Mod_Descripcion AS Descripcion FROM Modelos WHERE Mod_IdModelo = @Clave";
        public static string Insert_Modelo => "INSERT INTO Modelos (Mod_IdMarca, Mod_Descripcion) VALUES (@Opcion, @Descripcion)";
        public static string Update_Modelo => "UPDATE Modelos SET Mod_IdMarca=@Opcion, Mod_Descripcion=@Descripcion FROM Modelos WHERE Mod_IdModelo = @Clave";
        public static string Delete_Modelo => "DELETE Modelos WHERE Mod_IdModelo = @Clave";


        public static string Select_AutoList => "";
        public static string Select_Auto => "";
        public static string Insert_Auto => "INSERT INTO Autos (Aut_IdMarca, Aut_IdModelo, Aut_IdCarroceria, Aut_Anio, Aut_Color, Aut_Precio, Aut_FechaCompra, Aut_Observaciones) " +
                                                       "VALUES (@IdMarca, @IdModelo, @IdCarroceria, @Anio, @Color, @Precio, @FechaCompra, @Observaciones)";
        public static string Update_Auto => "UPDATE Autos SET Aut_IdMarca = @IdMarca, Aut_IdModelo = @IdModelo, " +
                                                             "Aut_Anio = @Anio, Aut_Color = @Color, Aut_Observaciones = @Observaciones, " +
                                                             "Aut_Precio = @Precio, Aut_FechaCompra = @FechaCompra WHERE Aut_IdAuto = @IdAuto";
        public static string Delete_Auto => "DELETE Autos WHERE Aut_IdAuto = @IdAuto";


        public static string Sp_GetAutos => "EXEC SP_GetAutos @IdMarca = '', @IdModelo = '', @IdCarroceria = '', @IdAuto = '', @Anio = '', @PrecioMin = '', @PrecioMax = ''";
    }
}
