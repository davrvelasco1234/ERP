
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ERP_AppDesktop.Helpers;
using ERP_AppDesktop.Models;
using ERP_Common.Models;
using ERP_Components;
using ERP_MVVM.BaseMVVM;
using ERP_MVVM.Helpers;
using ERP_Security;
using Microsoft.Toolkit.Mvvm.Input;


namespace ERP_AppDesktop.ViewModels
{
    public class MainViewModel : BaseViewModel, IComponentView
    {
        //admin admin 123 QA 127.0.0.1 1801
        #region Fields
        private ComponentManager componentManager;
        public IComponentView SettingsCom { get; set; }
        public IComponentView InicializeCom { get; set; }
        public UserControl InicializeControl { get; set; }
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

        private IComponentView bodyComponent;
        public IComponentView BodyComponent
        {
            get => bodyComponent;
            set => SetProperty(ref this.bodyComponent, value);
        }

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


        //public List<TabControlItem> TabControlList { get; set; }


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
            IComponent buttomComp = this.componentManager.Modules.Where(W => W.ToString().Split('.')[0] == "ERP_ButtonCom").FirstOrDefault();
            IComponent settingsCom = this.componentManager.Modules.Where(W => W.ToString().Split('.')[0] == "ERP_SettingsCom").FirstOrDefault();
            IComponent inicializeCom = this.componentManager.Modules.Where(W => W.ToString().Split('.')[0] == "ERP_InicializeCom").FirstOrDefault();
            

            //INICIALIZA COMPONENS DEFAULT
            if (!(buttomComp is null)) this.ButtonComponent = buttomComp.GetComponent();
            if (!(settingsCom is null)) this.SettingsCom = settingsCom.GetComponent();
            if (!(inicializeCom is null)) this.InicializeCom = inicializeCom.GetComponent();
            if (!(inicializeCom is null)) this.InicializeControl = inicializeCom.GetControl();

            //INICIALIZA IMAGEN
            this.LogoCompany = Properties.Resources.construccion.ToBitmapImage();
            this.IconMenuImage = Properties.Resources.Menu.ToBitmapImage();
            this.IconReloadImage = Properties.Resources.Reload.ToBitmapImage();

            //INICIALIZA DATOS DEFAULT
            this.IndexGroupList = new ObservableCollection<IndexGroup>(Helpers.CreateIndex.GetIndexGroup());
            this.BodyComponent = this.InicializeCom;

            this.BodyComponentSelected = new Models.BodyComponent { ComponentView = this.BodyComponent};

            /*
            this.TabControlList = new ObservableCollection<TabItem>();
            var tabItem = new TabItem { Header = "Tab A", };
            var tabItem1 = new TabItem { Header = "Tab B", };
            var tabItem2 = new TabItem { Header = "Tab C", };
            this.TabControlList.Insert(0, tabItem);
            this.TabControlList.Insert(1, tabItem1);
            this.TabControlList.Insert(2, tabItem2);
            */

        }
        #endregion

        /*
        private ObservableCollection<TabItem> tabControlList;
        public ObservableCollection<TabItem> TabControlList
        {
            get => this.tabControlList;
            set => SetProperty(ref this.tabControlList, value);
        }
        */


        #region Loaded
        public void Loaded()
        {
            //VALIDA LOGIN
            InicializaLogIn();


            /*
            object viewModel = null;
            this.PanelLoading = true;                                   //inicia la animacion   
            Task task1 = Task.Run(() =>
            {

                viewModel = new UserViewModel();

                this.PanelLoading = false;                              //detiene la animacion  
            });

            task1.Wait();

            this.TabControlList = new ObservableCollection<TabItem>();
            var tabItem = new TabItem { Content = new UserControl1() { DataContext = viewModel }, Header = "Tab A", };
            this.TabControlList.Insert(0, tabItem);

            this.BodyComponentSelected = this.BodyComponentList.FirstOrDefault();
            */

        }

        public void Inicialize()
        {

            
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

            this.BodyComponent = null;

            IComponent componenSelected = this.componentManager.Modules.Where(W => W.ToString().Split('.')[0] == selectedItem.IdComponent).FirstOrDefault();

            if (componenSelected is null) return;


            

            this.BodyComponent = await GetInstansViewModel(componenSelected);

            var resp = this.BodyComponentList.Where(w => w.NameSpace == componenSelected.ToString()).FirstOrDefault();

            if (this.BodyComponentList.Where(w => w.NameSpace == componenSelected.ToString()).FirstOrDefault() is null)
            {
                this.BodyComponentList.Add(new Models.BodyComponent { Name = componenSelected.Title, ComponentView = this.BodyComponent, NameSpace = componenSelected.ToString(), IsVisibilityItemsControl = Visibility.Visible });
                this.BodyComponentSelected = this.BodyComponentList.LastOrDefault();
            }
            else
            {
                var item = this.BodyComponentList.Where(w => w.NameSpace == componenSelected.ToString()).First();
                var index = this.BodyComponentList.IndexOf(item);
                this.BodyComponentList.RemoveAt(index);
                this.BodyComponentList.Insert(index, new Models.BodyComponent { Name = componenSelected.Title, ComponentView = this.BodyComponent, NameSpace = componenSelected.ToString(), IsVisibilityItemsControl = Visibility.Visible });
                this.BodyComponentSelected = this.BodyComponentList.ElementAt(index);
            }


            GC.Collect();

            ListBoxSelectionChanged();
        }

        private async Task<IComponentView> GetInstansViewModel(IComponent component)
        {
            this.PanelLoading = true;
            var resp = await Task.Factory.StartNew(() => component.GetComponent());
            this.PanelLoading = false;

            return resp;
        }
        //private async Task<object> GetInstansViewModel(Func<object> viewModelParam) => await Task.Factory.StartNew(() => viewModelParam() );






        private void HeaderLinksProperty(HeaderLinks link)
        {
            if (link.DisplayCommanParam == "Settings")
            {
                this.BodyComponent = this.SettingsCom;
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
                this.BodyComponent = this.SettingsCom;
            }
            else if(gesture == "CtrlI")
            {
                this.BodyComponent = this.InicializeCom;
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
                var resp = ERP_AppDesktop.Helpers.LogIn.Log(null);
                InicializaLogIn();
            }
        }

        private void LockWindow()
        {
            this.GridWindowIsEnabled = false;
            this.ImagenLockSource = Properties.Resources.Lock.ToBitmapImage();
            this.ImagenLockVisibility = Visibility.Visible;
            this.IconGetInGetOutImage = Properties.Resources.GetIn.ToBitmapImage();
            this.IconGetInGetOutToolTip = "Get In " + "&#x0a; CTRL+G";
            this.WidthMenu = new GridLength(0);
        }

        private void UnLockWindow()
        {
            this.GridWindowIsEnabled = true;
            this.ImagenLockSource = null;
            this.ImagenLockVisibility = Visibility.Collapsed;
            this.IconGetInGetOutImage = Properties.Resources.GetOut.ToBitmapImage();
            this.IconGetInGetOutToolTip = "Get Out " + " &#x0a; CTRL+G";
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
