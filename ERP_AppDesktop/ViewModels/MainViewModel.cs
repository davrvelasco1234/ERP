﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using ERP_AppDesktop.Helpers;
using ERP_AppDesktop.Models;
using ERP_Common.Models;
using ERP_Core.Components;
using ERP_MVVM.BaseMVVM;
using ERP_MVVM.Helpers;
using Microsoft.Toolkit.Mvvm.Input;


namespace ERP_AppDesktop.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //admin admin 123 QA 127.0.0.1 1801
        #region Fields
        private readonly object _lock = new object();
        private ComponentManager componentManager;
        public IComponentView SettingsCom { get; set; }
        public IComponentView InitializeCom { get; set; }
        #endregion


        
        #region Properties
        private ObservableCollection<BodyComponent> bodyComponentList = new ObservableCollection<BodyComponent>();
        public ObservableCollection<BodyComponent> BodyComponentList
        {
            get => this.bodyComponentList;
            set => SetProperty(ref this.bodyComponentList, value);
        }
        private BodyComponent bodyComponentSelected;
        public BodyComponent BodyComponentSelected
        {
            get => this.bodyComponentSelected;
            set => SetProperty(ref this.bodyComponentSelected, value);
        }
        //private ObservableCollection<TabControlItem> tabControlList;
        //public ObservableCollection<TabControlItem> TabControlListx
        //{
        //    get => this.tabControlList;
        //    set => SetProperty(ref this.tabControlList, value);
        //}
        private TabControlItem tabControlSelected;
        public TabControlItem TabControlSelected
        {
            get => this.tabControlSelected;
            set => SetProperty(ref this.tabControlSelected, value);
        }


        private IndexGroup indexGroupSelected;
        public IndexGroup IndexGroupSelected
        {
            get => this.indexGroupSelected;
            set => SetProperty(ref this.indexGroupSelected, value);
        }
        private ObservableCollection<IndexGroup> indexGroupList;
        public ObservableCollection<IndexGroup> IndexGroupList
        {
            get => this.indexGroupList; 
            set => SetProperty(ref this.indexGroupList, value);
        }

        private List<HeaderLinks> headerLinksList;
        public List<HeaderLinks> HeaderLinksList
        {
            get => this.headerLinksList;
            set => SetProperty(ref this.headerLinksList, value);
        }

        private IComponentView buttonComponent;
        public IComponentView ButtonComponent
        {
            get => buttonComponent;
            set => SetProperty(ref this.buttonComponent, value);
        }

        private IComponentView indexComponent;
        public IComponentView IndexComponent
        {
            get => indexComponent;
            set => SetProperty(ref this.indexComponent, value);
        }

        //private IComponentView bodyComponent;
        //public IComponentView BodyComponent
        //{
        //    get => bodyComponent;
        //    set => SetProperty(ref this.bodyComponent, value);
        //}

        private BitmapImage logoCompany;
        public BitmapImage LogoCompany
        {
            get => logoCompany;
            set => SetProperty(ref this.logoCompany, value);
        }

        private BitmapImage iconMenuImage;
        public BitmapImage IconMenuImage
        {
            get => iconMenuImage;
            set => SetProperty(ref this.iconMenuImage, value);
        }

        private BitmapImage iconReloadImage;
        public BitmapImage IconReloadImage
        {
            get => iconReloadImage;
            set => SetProperty(ref this.iconReloadImage, value);
        }

        private BitmapImage iconGetInGetOutImage;
        public BitmapImage IconGetInGetOutImage
        {
            get => iconGetInGetOutImage;
            set => SetProperty(ref this.iconGetInGetOutImage, value);
        }
        private string iconGetInGetOutToolTip;
        public string IconGetInGetOutToolTip
        {
            get => iconGetInGetOutToolTip;
            set => SetProperty(ref this.iconGetInGetOutToolTip, value);
        }
        

        private GridLength widthMenu = new GridLength(220);
        public GridLength WidthMenu
        {
            get => widthMenu;
            set => SetProperty(ref this.widthMenu, value);
        }

        private bool gridWindowIsEnabled;
        public bool GridWindowIsEnabled
        {
            get => gridWindowIsEnabled;
            set => SetProperty(ref this.gridWindowIsEnabled, value);
        }
        private BitmapImage imagenLockSource;
        public BitmapImage ImagenLockSource
        {
            get => imagenLockSource;
            set => SetProperty(ref this.imagenLockSource, value);
        }
        private Visibility imagenLockVisibility;
        public Visibility ImagenLockVisibility
        {
            get => imagenLockVisibility;
            set => SetProperty(ref this.imagenLockVisibility, value);
        }
        #endregion


        #region PanelLoading
        private bool panelLoading;
        public bool PanelLoading
        {
            get => panelLoading;
            set => SetProperty(ref this.panelLoading, value);
        }
        private string panelMainMessage;
        public string PanelMainMessage
        {
            get => panelMainMessage;
            set => SetProperty(ref this.panelMainMessage, value);
        }
        private string panelSubMessage;
        public string PanelSubMessage
        {
            get => panelSubMessage;
            set => SetProperty(ref this.panelSubMessage, value);
        }
        #endregion


        #region Commands
        public ICommand LoadedCommand => new RelayCommand(Loaded);
        public ICommand HeaderLinksPropertyCommand => new RelayCommand<HeaderLinks>(HeaderLinksProperty);
        public ICommand InputBindingsWindowERPCommand => new RelayCommand<string>(InputBindingsWindowERPC);
        public ICommand MouseDoubleClickItemTreeViewCommand => new AsyncRelayCommand<IndexGroup>(MouseDoubleClickItemTreeView);
        public ICommand IcomMenuCommand => new RelayCommand(IcomMenu);
        public ICommand IcomReloadCommand => new RelayCommand(IcomReload);
        public ICommand IcomGetInGetOutCommand => new RelayCommand(IcomGetInGetOut);
        public ICommand ListBoxSelectionChangedCommand => new RelayCommand(ListBoxSelectionChanged);
        #endregion

        
        #region Contructors
        public MainViewModel()
        {
            //LINKS
            this.HeaderLinksList = new List<HeaderLinks>
            {
                new HeaderLinks{ DisplayContent = "Settings",       DisplayCommanParam="Settings"},
                new HeaderLinks{ DisplayContent = "Google",         DisplayCommanParam="Google"},
                new HeaderLinks{ DisplayContent = "Calculadora",    DisplayCommanParam="Calculadora"},
            };

            //LOAD COMPONENTS
            this.componentManager = ComponentManager.GetComponents();
            IComponentERP buttomComp = this.componentManager.Modules.Where(W => W.ToString().Split('.')[0] == "ERP_ButtonCom").FirstOrDefault();
            IComponentERP settingsCom = this.componentManager.Modules.Where(W => W.ToString().Split('.')[0] == "ERP_SettingsCom").FirstOrDefault();
            IComponentERP inicializeCom = this.componentManager.Modules.Where(W => W.ToString().Split('.')[0] == "ERP_InicializeCom").FirstOrDefault();

            //INICIALIZA COMPONENS DEFAULT
            if (!(settingsCom is null)) this.SettingsCom = settingsCom.GetComponent();
            if (!(buttomComp is null)) this.ButtonComponent = buttomComp.GetComponent();
            if (!(inicializeCom is null)) this.InitializeCom = inicializeCom.GetComponent();

            //INICIALIZA IMAGEN
            this.LogoCompany = Properties.Resources.construccion.ToBitmapImage();
            this.IconReloadImage = Properties.Resources.Reload.ToBitmapImage();
            this.IconMenuImage = Properties.Resources.Menu.ToBitmapImage();

            //INICIALIZA DATOS DEFAULT
            this.IndexGroupList = new ObservableCollection<IndexGroup>(Helpers.CreateIndex.GetIndexGroup());
            //this.BodyComponent = this.InitializeCom;

            Inicialize();

        }




        #endregion
        #region Loaded
        public void Loaded()
        {
            //VALIDA LOGIN
            InicializaLogIn();
        }
        public void Inicialize()
        {
            this.BodyComponentSelected = new Models.BodyComponent { ComponentView = this.InitializeCom };
        }
        #endregion



        #region Methods
        private void ListBoxSelectionChanged()
        {
            foreach (var item in this.BodyComponentList)
            {
                item.IsVisibilityItemsControl = Visibility.Collapsed;

                if (item.NameSpace == this.BodyComponentSelected.NameSpace)
                {
                    item.IsVisibilityItemsControl = Visibility.Visible;
                }
            }
        }
        

        private async Task MouseDoubleClickItemTreeView(IndexGroup selectedItem)
        {
            if (selectedItem is null) { return; }
            if (!selectedItem.IsComponent) { return; }

            IComponentERP componenSelected = this.componentManager.Modules.Where(W => W.ToString().Split('.')[0] == selectedItem.IdComponent).FirstOrDefault();
            
            if (componenSelected is null) return;
            
            
            IComponentView compview = await GetInstansViewModel(componenSelected);
            
            var existsComponent = this.BodyComponentList.Where(w => w.NameSpace == componenSelected.ToString()).FirstOrDefault();
            
            if (existsComponent is null)
            {
                this.BodyComponentList.Add(new Models.BodyComponent { Name = componenSelected.ComponentInfo.Title, ComponentView = compview, NameSpace = componenSelected.ToString(), IsVisibilityItemsControl = Visibility.Visible });
                this.BodyComponentSelected = this.BodyComponentList.LastOrDefault();
            }
            else
            {
                Inicialize();
                var index = this.BodyComponentList.IndexOf(existsComponent);
                this.BodyComponentList.Remove(existsComponent);
                this.BodyComponentList.Insert(index, new Models.BodyComponent { Name = componenSelected.ComponentInfo.Title, ComponentView = compview, NameSpace = componenSelected.ToString(), IsVisibilityItemsControl = Visibility.Visible });
                this.BodyComponentSelected = this.BodyComponentList.ElementAt(index);
                this.BodyComponentList.RemoveAt(10);
            }
            

            this.CallGarbageCollector();

        }



        private async Task<IComponentView> GetInstansViewModel(IComponentERP component)
        {
            this.PanelLoading = true;
            var resp = await Task.Factory.StartNew(() => component.GetComponent());
            this.PanelLoading = false;

            return resp;
        }

        

        private void HeaderLinksProperty(HeaderLinks link)
        {
            if (link.DisplayCommanParam == "Settings")
            {
                //this.BodyComponentSelected = new Models.BodyComponent { ComponentView = this.SettingsCom, IsVisibilityItemsControl = Visibility.Visible };
                this.BodyComponentList.Add(new Models.BodyComponent { Name = "asd", ComponentView = this.SettingsCom, NameSpace = "asdf", IsVisibilityItemsControl = Visibility.Visible });
                this.BodyComponentSelected = this.BodyComponentList.LastOrDefault();

            }
            else if (link.DisplayCommanParam == "Google")
            {
                System.Diagnostics.Process.Start("https://www.google.com/");
            }
            else if (link.DisplayCommanParam == "Calculadora")
            {
                System.Diagnostics.Process.Start("calc.exe");
            }
            else
            {

            }
        }

        private void InputBindingsWindowERPC(string gesture)
        {
            if (gesture == "CtrlS")
            {
                this.BodyComponentSelected = new Models.BodyComponent { ComponentView = this.SettingsCom };
            }
            else if(gesture == "CtrlI")
            {
                this.BodyComponentSelected = new Models.BodyComponent { ComponentView = this.InitializeCom };
            }
            else if (gesture == "Esc")
            {

            }
        }
        #endregion



        #region ButtonsBar
        //MENU
        private void IcomMenu()
        {
            if (this.WidthMenu.Value < 50)
            {
                this.WidthMenu = new GridLength(220);
            }
            else
            {
                this.WidthMenu = new GridLength(0);
            }
        }


        //RELOAD
        private void IcomReload()
        {

        }


        //GetIn/GetOut
        
        private void IcomGetInGetOut()
        {
            if (this.CheckLogIn)
            {
                ERP_Security.LoginERP.UnLog();
                InicializaLogIn();
            }
            else
            {
                var resp = ERP_Security.LoginERP.Log(null); //ERP_AppDesktop.Helpers.LogIn.Log(null);
                InicializaLogIn();
            }
        }

        private void LockWindow()
        {
            this.GridWindowIsEnabled = false;
            this.ImagenLockSource = Properties.Resources.Lock.ToBitmapImage();
            this.ImagenLockVisibility = Visibility.Visible;
            this.IconGetInGetOutImage = Properties.Resources.GetIn.ToBitmapImage();
            this.IconGetInGetOutToolTip = "Get In " + "CTRL+G";
            this.WidthMenu = new GridLength(0);
        }

        private void UnLockWindow()
        {
            this.GridWindowIsEnabled = true;
            this.ImagenLockSource = null;
            this.ImagenLockVisibility = Visibility.Collapsed;
            this.IconGetInGetOutImage = Properties.Resources.GetOut.ToBitmapImage();
            this.IconGetInGetOutToolTip = "Get Out " + "CTRL+G";
            this.WidthMenu = new GridLength(220);
        }
        
        public void InicializaLogIn()
        {
            if (this.CheckLogIn)
            {
                UnLockWindow();
            }
            else
            {
                LockWindow();
            }
        }
        private bool CheckLogIn => ERP_Security.LoginERP.LoginRequest.StatusLog;
        #endregion

    }
}
