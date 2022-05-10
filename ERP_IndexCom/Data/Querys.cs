
using System.Collections.Generic;
using ERP_Entorno;
using ERP_IndexCom.Entity;


namespace ERP_IndexCom.Data
{
    internal class Querys : Scritps
    {
        //public IEnumerable<IndexEntity> Select_Index() => Entorno.ExecQuery.Query<IndexEntity>(Select_Index_Script, null);

        internal static IEnumerable<IndexEntity> Select_Index()
            => new List<IndexEntity>
            {
                new IndexEntity {ime_IdMenu = 1, ime_IdMenuPabre = 0, ime_Posicion = 0, ime_DescripcionCorta = "TI", ime_Descripcion = "SISTEMAS", ime_Imagen = "Home"},     
                new IndexEntity {ime_IdMenu = 2, ime_IdMenuPabre = 1, ime_Posicion = 0, ime_DescripcionCorta = "CMP", ime_Descripcion = "Components", ime_Imagen = "Home"},  
                new IndexEntity {ime_IdMenu = 3, ime_IdMenuPabre = 2, ime_Posicion = 0, ime_DescripcionCorta = "CMP1", ime_Descripcion = "Component 1"},
                new IndexEntity {ime_IdMenu = 4, ime_IdMenuPabre = 2, ime_Posicion = 0, ime_DescripcionCorta = "CMP2", ime_Descripcion = "Component 2"},
            };


        internal static IEnumerable<ComponentEntity> Select_Components()
            => new List<ComponentEntity>
            {
                new ComponentEntity{ idComponent = "ERP_Component_1", Nombre = "Component 1", Descripcion = "componente 1 de pruebas" },
                new ComponentEntity{ idComponent = "ERP_Component_2", Nombre = "Component 2", Descripcion = "componente 2 de pruebas" },
            };

    }
}




