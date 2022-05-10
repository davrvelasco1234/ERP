using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_AppDesktop.Data
{
    internal class Scripts
    {
        protected static string Select_Prodcuto_Script => "SELECT IdProducto, Descripcion, Precio, FechaAlta FROM Products where IdProducto = @IdProducto";

        protected static string Select_Index_Script => "SELECT ime_IdMenu, ime_IdMenuPabre, ime_Nombre, ime_Descripcion, ime_Posicion, ime_Imagen, ime_IdComponent FROM Index_Menu";

    }
}
