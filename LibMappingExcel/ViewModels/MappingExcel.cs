


using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using GemBox.Spreadsheet;
using LibMappingExcel.Helpers;
using Microsoft.Win32;
using MVVM.BaseMVVM;
using MVVM.Model;



namespace LibMappingExcel.ViewModels
{
    /// <summary>
    /// Da de alta plantillas para migrar archivos excel
    /// Mantenimiento de plantillas 
    /// Carga excel                     
    /// Descarga plantilla
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MappingExcel<T>
    {
        private readonly string assemblyName;
        private readonly SqlConnection sqlConnection;


        /// <summary>
        /// Inicializa AssemblyName y SqlConnection
        /// </summary>
        /// <param name="assembly">Nombre del proyecto</param>
        /// <param name="connection">Cadena de coneccion a sql</param>
        public MappingExcel(string assembly, SqlConnection connection)
        {
            var manager = new DataTemplateManager();
            manager.RegisterDataTemplate<MappingModelExcelViewModel, Views.MappingModelExcelPage>();
            manager.RegisterDataTemplate<MappingValuesModelViewModel, Views.MappingValuesModelPage>();

            //MappingModelExcelViewModel asfdsdf = new MappingModelExcelViewModel();

            this.assemblyName = assembly;
            this.sqlConnection = connection;
        }


        /// <summary>
        /// Manteniminto plantillas excel
        /// </summary>
        public void AlterMappingExcel()
        {
            DialogBaseViewModel dialogBaseViewModel = new LibMappingExcel.ViewModels.MappingModelExcelViewModel<T>(this.assemblyName, this.sqlConnection);
            Response responseMVVM = DialogService.OpenDialog(dialogBaseViewModel, "Mapping Excel");
        }

        public void AlterMappingExcel(int plantillaId)
        {
            DialogBaseViewModel dialogBaseViewModel = new LibMappingExcel.ViewModels.MappingModelExcelViewModel<T>(this.assemblyName, this.sqlConnection, plantillaId);
            //DialogBaseViewModel dialogBaseViewMode2 = new LibMappingExcel.ViewModels.MappingModelExcelViewModel<T>(this.assemblyName, this.sqlConnection);
            Response responseMVVM = DialogService.OpenDialog(dialogBaseViewModel, "Mapping Excel");
        }


        /// <summary>
        /// Obtiene lista de plantillas del programa en ejecucion 
        /// <para>Su respuesta se obtien con ObservableCollection(PlantillasExcel) resp = (ObservableCollection(PlantillasExcel))response.Result; </para>
        /// </summary>
        /// <param name="idPlantilla"></param>
        public Response GetPlantillas(int idPlantilla = 0)
        {
            return Data.Query.GetPlantillas(this.sqlConnection, this.assemblyName);
        }


        /// <summary>
        /// Importa una archivo excel a un objeto T
        /// <para>Su respuesta se obtien con LoadExcelResp<T> resp = (LoadExcelResp<T>)response.Result; </para>
        /// </summary>
        /// <param name="ruta">Ruta del del archivo xlsx</param>
        /// <param name="idPlantilla">Identificador de la plantilla</param>
        /// <param name="InsertValorError">Parametro opccional, En true los registron con error los insertara en ListObjectT</param>
        /// <returns></returns>
        public Response LoadExcel(string ruta, int idPlantilla, bool InsertValorError = false)
        {
            LoadFile loadFile = new LoadFile();
            return loadFile.LoadExcel<T>(this.sqlConnection, this.assemblyName, idPlantilla, ruta, InsertValorError);
        }


        /// <summary>
        /// Descarga una plantilla de muestra
        /// <para>Su respuesta se obtien con response.IsSuccess </para>
        /// </summary>
        /// <param name="ruta">Ruta donde se guardara el archivo xlsx</param>
        /// <param name="idPlantilla">Identificador de la plantilla</param>
        /// <returns></returns>
        public Response DownloadExcel(string ruta, int idPlantilla)
        {
            return DownloadFile.GetTemplateExcel<T>(this.sqlConnection, this.assemblyName, idPlantilla, ruta);
        }


        /// <summary>
        /// Retorna los atrigutos de la propiedad filtrada del objeto T
        /// <para>Su respuesta se obtien con AttributesObject resp = (AttributesObject)response.Result; </para>
        /// </summary>
        /// <param name="propiedad">Nombre de la propiedad de Objeto T</param>
        /// <returns></returns>
        public Response GetAttributtes(string propiedad)
        {
            return ObjectGeneric.Attributtes<T>(propiedad);
        }


        /// <summary>
        /// Retorna la lista de propiedades del objeto T, cada uno con sus atributos
        /// <para>Su respuesta se obtien con ObservableCollection(AttributesObject) resp = (ObservableCollection(AttributesObject))response.Result; </para>
        /// </summary>
        /// <returns></returns>
        public Response GetAttributtes()
        {
            return ObjectGeneric.Attributtes<T>("***");
        }



        



    }



    public class ConfigDownloadExcel
    {
        public string NameBook { get; set; } = "Book";
        public string NameSheet { get; set; } = "Sheet1";
        public int[] ColNum { get; set; } = new int[0];
    }

}
