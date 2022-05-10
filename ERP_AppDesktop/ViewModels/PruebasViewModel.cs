
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ERP_MVVM.BaseMVVM;
using Microsoft.Toolkit.Mvvm.Input;
using ERP_AppDesktop.Helpers;
using ERP_Components;
using ERP_AppDesktop.Models;
using Dapper;
using ERP_AppDesktop.Data;
using ERP_Entorno.Interfaces;

namespace ERP_AppDesktop.ViewModels
{
    public class PruebasViewModel : BaseViewModel
    {
        private string respSaludo;
        public string RespSaludo
        {
            get => respSaludo;
            set => SetProperty(ref this.respSaludo, value);
        }

        private IComponentView myComponent;
        public IComponentView MyComponent
        {
            get => myComponent;
            set => SetProperty(ref this.myComponent, value);
        }




        public ICommand LoadedCommand => new RelayCommand(Loaded);
        //public ICommand MethodSaludoCommand => new AsyncRelayCommand(LoadedAsync);
        //public ICommand MethodSaludoCommand => new RelayCommand(MethodSaludo);


        public PruebasViewModel(string sadfas)
        {

        }

        public PruebasViewModel()
        {
            
        }



        public void Loaded()
        {
            ComponentManager manager = new ComponentManager(@"../../../Components");
            foreach (IComponent item in manager.Modules)
            {
                this.MyComponent = item.GetComponent();
            }


            //var configFileReader = new CustomConfigurationFileReader("c:\\myconfig.config");

            // Get the custom Configuration Section using its name
            //var sageConfig = (SageCRMConfig)ConfigurationManager.GetSection("sageCRM");

            // Loop through each instance in the SageCRMInstanceCollection
            //foreach (SageCRMInstanceElement instance in sageConfig.SageCRMInstances)
            //{
            //    // Write the instance information to the Console
            //    Console.WriteLine("{0} {1} {2}",
            //        instance.Name,
            //        instance.Server,
            //        instance.InstallationName);
            //}


            //var resp = this.ExecQuery.ExecuteScalar<int>("SELECT count(*) FROM fechas", null);
            //var asd = "";
        }
        /*
        public async Task LoadedAsync()
        {
            
            //var sAttr = System.Configuration.ConfigurationManager.AppSettings.Get("Key0");
            //
            //string datoCapturadoPorUsuario = "1";
            //
            //var parameters = new { IdProducto = datoCapturadoPorUsuario};
            ////var param = new IndexGroup{ IdProducto = 1 };
            //
            ////var res = ERP_Entorno.ExecQuery.QuerySingle<Producto>(Querys.Select_Prodcuto, param);
            ////var resp = await ERP_Entorno.ExecQuery.ExecuteScalarAsync<int>("SELECT count(*) FROM Products");
            //var asd = "";
        }
        */
        public void MethodSaludo()
        {
            //this.RespSaludo = "Hola " + this.Saludo;
            ComponentManager manager = new ComponentManager(@"../../../Components");

            foreach (IComponent item in manager.Modules)
            {
                this.MyComponent = item.GetComponent();
                //BaseViewModel dialogBaseViewModel = new ViewModels.ComponentViewModel();
                //DialogService.OpenDialog(dialogBaseViewModel, "Componente de Pruebas");
            }

        }

        
    }
}
