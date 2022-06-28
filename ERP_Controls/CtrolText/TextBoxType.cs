


using System;                   
using System.Windows;           
using System.Windows.Controls;  



namespace ERP_Controls.CtrolText
{
    public class TextBoxType : TextBox
    {
        private string UiId { get; set; }
        public string TypeValidate { get; set; }

        public static readonly DependencyProperty TypeIsValidProperty = DependencyProperty.Register("TypeIsValid", typeof(string), typeof(TextBoxType), new PropertyMetadata(""));
        public string TypeIsValid
        {
            get { return (string)GetValue(TypeIsValidProperty); }
            set { SetValue(TypeIsValidProperty, value); }
        }

        public TextBoxType()
        {
            

            this.TextChanged += TextBox_TextChanged;
            this.TypeIsValid = WrideValid(true, "", "", "");
            UiId = Guid.NewGuid().ToString();
        }
        


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var asd = ((Control)sender).GetHashCode().ToString();
            var tb = sender as TextBox;
            string name = tb.Name == "" ? "Campo" : tb.Name;
            if (tb != null)
            {
                try
                {
                    TypeCode type = GetTypeCode(TypeValidate);
                    if (type == TypeCode.Empty)
                    {
                        this.TypeIsValid = WrideValid(false, "Tipo de Dato desconocido", name, TypeValidate);
                        return;
                    }
                    else
                    {
                        var resp = Convert.ChangeType(tb.Text, type);
                        this.TypeIsValid = WrideValid(true, "", name, TypeValidate);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    this.TypeIsValid = WrideValid(false, ex.Message, name, TypeValidate);
                    return;
                }
            }
        }

        public string WrideValid(bool status, string message, string name, string type)
        {
            return (status ? "TRUE" : "FALSE") + "|" + this.UiId + "|" + message + "|" + name + "|" + type;
        }

        public TypeCode GetTypeCode(string type)
        {
            if (type == "Boolean")
                return TypeCode.Boolean;
            else if (type == "Byte")
                return TypeCode.Byte;
            else if (type == "Char")
                return TypeCode.Char;
            else if (type == "DateTime")
                return TypeCode.DateTime;
            else if (type == "Decimal")
                return TypeCode.Decimal;
            else if (type == "Double")
                return TypeCode.Double;
            else if (type == "Int16")
                return TypeCode.Int16;
            else if (type == "Int32")
                return TypeCode.Int32;
            else if (type == "Int64")
                return TypeCode.Int64;
            else if (type == "Object")
                return TypeCode.Object;
            else if (type == "SByte")
                return TypeCode.SByte;
            else if (type == "Single")
                return TypeCode.Single;
            else if (type == "String")
                return TypeCode.String;
            else if (type == "UInt16")
                return TypeCode.UInt16;
            else if (type == "UInt32")
                return TypeCode.UInt32;
            else if (type == "UInt64")
                return TypeCode.UInt64;

            return TypeCode.Empty;
        }


    }
}

