
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using ERP_Components;
using ERP_MVVM.BaseMVVM;
using Microsoft.Toolkit.Mvvm.Input;

namespace ERP_Component_1.ViewModels
{
    public class ComponentViewModel : BaseViewModel, IComponentView
    {
        private string inputText;
        public string InputText
        {
            get => inputText;
            set => SetProperty(ref this.inputText, value);
        }

        private string outputText;
        public string OutputText
        {
            get => outputText;
            set => SetProperty(ref this.outputText, value);
        }

        public ICommand LoadedCommand => new RelayCommand(Loaded);

        

        public ICommand MethodButtomCommand => new RelayCommand(MethodButtom);


        public ComponentViewModel()
        {
            //int uno = 1;
            //int cero = 1;
            //var ASDF = (uno / cero);
            //

            Console.WriteLine("contructor");
        
            //this.OutputText = "TITULO";

        }

        public void Loaded()
        {
            //System.Threading.Thread.Sleep(5000);

            this.OutputText = "TITULO";


            
        }
        


        public void MethodButtom()
        {
            this.OutputText = "Hola " + this.InputText;

        }
    }
}
