
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

using LibMappingExcel.Helpers;
using LibMappingExcel.Models;
using MVVM.Model;

namespace LibMappingExcel.Data
{
    internal class Query
    {
        /// <summary>
        /// Select PlantillasExcel
        /// <para> Su respuesta se obtien con ObservableCollection(PlantillasExcel) resp = (ObservableCollection(PlantillasExcel))response.Result;  </para>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="proyecto"></param>
        /// <param name="idPlantilla"></param>
        /// <returns></returns>
        public static Response GetPlantillas(SqlConnection connection, string proyecto, int idPlantilla = 0)
        {
            Response resp = new Response { IsSuccess = false, MessageType = MessageType.Warning};
            try
            {
                string script;
                if (idPlantilla > 0)
                {
                    script = "select pe_Id as Id, pe_Proyecto as Proyecto, pe_Plantilla as Descripcion, pe_Mapping as XmlDocument " +
                        "from LibMappingExcel where pe_Proyecto = '" + proyecto + "' and pe_Id = '" + idPlantilla + "'";
                }
                else
                {
                    script = "select pe_Id as Id, pe_Proyecto as Proyecto, pe_Plantilla as Descripcion, pe_Mapping as XmlDocument " +
                        "from LibMappingExcel where pe_Proyecto = '" + proyecto + "'";
                }

                SqlCommand cmd = new SqlCommand(script, connection);

                cmd.CommandType = System.Data.CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ObservableCollection<PlantillasExcel> plantillas = new ObservableCollection<PlantillasExcel>();
                PlantillasExcel plantilla;

                foreach (DataRow item in dataTable.Rows)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(item["XmlDocument"].ToString());

                    plantilla = new PlantillasExcel
                    {
                        Id = Convert.ToInt32(item["Id"].ToString()),
                        Proyecto = item["Proyecto"].ToString(),
                        Descripcion = item["Descripcion"].ToString(),
                        MappingExcel = XML.XmlToObject<MappingExcel>(doc)
                    };
                    plantillas.Add(plantilla);
                }

                resp.IsSuccess = true;
                resp.Message = "";
                resp.MessageType = MessageType.Success;
                resp.Result = plantillas;
                return resp;
            }
            catch (Exception e)
            {
                resp.IsSuccess = false;
                resp.Message = e.Message;
                resp.MessageType = MessageType.Bug;
                return resp;
            }
        }

        public static string UpdatePlantilla(string Proyecto, string NombrePlantilla, string xml, int Id)
        {
            string script = "update LibMappingExcel " +
                    "set pe_Proyecto = '" + Proyecto + "', " +
                    "pe_Plantilla = '" + NombrePlantilla + "', " +
                    "pe_Mapping = '" + xml + "' " +
                    "where pe_Id = '" + Id.ToString() + "'";

            return script;
        }

        public static string InsertPlantilla(string assemblyName, string NombrePlantilla, string xml)
        {
            string script = "INSERT INTO LibMappingExcel " +
                            "VALUES('" + assemblyName + "', '" + NombrePlantilla + "', '" + xml + "')";
            return script;
        }

        public static string DeletePlantilla(int Id)
        {
            string script = "delete from LibMappingExcel where pe_Id = '" + Id + "'";
            return script;
        }

    }
}
