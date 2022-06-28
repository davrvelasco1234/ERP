

using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;


using GemBox.Spreadsheet;
using LibMappingExcel.Models;
using MVVM.Model;
using MVVM.Helpers;
using MVVM.Notification;



namespace LibMappingExcel.Helpers
{
    internal class LoadFile
    {
        public Response LoadExcel<T>(SqlConnection sqlConnection, string assemblyName, int IDtemplate, string ruta, bool InsertValorError)
        {
            Response response = new Response { IsSuccess = false, MessageType = MessageType.Bug };
            try
            {
                LoadExcelResp<T> responseLoadExcel = new LoadExcelResp<T>();

                //OBTIENE LA PLANTILLA A UTILIZAR DE LA BASE DE DATOS
                PlantillasExcel plantilla = ((ObservableCollection<PlantillasExcel>)Data.Query.GetPlantillas(sqlConnection, assemblyName, IDtemplate).Result).FirstOrDefault();
                if (plantilla is null)
                {
                    response.Message = "No se encontro la plantilla";
                    return response;
                }
                /*************************************************************/


                //VALIDA QUE EXISTA EL MAPPING EN LA PLANTILLA
                MappingExcel respMapping = plantilla.MappingExcel;
                if (respMapping is null)
                {
                    response.Message = "MappingExcel no esta definido";
                    return response;
                }
                /*************************************************************/


                //CARGA EL ARCHIVO XLSX en dataTable
                SpreadsheetInfo.SetLicense("E0YU-JKB1-WFGE-HHO3");
                var workbook = ExcelFile.Load(ruta);
                var worksheet = workbook.Worksheets[0];

                DataTable dataTable = worksheet.CreateDataTable(new CreateDataTableOptions()
                {
                    ColumnHeaders = false,
                    StartRow = respMapping.RenglonInicial - 1,
                    NumberOfColumns = respMapping.PropiedadesList.Select(P => P.ColumnaExcel).Max(),
                    NumberOfRows = worksheet.Rows.Count,
                    Resolution = ColumnTypeResolution.AutoPreferStringCurrentCulture
                });

                if (dataTable.Rows.Count < 1)
                {
                    response.Message = "No se encontraron registros en el archivo";
                    return response;
                }
                /*************************************************************/



                //ESTA LISTA OBTENGRA DATOS CORRECTOS
                ObservableCollection<T> obsrCollT = new ObservableCollection<T>();
                //ESTA LISTA OBTENGRA DATOS CON ERROR
                ObservableCollection<T> obsrCollTError = new ObservableCollection<T>();




                //OBTIENE EL MAXIMO DE RENGLONES A LEER
                int renglonesMax = 0;
                if (dataTable.Rows.Count < respMapping.MaximoRenglones || respMapping.MaximoRenglones == 0)
                {
                    renglonesMax = dataTable.Rows.Count;
                }
                else
                {
                    Popup.ExecutePopup(MessageType.Warning, "Aviso", "El archivo supera la cantidad maxima de reglones permitidos " + Environment.NewLine + Environment.NewLine + "Solo se migrara la cantidad de registros permitidos");
                    renglonesMax = respMapping.MaximoRenglones;
                }
                /*************************************************************/


                //Lee dataTable que contien el archivo cargado
                for (int i = 0; i < renglonesMax; i++)
                {
                    //instancia del objeto generico
                    T objectGeneric = InstancenGeneric.GetInstance<T>();
                    DataRow row = dataTable.Rows[i];


                    //valida que en el DataRow almenos exista un dato para evaluar ademas del ID
                    //si no encuentra ningun dato el renglon actual se ignora
                    bool valido = false;
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        var valColum = row[j].ToString().Trim();
                        Propiedades propiedad = respMapping.PropiedadesList.Where(M => M.ColumnaExcel == (j + 1)).FirstOrDefault();
                        if(propiedad == null )
                        {
                            continue;
                        }
                        string propertyName = propiedad.Propiedad;

                        var isID = "False";
                        if (valColum.ToString().Trim() != "")
                        {
                            try
                            {
                                foreach (PropertyInfo property in objectGeneric.GetType().GetProperties())
                                {
                                    if (propertyName != property.Name) { continue;  }

                                    if (!(property.GetCustomAttributesData().Where(
                                        A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).FirstOrDefault() is null))
                                    {
                                        if (!(property.GetCustomAttributesData().Where(
                                                            A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                            FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.IsID.ToString()).
                                                            FirstOrDefault().TypedValue.Value is null))
                                        {
                                            isID = property.GetCustomAttributesData().Where(
                                                            A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                            FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.IsID.ToString()).
                                                            FirstOrDefault().TypedValue.Value.ToString();
                                            
                                        }
                                    }
                                }
                            } catch (Exception) { }
                        }

                        if (valColum.ToString().Trim() != "" && (isID == "False"))
                        {
                            valido = true;
                            break;
                        }
                    }
                    if (!valido) { continue; }
                    /*************************************************************/




                    //Busca la propiedad "MessageLibMappingExcel" en el objeto generico
                    //si la encuentra esta tendra los mensajes de error
                    PropertyInfo propertyMessage = objectGeneric.GetType().GetProperties().Where(P => P.Name == AttMappingExcel.AttMappingExcelModel.MessageLibMappingExcel.ToString()).FirstOrDefault();
                    if (!(propertyMessage is null))
                    {
                        Type type = propertyMessage.PropertyType;
                        if (System.Type.GetTypeCode(propertyMessage.PropertyType) != TypeCode.String)
                        {
                            propertyMessage = null;
                        }
                    }
                    //RowLibMappingExcel
                    PropertyInfo propertyRow = objectGeneric.GetType().GetProperties().Where(P => P.Name == AttMappingExcel.AttMappingExcelModel.RowLibMappingExcel.ToString()).FirstOrDefault();
                    if (!(propertyRow is null))
                    {
                        Type type = propertyRow.PropertyType;
                        if (System.Type.GetTypeCode(propertyRow.PropertyType) != TypeCode.Int32)
                        {
                            propertyRow = null;
                        }
                    }
                    /*************************************************************/


                    //inicializa
                    string messageError = "";               // descripcion del error 
                    bool propertyIsSuccess = true;          // valida la propiedad  
                    /*************************************************************/


                    //inicia la interaccion de las propiedades
                    foreach (PropertyInfo property in objectGeneric.GetType().GetProperties())
                    {
                        //se obtiene el tipo de la propiedad
                        System.Type type = property.PropertyType;
                        if (System.Type.GetTypeCode(type) == TypeCode.Object)
                        {
                            type = type.UnderlyingSystemType.GenericTypeArguments.FirstOrDefault();
                        }


                        //se busca la propiedad del objeto en el Mapeo
                        string name = property.Name;
                        if ((respMapping.PropiedadesList.Where(M => M.Propiedad == name).FirstOrDefault()) is null)
                        {
                            continue;
                        }


                        //obtiene la lista de constantes
                        ObservableCollection<ValorPropiedades> ValorPropiedadesList = respMapping.PropiedadesList.Where(M => M.Propiedad == name).FirstOrDefault().ValorPropiedadesList;
                        //obtiene en que columna del excel esta el valor para esta propiedad
                        int colum = respMapping.PropiedadesList.Where(M => M.Propiedad == name).FirstOrDefault().ColumnaExcel - 1;
                        if (row[colum] == null) { continue; }


                        //busca formatos de fecha
                        FormatDate formatDate = respMapping.PropiedadesList.Where(M => M.Propiedad == name).FirstOrDefault().FormatDate;
                        string InputFormatDate, OutputFormatDate;
                        if (!(formatDate is null) && formatDate.IsDate)
                        {
                            formatDate.IsDate = true;
                            if (formatDate.InputFormatDate != "")
                            {
                                InputFormatDate = formatDate.InputFormatDate;
                            }
                            else
                            {
                                InputFormatDate = "dd/MM/yyyy";
                            }
                            if (formatDate.OutputFormatDate != "")
                            {
                                OutputFormatDate = formatDate.OutputFormatDate;
                            }
                            else
                            {
                                OutputFormatDate = InputFormatDate;
                            }
                        }
                        else
                        {
                            formatDate.IsDate = false;
                            InputFormatDate = "";
                            OutputFormatDate = "";
                        }
                        /*************************************************************/


                        ValorDefault propiedadValorDefault = respMapping.PropiedadesList.Where(M => M.Propiedad == name).FirstOrDefault().ValorDefault;
                        //valida que el valor obtenido del row haga match tipo de la propiedad
                        bool respToTry = ToTryParse(System.Type.GetTypeCode(type), row[colum], InputFormatDate, out string valor);

                        if (!respToTry)
                        {
                            if (valor != string.Empty)
                            {
                                propertyIsSuccess = false;
                                if (!(propertyMessage is null))
                                {
                                    messageError = messageError + "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - El valor \"" + valor + "\" no puede ser convertido a " + type.ToString() + Environment.NewLine;
                                    propertyMessage.SetValue(objectGeneric, messageError);
                                }
                                property.SetValue(objectGeneric, null);
                                continue;
                            }
                            else
                            {
                                if (propiedadValorDefault.IsRequired)
                                {
                                    // Si el valor es vacio y no hay default.
                                    propertyIsSuccess = false;
                                    if (!(propertyMessage is null))
                                    {
                                        messageError = messageError + "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - El valor no debe ser vacio. " + Environment.NewLine;
                                        propertyMessage.SetValue(objectGeneric, messageError);
                                    }
                                    property.SetValue(objectGeneric, null);
                                    continue;
                                }
                                else
                                {
                                    valor = propiedadValorDefault.Valor;
                                }
                            }
                        }
                        else if (valor == string.Empty)
                        {
                            if(propiedadValorDefault.IsRequired)
                            {
                                propertyIsSuccess = false;
                                if (!(propertyMessage is null))
                                {
                                    messageError = messageError + "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - El valor no debe ser vacio. " + Environment.NewLine;
                                    propertyMessage.SetValue(objectGeneric, messageError);
                                }
                                property.SetValue(objectGeneric, null);
                                continue;
                            }
                            else
                            {
                                valor = propiedadValorDefault.Valor;
                            }
                        }


                        //revisa si la propiedad tiene el atributo RegularExpressionMappingExcelAttribute
                        if (!(property.GetCustomAttributesData().Where(
                            A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).FirstOrDefault() is null))
                        {

                            //**********regularExpression *************
                            if (!(property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.RegularExpression.ToString()).
                                                FirstOrDefault().TypedValue.Value is null))
                            {
                                //obtiene la exprecion regular
                                var regularExpression = property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.RegularExpression.ToString()).
                                                FirstOrDefault().TypedValue.Value.ToString();

                                //evalua exprecion regular
                                Regex regex = new Regex(regularExpression.ToString());
                                Match match = regex.Match(valor);
                                if (match.Success)
                                {
                                    try
                                    {
                                        //inserta el valor la propiedad del objeto
                                        InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                    }
                                    catch (Exception e)
                                    {
                                        //inserta la descripcion del error
                                        propertyIsSuccess = false;
                                        if (!(propertyMessage is null))
                                        {
                                            messageError = messageError + "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - " + e.Message + Environment.NewLine;
                                            propertyMessage.SetValue(objectGeneric, messageError);
                                        }
                                    }
                                }
                                else
                                {
                                    if (propiedadValorDefault == null)
                                    {
                                        //inserta el valor la propiedad del objeto pero como error
                                        //ya que la exprecion regular no se cumplio
                                        propertyIsSuccess = false;

                                        if (!(propertyMessage is null))
                                        {
                                            messageError = messageError + "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - El valor \"" + valor + "\" no cumple con la exprecion regular " + regularExpression.ToString() + Environment.NewLine;
                                            propertyMessage.SetValue(objectGeneric, messageError);
                                        }

                                        if (InsertValorError)
                                        {
                                            try
                                            {
                                                InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                            }
                                            catch (Exception e)
                                            {
                                                if (!(propertyMessage is null))
                                                {
                                                    messageError = messageError + "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - El valor \"" + valor + "\" no cumple con la exprecion regular " + regularExpression.ToString() + e.Message + Environment.NewLine;
                                                    propertyMessage.SetValue(objectGeneric, messageError);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        InsertObjectGeneric(ref objectGeneric, property, propiedadValorDefault.Valor, System.Type.GetTypeCode(type));
                                    }
                                }
                            }


                            //*****************Constans*********************
                            else
                            if (!(property.GetCustomAttributesData().Where(
                                                    A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                    FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Constans.ToString()).
                                                    FirstOrDefault().TypedValue.Value is null))
                            {
                                //obtiene las contantes
                                var Constantes = property.GetCustomAttributesData().Where(
                                                        A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                        FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Constans.ToString()).
                                                        FirstOrDefault().TypedValue.Value.ToString();
                                //busca que la contante recibida exista en la lista de contandes definidas
                                int exist = ValorPropiedadesList.Where(V => V.Valor == valor).Count();
                                int exist2 = ValorPropiedadesList.Where(V => V.Valor == propiedadValorDefault.Valor).Count();
                                if (exist > 0 || exist2 > 0)
                                {
                                    try
                                    {
                                        if (exist > 0)
                                        {
                                            //reliza el intercambio de variales y la inserta
                                            valor = ValorPropiedadesList.Where(V => V.Valor == valor).FirstOrDefault().Propiedad;

                                            InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                        }
                                        else if (exist2 > 0)
                                        {
                                            valor = propiedadValorDefault.Valor;
                                            //reliza el intercambio de variales y la inserta
                                            valor = ValorPropiedadesList.Where(V => V.Valor == valor).FirstOrDefault().Propiedad;
                                            InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        if (propiedadValorDefault == null)
                                        {
                                            propertyIsSuccess = false;

                                            if (!(propertyMessage is null))
                                            {
                                                messageError = messageError + "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - " + e.Message + Environment.NewLine;
                                                propertyMessage.SetValue(objectGeneric, messageError);
                                            }
                                        }
                                        else
                                        {
                                            InsertObjectGeneric(ref objectGeneric, property, propiedadValorDefault.Valor, System.Type.GetTypeCode(type));
                                        }
                                    }
                                }
                                else
                                {
                                    if (propiedadValorDefault == null)
                                    {
                                        //si no encuentra la constante en la lista la inserta como error
                                        propertyIsSuccess = false;

                                        if (!(propertyMessage is null))
                                        {
                                            messageError = messageError + "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - El valor \"" + valor + "\" no cumple con las constantes definidas " + string.Join("|", ValorPropiedadesList.Select(V => V.Valor)) + Environment.NewLine;
                                            propertyMessage.SetValue(objectGeneric, messageError);
                                        }


                                        if (InsertValorError)
                                        {
                                            try
                                            {
                                                InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                            }
                                            catch (Exception e)
                                            {
                                                if (!(propertyMessage is null))
                                                {
                                                    messageError = messageError = "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - " + e.Message + Environment.NewLine;
                                                    propertyMessage.SetValue(objectGeneric, messageError);
                                                }

                                            }
                                        }
                                    }
                                    else
                                    {
                                        InsertObjectGeneric(ref objectGeneric, property, propiedadValorDefault.Valor, System.Type.GetTypeCode(type));
                                    }
                                }
                            }


                            //si existe el atributo RegularExpressionMappingExcelAttribute pero no hay 
                            //regularExpression ni Constans entra aqui e inserta el valor
                            else
                            {
                                try
                                {
                                    if (formatDate.IsDate)
                                    {
                                        try
                                        {
                                            DateTime dateTime = new DateTime();
                                            if (DateTime.TryParse(valor.ToString().Trim(), out dateTime))
                                            {
                                                InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                            }
                                            else
                                            {
                                                var dateTime1 = DateTime.ParseExact(valor.ToString().Trim(), InputFormatDate, null);
                                                var dateTime2 = String.Format("{0:" + OutputFormatDate + "}", dateTime1);
                                                valor = dateTime2;

                                                InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                            }

                                        }
                                        catch (Exception e)
                                        {
                                            propertyIsSuccess = false;
                                            if (!(propertyMessage is null))
                                            {
                                                messageError = messageError = "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - \"" + valor + "\" - " + e.Message + Environment.NewLine;
                                                propertyMessage.SetValue(objectGeneric, messageError);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                    }
                                }
                                catch (Exception e)
                                {
                                    if (propiedadValorDefault == null)
                                    {
                                        propertyIsSuccess = false;
                                        if (!(propertyMessage is null))
                                        {
                                            messageError = messageError = "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - " + e.Message + Environment.NewLine;
                                            propertyMessage.SetValue(objectGeneric, messageError);
                                        }
                                    }
                                    else
                                    {
                                        InsertObjectGeneric(ref objectGeneric, property, propiedadValorDefault.Valor, System.Type.GetTypeCode(type));
                                    }
                                }
                            }
                        }
                        else
                        {
                            //si no existe el atributo RegularExpressionMappingExcelAttribute entra aqui
                            try
                            {
                                if (formatDate.IsDate)
                                {
                                    try
                                    {
                                        DateTime dateTime = new DateTime();
                                        if (DateTime.TryParse(valor.ToString().Trim(), out dateTime))
                                        {
                                            InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                        }
                                        else
                                        {
                                            var dateTime1 = DateTime.ParseExact(valor.ToString().Trim(), InputFormatDate, null);
                                            var dateTime2 = String.Format("{0:" + OutputFormatDate + "}", dateTime1);
                                            valor = dateTime2;

                                            InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                        }

                                    }
                                    catch (Exception e)
                                    {
                                        if (propiedadValorDefault == null)
                                        {
                                            propertyIsSuccess = false;
                                            if (!(propertyMessage is null))
                                            {
                                                messageError = messageError = "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - " + valor + " - " + e.Message + Environment.NewLine;
                                                propertyMessage.SetValue(objectGeneric, messageError);
                                            }
                                        }
                                        else
                                        {
                                            InsertObjectGeneric(ref objectGeneric, property, propiedadValorDefault.Valor, System.Type.GetTypeCode(type));
                                        }
                                    }
                                }
                                else
                                {
                                    InsertObjectGeneric(ref objectGeneric, property, valor, System.Type.GetTypeCode(type));
                                }
                            }
                            catch (Exception e)
                            {
                                if (propiedadValorDefault == null)
                                {
                                    propertyIsSuccess = false;
                                    if (!(propertyMessage is null))
                                    {
                                        messageError = messageError = "[R" + (i + respMapping.RenglonInicial) + "][C" + (colum + 1) + "] - " + e.Message + Environment.NewLine;
                                        propertyMessage.SetValue(objectGeneric, messageError);
                                    }
                                }
                                else
                                {
                                    InsertObjectGeneric(ref objectGeneric, property, propiedadValorDefault.Valor, System.Type.GetTypeCode(type));
                                }
                            }
                        }
                    }

                    if (!(propertyRow is null))
                    {
                        propertyRow.SetValue(objectGeneric, (i + respMapping.RenglonInicial));
                    }

                    //si todas las propiedades se insertaron correctamente 
                    //se inserta el objeto en obsrCollT
                    if (propertyIsSuccess || InsertValorError)
                    {
                        if (!(propertyMessage is null))
                        {
                            propertyMessage.SetValue(objectGeneric, messageError);
                        }
                        obsrCollT.Add(objectGeneric);
                    }

                    //si se encontraron errores se inserta en la lista con errores
                    if (!propertyIsSuccess)
                    {
                        obsrCollTError.Add(objectGeneric);
                    }
                }

                //fin de la ejecucion se crea el response
                if (obsrCollT.Count() > 0 || obsrCollTError.Count() > 0)
                {
                    response.IsSuccess = true;
                    response.MessageType = MessageType.Success;
                }
                else
                {
                    response.IsSuccess = false;
                    response.MessageType = MessageType.Warning;
                    response.Message = "No se encontraron datos en el archivo";
                }

                responseLoadExcel.ListObjectT = obsrCollT;
                responseLoadExcel.ListObjectTError = obsrCollTError;
                response.Result = responseLoadExcel;

                return response;
            }
            catch (Exception e)
            {
                //si llega aqui es porque algo no se contemplo en el codigo anterior y la libreria mandara un bug
                response.MessageType = MessageType.Bug;
                response.Message = string.Concat(e.StackTrace, Environment.NewLine, Environment.NewLine,
                                                e.TargetSite, Environment.NewLine, Environment.NewLine,
                                                e.Message);

                response.IsSuccess = false;
                return response;
            }
        }



        internal void InsertObjectGeneric<T>(ref T objectGeneric, PropertyInfo property, string valor, TypeCode type)
        {
            if (type == TypeCode.Boolean)
            {
                property.SetValue(objectGeneric, Convert.ToBoolean(valor));
            }
            else if (type == TypeCode.Byte)
            {
                property.SetValue(objectGeneric, Convert.ToByte(valor));
            }
            else if (type == TypeCode.Char)
            {
                property.SetValue(objectGeneric, Convert.ToChar(valor));
            }
            else if (type == TypeCode.DateTime)
            {
                property.SetValue(objectGeneric, Convert.ToDateTime(valor));
            }
            else if (type == TypeCode.DBNull)
            {

            }
            else if (type == TypeCode.Decimal)
            {
                property.SetValue(objectGeneric, Convert.ToDecimal(valor));
            }
            else if (type == TypeCode.Double)
            {
                property.SetValue(objectGeneric, Convert.ToDouble(valor));
            }
            else if (type == TypeCode.Empty)
            {

            }
            else if (type == TypeCode.Int16)
            {
                property.SetValue(objectGeneric, Convert.ToInt16(valor));
            }
            else if (type == TypeCode.Int32)
            {
                property.SetValue(objectGeneric, Convert.ToInt32(valor));
            }
            else if (type == TypeCode.Int64)
            {
                property.SetValue(objectGeneric, Convert.ToInt64(valor));
            }
            else if (type == TypeCode.Object)
            {

            }
            else if (type == TypeCode.SByte)
            {
                property.SetValue(objectGeneric, Convert.ToSByte(valor));
            }
            else if (type == TypeCode.Single)
            {
                property.SetValue(objectGeneric, Convert.ToSingle(valor));
            }
            else if (type == TypeCode.String)
            {
                property.SetValue(objectGeneric, valor.ToString());
            }
            else if (type == TypeCode.UInt16)
            {
                property.SetValue(objectGeneric, Convert.ToUInt16(valor));
            }
            else if (type == TypeCode.UInt32)
            {
                property.SetValue(objectGeneric, Convert.ToUInt32(valor));
            }
            else if (type == TypeCode.UInt64)
            {
                property.SetValue(objectGeneric, Convert.ToUInt64(valor));
            }
        }

        internal bool ToTryParse(TypeCode type, object objeto, string formatDate)
        {
            return ToTryParse(type, objeto, formatDate, out string valor);
        }

        internal bool ToTryParse(TypeCode type, object objeto, string formatDate, out string valor)
        {
            bool resp = false;
            valor = objeto.ToString().Trim();

            if (type == TypeCode.Boolean)
            {
                if (bool.TryParse(objeto.ToString(), out bool valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.Byte)
            {
                if (byte.TryParse(objeto.ToString(), out byte valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.Char)
            {
                if (char.TryParse(objeto.ToString(), out char valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.DateTime)
            {
                try
                {
                    DateTime dateTime = new DateTime();
                    if (DateTime.TryParse(objeto.ToString().Trim(), out dateTime))
                    {
                        resp = true;
                    }
                    else
                    {
                        DateTime.ParseExact(objeto.ToString().Trim(), formatDate, null);
                        resp = true;
                    }
                    valor = objeto.ToString().Trim();
                }
                catch (Exception)
                {

                }
                
            }
            //else if (type == TypeCode.DBNull)
            //{

            //}
            else if (type == TypeCode.Decimal)
            {
                if (decimal.TryParse(string.Format("{0:N10}", objeto), out decimal valResult))
                {
                    valor = string.Format("{0:N10}", objeto);
                    resp = true;
                }
            }
            else if (type == TypeCode.Double)
            {
                if (double.TryParse(string.Format("{0:N10}", objeto), out double valResult))
                {
                    valor = string.Format("{0:N10}", objeto);
                    resp = true;
                }
            }
            else if (type == TypeCode.Empty)
            {

            }
            else if (type == TypeCode.Int16)
            {
                if (Int16.TryParse(objeto.ToString(), out Int16 valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.Int32)
            {
                if (Int32.TryParse(objeto.ToString(), out Int32 valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.Int64)
            {
                if (Int64.TryParse(objeto.ToString(), out Int64 valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.Object)
            {

            }
            else if (type == TypeCode.SByte)
            {
                if (SByte.TryParse(objeto.ToString(), out sbyte valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.Single)
            {
                if (Single.TryParse(objeto.ToString(), out Single valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.String)
            {
                valor = objeto.ToString();
                resp = true;
            }
            else if (type == TypeCode.UInt16)
            {
                if (UInt16.TryParse(objeto.ToString(), out ushort valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.UInt32)
            {
                if (UInt32.TryParse(objeto.ToString(), out uint valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            else if (type == TypeCode.UInt64)
            {
                if (UInt64.TryParse(objeto.ToString(), out ulong valResult))
                {
                    valor = objeto.ToString();
                    resp = true;
                }
            }
            return resp;
        }

    }
}
