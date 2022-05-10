using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ERP_Components;
using ERP_IndexCom.Entity;
using ERP_IndexCom.Models;
using ERP_MVVM.BaseMVVM;
using ERP_MVVM.Helpers;
using Microsoft.Toolkit.Mvvm.Input;


namespace ERP_IndexCom.ViewModels
{
    public class IndexViewModel : BaseViewModel, IComponentView
    {

        #region Fields
        private string Att;
        #endregion


        #region Properties
        private ObservableCollection<IndexGroup> indexGroupList;
        public ObservableCollection<IndexGroup> IndexGroupList
        {
            get => this.indexGroupList;
            set => SetProperty(ref this.indexGroupList, value);
        }

        private object objectSelected;
        public object ObjectSelected
        {
            get => this.objectSelected;
            set => SetProperty(ref this.objectSelected, value);
        }
        #endregion


        #region Commands
        public ICommand LoadedCommand => new RelayCommand(Loaded);
        #endregion


        #region Services

        #endregion

        #region Contructors
        public IndexViewModel()
        {

        }
        #endregion


        #region Loaded
        public void Loaded()
        {
            this.IndexGroupList = new ObservableCollection<IndexGroup>(GetIndexGroup());
        }
        #endregion


        #region Methods
        public static IEnumerable<IndexGroup> GetIndexGroup()
        {
            IEnumerable<IndexEntity> IndexList = Data.Querys.Select_Index();
            IEnumerable<IndexGroup> query = (from item in IndexList
                                      where item.ime_IdMenuPabre == 0
                                      select new IndexGroup
                                      {
                                          IdMenu = item.ime_IdMenu,
                                          IdMenuPabre = item.ime_IdMenuPabre,
                                          DescripcionCorta = item.ime_DescripcionCorta,
                                          Descripcion = item.ime_Descripcion,
                                          Posicion = item.ime_Posicion,
                                          Image = GetImage(item.ime_Imagen),
                                          IndexGroupList = GetIndexGroup(item.ime_IdMenu, IndexList)
                                      }).OrderBy(O => O.Posicion);
            return query;
        }


        private static IEnumerable<IndexSubGroup> GetIndexGroup(int idMenu, IEnumerable<IndexEntity> IndexList)
            => (from item in IndexList
                let tieneHijos = IndexList.Where(o => o.ime_IdMenuPabre == item.ime_IdMenu).Any()
                where item.ime_IdMenuPabre == idMenu
                select new IndexSubGroup
                {
                    IdMenu = item.ime_IdMenu,
                    IdMenuPabre = item.ime_IdMenuPabre,
                    DescripcionCorta = item.ime_DescripcionCorta,
                    Descripcion = item.ime_Descripcion,
                    Posicion = item.ime_Posicion,
                    Image = tieneHijos ? Properties.Resources.Folder.ToBitmapImage() : Properties.Resources.File.ToBitmapImage(),
                    ImageOpen = tieneHijos ? Properties.Resources.Opened_folder.ToBitmapImage() : Properties.Resources.File.ToBitmapImage(),
                    IndexGroupList = tieneHijos ? GetIndexGroup(item.ime_IdMenu, IndexList) : null
                }).OrderBy(O => O.Posicion);


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


        #endregion

    }
}
