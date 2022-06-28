
using System;
using System.Windows;
using System.Windows.Markup;


namespace ERP_MVVM.Helpers
{
    public class DataTemplateManager
    {

        public static DataTemplate RegisterDataTemplate<TViewModel, TView>() where TView : FrameworkElement
        {
            return RegisterDataTemplate(typeof(TViewModel), typeof(TView));
        }


        private static DataTemplate RegisterDataTemplate(Type viewModelType, Type viewType)
        {
            var template = CreateTemplate(viewModelType, viewType);
            var key = template.DataTemplateKey;
            bool exist = false;
            foreach (var item in Application.Current.Resources.Keys)
            {
                if (item.ToString() == key.ToString())
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                Application.Current.Resources.Add(key, template);
            }

            return template;
        }



        private static DataTemplate CreateTemplate(Type viewModelType, Type viewType)
        {
            const string xamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}}\"><v:{1} /></DataTemplate>";
            var xaml = String.Format(xamlTemplate, viewModelType.Name, viewType.Name);

            var context = new ParserContext();

            context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
            context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace, viewModelType.Assembly.FullName);
            context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace, viewType.Assembly.FullName);

            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            var template = (DataTemplate)XamlReader.Parse(xaml, context);
            return template;
        }

    }

    /*

    public class DataTemplateManager
    {
        public  DataTemplateManager RegisterDataTemplate<TViewModel, TView>() where TView : FrameworkElement
        {
            return RegisterDataTemplate(typeof(TViewModel), typeof(TView));
        }

        private DataTemplateManager RegisterDataTemplate(Type viewModelType, Type viewType)
        {
            var template = CreateTemplate(viewModelType, viewType);
            var key = template.DataTemplateKey;
            bool exist = false;
            foreach (var item in Application.Current.Resources.Keys)
            {
                if (item.ToString() == key.ToString())
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                Application.Current.Resources.Add(key, template);
            }
            return this;
        }



        private static DataTemplate CreateTemplate(Type viewModelType, Type viewType)
        {
            const string xamlTemplate = "<DataTemplate DataType=\"{{x:Type vm:{0}}}\"><v:{1} /></DataTemplate>";
            var xaml = String.Format(xamlTemplate, viewModelType.Name, viewType.Name);

            var context = new ParserContext();

            context.XamlTypeMapper = new XamlTypeMapper(new string[0]);
            context.XamlTypeMapper.AddMappingProcessingInstruction("vm", viewModelType.Namespace, viewModelType.Assembly.FullName);
            context.XamlTypeMapper.AddMappingProcessingInstruction("v", viewType.Namespace, viewType.Assembly.FullName);

            context.XmlnsDictionary.Add("", "http://schemas.microsoft.com/winfx/2006/xaml/presentation");
            context.XmlnsDictionary.Add("x", "http://schemas.microsoft.com/winfx/2006/xaml");
            context.XmlnsDictionary.Add("vm", "vm");
            context.XmlnsDictionary.Add("v", "v");

            var template = (DataTemplate)XamlReader.Parse(xaml, context);
            return template;

        }

    }


    */
}
