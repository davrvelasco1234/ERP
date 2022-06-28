
using System;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

using GemBox.Spreadsheet;
using LibMappingExcel.Models;
using MVVM.Model;
using MVVM.Helpers;


namespace LibMappingExcel.Helpers
{
    internal class DownloadFile
    {
        public static Response GetTemplateExcel<T>(SqlConnection sqlConnection, string proyecto, int IdPlantilla, string rutaGuardar)
        {
            Response response = new Response { IsSuccess = false, MessageType = MessageType.Warning };

            PlantillasExcel plantilla = ((ObservableCollection<PlantillasExcel>)Data.Query.GetPlantillas(sqlConnection, proyecto, IdPlantilla).Result).FirstOrDefault();
            if (plantilla is null)
            {
                response.Message = "No se encontro la plantilla";
                return response;
            }

            MappingExcel respMapping = plantilla.MappingExcel;
            if (respMapping is null)
            {
                response.Message = "MappingExcel no esta definido";
                return response;
            }


            SpreadsheetInfo.SetLicense("E0YU-JKB1-WFGE-HHO3");
            ExcelFile workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("Sheet1");



            if (respMapping.RenglonInicial > 1)
            {
                worksheet.Rows[0].Height = 600;
                worksheet.Rows[0].Style.VerticalAlignment = VerticalAlignmentStyle.Center;
                worksheet.Rows[0].Style.Font.Color = Color.Red;
                worksheet.Rows[0].Style.Font.Weight = ExcelFont.BoldWeight;
                worksheet.Rows[0].Style.Font.Size = 11 * 20;
                worksheet.Panes = new WorksheetPanes(PanesState.Frozen, 0, respMapping.RenglonInicial - 1, "A" + respMapping.RenglonInicial, PanePosition.BottomLeft);
            }
            if (respMapping.RenglonInicial > 2)
            {
                worksheet.Rows[1].Style.Font.Weight = ExcelFont.BoldWeight;
                worksheet.Rows[1].Style.Font.Size = 10 * 20;
            }



            try
            {

                T objectGeneric = InstancenGeneric.GetInstance<T>();

                foreach (PropertyInfo property in objectGeneric.GetType().GetProperties())
                {
                    System.Type type = property.PropertyType;
                    TypeCode typet = System.Type.GetTypeCode(type);
                    var asdd = type.BaseType;
                    if (typet == TypeCode.Object && type.BaseType.FullName == "System.Object")
                    {
                        continue;
                    }

                    string Comentario = "";
                    string Ejemplo = "";
                    string AliasProperty = null;
                    bool IsVisible = true;
                    ObservableCollection<ValorPropiedades> ValorPropiedadesList = new ObservableCollection<ValorPropiedades>();


                    if (!(property.GetCustomAttributesData().Where(
                            A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).FirstOrDefault() is null))
                    {
                        if (!(property.GetCustomAttributesData().Where(
                                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.IsVisible.ToString()).
                                                FirstOrDefault().TypedValue.Value is null))
                        {
                            IsVisible = Convert.ToBoolean(property.GetCustomAttributesData().Where(
                                    A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                    FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.IsVisible.ToString()).
                                    FirstOrDefault().TypedValue.Value);
                            if (!IsVisible)
                            {
                                continue;
                            }
                        }

                        if (!(property.GetCustomAttributesData().Where(
                                                    A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                    FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Message.ToString()).
                                                    FirstOrDefault().TypedValue.Value is null))
                        {
                            Comentario = property.GetCustomAttributesData().Where(
                                                    A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                    FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Message.ToString()).
                                                    FirstOrDefault().TypedValue.Value.ToString();
                        }
                        if (!(property.GetCustomAttributesData().Where(
                                                    A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                    FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Example.ToString()).
                                                    FirstOrDefault().TypedValue.Value is null))
                        {
                            Ejemplo = property.GetCustomAttributesData().Where(
                                                    A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                    FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.Example.ToString()).
                                                    FirstOrDefault().TypedValue.Value.ToString();
                        }
                        if (!(property.GetCustomAttributesData().Where(
                                                    A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                    FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.AliasProperty.ToString()).
                                                    FirstOrDefault().TypedValue.Value is null))
                        {
                            AliasProperty = property.GetCustomAttributesData().Where(
                                                    A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                                    FirstOrDefault().NamedArguments.Where(N => N.MemberName == AttMappingExcel.AttMappingExcelModel.AliasProperty.ToString()).
                                                    FirstOrDefault().TypedValue.Value.ToString();
                        }
                    }


                    var name = property.Name;
                    if (respMapping.PropiedadesList.Where(M => M.Propiedad == name).FirstOrDefault() is null)
                    {
                        continue;
                    }

                    int colum = respMapping.PropiedadesList.Where(M => M.Propiedad == name).FirstOrDefault().ColumnaExcel - 1;
                    FormatDate formatDate = respMapping.PropiedadesList.Where(M => M.Propiedad == name).FirstOrDefault().FormatDate;

                    if (!(formatDate is null) && formatDate.IsDate)
                    {
                        if (formatDate.InputFormatDate != "")
                        {
                            Ejemplo = formatDate.InputFormatDate;
                        }
                    }



                    if (respMapping.RenglonInicial > 1)
                    {
                        if (AliasProperty is null)
                        {
                            worksheet.Cells[0, colum].Value = name;
                        }
                        else
                        {
                            worksheet.Cells[0, colum].Value = AliasProperty.ToString().Replace("\r", Environment.NewLine);
                        }
                        
                        worksheet.Cells[0, colum].Style.FillPattern.SetSolid(Color.FromArgb(0, 235, 235, 235));
                    }

                    if (respMapping.RenglonInicial > 2)
                    {
                        worksheet.Cells[1, colum].Value = Comentario.ToString().Replace("\r", Environment.NewLine);
                        worksheet.Cells[1, colum].Style.FillPattern.SetSolid(Color.FromArgb(0, 235, 235, 235));
                    }


                    worksheet.Cells[respMapping.RenglonInicial-1, colum].Value = Ejemplo;
                }

                int columnCount = worksheet.CalculateMaxUsedColumns();
                for (int i = 0; i < columnCount; i++)
                {
                    worksheet.Columns[i].AutoFit(1, worksheet.Rows[1], worksheet.Rows[worksheet.Rows.Count - 1]);

                    if (respMapping.RenglonInicial > 1)
                    {
                        for (int j = 0; j < respMapping.RenglonInicial - 1; j++)
                        {
                            worksheet.Cells[j, i].Style.FillPattern.SetSolid(Color.FromArgb(0, 235, 235, 235));
                        }
                    }
                }

                

                workbook.Save(rutaGuardar);

                response.IsSuccess = true;
                response.Message = "";
                response.MessageType = MessageType.Success;
                response.Result = new object();
                return response;
            }
            catch (Exception e)
            {

                response.MessageType = MessageType.Bug;
                response.Message = string.Concat(e.StackTrace, Environment.NewLine, Environment.NewLine,
                                                e.TargetSite, Environment.NewLine, Environment.NewLine,
                                                e.Message);

                response.IsSuccess = false;
                return response;
            }
        }
    }
}
