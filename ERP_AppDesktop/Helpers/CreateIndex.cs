using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using ERP_AppDesktop.Entity;
using ERP_AppDesktop.Models;
using ERP_Images.Helpers;
using ERP_MVVM.Helpers;

namespace ERP_AppDesktop.Helpers
{
    public static class CreateIndex
    {
        public static IEnumerable<IndexGroup> GetIndexGroup()
        {
            IEnumerable<IndexEntity> IndexList = Data.Querys.Select_Index();
            IEnumerable<IndexGroup> query = (from item in IndexList
                                             where item.ime_IdMenuPabre == 0
                                             select GetIndexGroup(item,
                                                                GetImage(item.ime_Imagen),
                                                                GetImage(item.ime_Imagen),
                                                                false,
                                                                true,
                                                                GetIndexGroup(item.ime_IdMenu, IndexList))).OrderBy(O => O.Posicion);
            return query;
        }


        private static IEnumerable<IndexGroup> GetIndexGroup(int idMenu, IEnumerable<IndexEntity> IndexList)
            => (from item in IndexList
                let tieneHijos = IndexList.Where(o => o.ime_IdMenuPabre == item.ime_IdMenu).Any()
                where item.ime_IdMenuPabre == idMenu
                select GetIndexGroup(item,
                                    tieneHijos ? Properties.Resources.Folder.ToBitmapImage() : Properties.Resources.File.ToBitmapImage(),
                                    tieneHijos ? Properties.Resources.Opened_folder.ToBitmapImage() : Properties.Resources.File.ToBitmapImage(),
                                    tieneHijos ? false : true,
                                    false,
                                    tieneHijos ? GetIndexGroup(item.ime_IdMenu, IndexList) : null)).OrderBy(O => O.Posicion);


        private static IndexGroup GetIndexGroup(IndexEntity item, BitmapImage image, BitmapImage imageOpen, bool isComponent, bool isMenuPadre, IEnumerable<IndexGroup> group)
            => new IndexGroup(item.ime_IdMenu, item.ime_IdMenuPabre, item.ime_IdComponent, item.ime_Nombre, 
                                item.ime_Descripcion, item.ime_Posicion, 
                                image, imageOpen, group, isComponent, isMenuPadre);


        private static BitmapImage GetImage(string nameImage)
        {
            try
            {
                object obj = Properties.Resources.ResourceManager.GetObject(nameImage);
                var img = ((System.Drawing.Bitmap)(obj));
                return img.ToBitmapImage();
            }
            catch (Exception)
            {
                return Properties.Resources.Home.ToBitmapImage();
            }
        }
    }
}
