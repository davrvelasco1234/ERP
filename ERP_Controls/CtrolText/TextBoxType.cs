
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
                    TypeCode type = ERP_Common.Helpers.Converts.GetTypeCode(TypeValidate);
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

        

    }


}

