
using System.Collections.Generic;
using ERP_AppDesktop.Entity;
using ERP_Entorno;

namespace ERP_AppDesktop.Data
{

    internal class Querys : Scripts
    {
        //public static IEnumerable<IndexEntity> Select_Index() => Entorno.ExecQuery.Query<IndexEntity>(Select_Index_Script, null);
        public static string Select_Prodcuto => "SELECT IdProducto, Descripcion, Precio, FechaAlta FROM Products where IdProducto = @IdProducto";

        public static IEnumerable<IndexEntity> Select_Index()
            => new List<IndexEntity>
            {
                new IndexEntity {ime_IdMenu = 1, ime_IdMenuPabre = 0, ime_Posicion = 0, ime_Nombre = "SISTEMAS",    ime_Imagen = "Home",  ime_IdComponent = "",                 ime_Descripcion = "TI"},
                new IndexEntity {ime_IdMenu = 2, ime_IdMenuPabre = 1, ime_Posicion = 0, ime_Nombre = "Components",  ime_Imagen = "",      ime_IdComponent = "",                 ime_Descripcion = "CMP"},
                new IndexEntity {ime_IdMenu = 3, ime_IdMenuPabre = 2, ime_Posicion = 0, ime_Nombre = "Component 1", ime_Imagen = "",      ime_IdComponent = "ERP_Component_1",  ime_Descripcion = "CMP1"},
                new IndexEntity {ime_IdMenu = 4, ime_IdMenuPabre = 2, ime_Posicion = 0, ime_Nombre = "Component 2", ime_Imagen = "",      ime_IdComponent = "ERP_Component_2",  ime_Descripcion = "CMP2"},
            };


        public static IEnumerable<ComponentEntity> Select_Components()
            => new List<ComponentEntity>
            {
                new ComponentEntity{ idComponent = "ERP_Component_1", Nombre = "Component 1", Descripcion = "componente 1 de pruebas", idMenu = 2},
                new ComponentEntity{ idComponent = "ERP_Component_2", Nombre = "Component 2", Descripcion = "componente 2 de pruebas", idMenu = 3 },
            };

    }

}


