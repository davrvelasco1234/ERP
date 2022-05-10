
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;


namespace ERP_AppDesktop.Models
{
    public class IndexGroup
    {
        public int IdMenu { get; set; }
        public int IdMenuPabre { get; set; }
        public string IdComponent { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Posicion { get; set; }

        public BitmapImage Image { get; set; }
        public BitmapImage ImageOpen { get; set; }

        public IEnumerable<IndexGroup> IndexGroupList { get; set; }

        public bool IsComponent { get; set; }
        public bool IsMenuPadre { get; set; }

        //public bool IsExpanded { get; set; }
        //public bool IsSelected { get; set; }
        public int Width => IsMenuPadre ? 40 : 20;
        public int Height => IsMenuPadre ? 40 : 20;
        public Visibility VisibilityDescMenuPadre => IsMenuPadre ? Visibility.Visible : Visibility.Collapsed;
        public Visibility VisibilityDescSubMenu => IsMenuPadre ? Visibility.Collapsed : Visibility.Visible;


        public IndexGroup()
        {

        }

        public IndexGroup(int idMenu, int idMenuPadre, string idComponent, string nombre, string descripcion, int posicion,
                          BitmapImage image, BitmapImage imageOpen, IEnumerable<IndexGroup> indexGroupList,
                          bool isComponent, bool isMenuPadre)
        {
            this.IdMenu = idMenu;
            this.IdMenuPabre = idMenuPadre;
            this.IdComponent = idComponent;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Posicion = posicion;
            this.Image = image;
            this.ImageOpen = imageOpen;
            this.IndexGroupList = indexGroupList;
            this.IsComponent = isComponent;
            this.IsMenuPadre = isMenuPadre;


        }

    }

}





