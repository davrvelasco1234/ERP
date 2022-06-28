
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace LibMappingExcel.Helpers
{
    public class XML
    {
        public static T XmlToObject<T>(XmlDocument document)
        {
            XmlReader reader = new XmlNodeReader(document);
            var serializer = new XmlSerializer(typeof(T));
            T result = (T)serializer.Deserialize(reader);
            return result;
        }


        public static XmlDocument ObjectToXml(object o)
        {
            string version = "<?xml version=\"1.0\" encoding=\"utf-16\"?>";
            string xmlns = "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"";

            StringWriter sw = new StringWriter();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());

                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception)
            {

            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            string xml = sw.ToString().Replace(version, "").Replace(xmlns, "");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc;
        }


        /*
        private XmlDocument ToXmlDocument(MappingExcel mappingExcel)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement element1 = doc.CreateElement("MappingExcel");
            element1.AppendChild(doc.CreateElement("RenglonInicial")).AppendChild(doc.CreateTextNode(mappingExcel.RenglonInicial));
            element1.AppendChild(doc.CreateElement("MaximoRenglones")).AppendChild(doc.CreateTextNode(mappingExcel.MaximoRenglones));
            element1.AppendChild(doc.CreateElement("NumeroConlumnas")).AppendChild(doc.CreateTextNode(mappingExcel.NumeroConlumnas));
            element1.AppendChild(doc.CreateElement("MaximoColumnas")).AppendChild(doc.CreateTextNode(mappingExcel.MaximoColumnas));

            XmlElement element22 = doc.CreateElement("PropiedadesList");
            foreach (Propiedades item in mappingExcel.PropiedadesList)
            {
                XmlElement element2 = doc.CreateElement("Propiedades");
                element2.AppendChild(doc.CreateElement("Propiedad")).AppendChild(doc.CreateTextNode(item.Propiedad));
                element2.AppendChild(doc.CreateElement("ColumnaExcel")).AppendChild(doc.CreateTextNode(item.ColumnaExcel.ToString()));

                XmlElement element33 = doc.CreateElement("ValorPropiedadesList");
                foreach (ValorPropiedades itemValor in item.ValorPropiedadesList)
                {
                    XmlElement element3 = doc.CreateElement("ValorPropiedades");
                    element3.AppendChild(doc.CreateElement("Propiedad")).AppendChild(doc.CreateTextNode(itemValor.Propiedad));
                    element3.AppendChild(doc.CreateElement("Valor")).AppendChild(doc.CreateTextNode(itemValor.Valor));
                    element33.AppendChild(element3);
                }
                element2.AppendChild(element33);
                element22.AppendChild(element2);
            }

            element1.AppendChild(element22);
            doc.AppendChild(element1);
            return doc;
        }
        */
    }

}
