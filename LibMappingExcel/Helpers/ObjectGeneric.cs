using LibMappingExcel.Models;
using MVVM.Helpers;
using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibMappingExcel.Helpers
{
    internal class ObjectGeneric
    {
        public static Response Attributtes<T>(string NameParam)
        {

            Response response = new Response { IsSuccess = false, MessageType = MessageType.Warning };
            try
            {
                T objectGeneric = InstancenGeneric.GetInstance<T>();
                ObservableCollection<AttributesObject> list = new ObservableCollection<AttributesObject>();
                AttributesObject attributesObject;
                foreach (PropertyInfo property in objectGeneric.GetType().GetProperties())
                {
                    string name = property.Name;
                    if (name != NameParam && NameParam != "***")
                    {
                        continue;
                    }

                    if ((property.GetCustomAttributesData().Where(
                                A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).FirstOrDefault() is null))
                    {
                        continue;
                    }


                    attributesObject = new AttributesObject();
                    attributesObject.Name = name;
                    Dictionary<string, string> dictionary = new Dictionary<string,string>();


                    var ListArguments = property.GetCustomAttributesData().Where(
                                        A => A.Constructor.DeclaringType.Name == AttMappingExcel.AttMappingExcelModel.RegularExpressionMappingExcelAttribute.ToString()).
                                        FirstOrDefault().NamedArguments;


                    foreach (var item in ListArguments)
                    {
                        var nameAtt = item.MemberName;
                        var valor = item.TypedValue.Value.ToString();
                        dictionary.Add(nameAtt, valor);
                    }
                    attributesObject.DictionaryAtt = dictionary;

                    list.Add(attributesObject);
                }


                response.IsSuccess = true;
                response.Message = "";
                response.MessageType = MessageType.Success;
                if (NameParam == "***")
                {
                    response.Result = list;
                }
                else
                {
                    response.Result = list.FirstOrDefault();
                }

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
