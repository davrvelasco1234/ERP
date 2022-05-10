


using System;
using System.Windows;
using ERP_Common;
using Microsoft.Toolkit.Mvvm.ComponentModel;


namespace ERP_MVVM.BaseMVVM
{
    public class BaseViewModelDialog : ObservableValidator
    {
        internal ErpResponse GetErpResponse
        {
            get;
            private set;
        }

        public void CloseDialogWithResult(Window dialog, ErpResponse result)
        {
            this.GetErpResponse = result;
            if (dialog != null)
                dialog.DialogResult = true;
        }
    }

    public class BaseViewModelDialog<T> : ObservableValidator
    {
        internal ErpResponse<T> GetErpResponse
        {
            get;
            private set;
        }


        public void CloseDialogWithResult(Window dialog, ErpResponse<T> result)
        {
            this.GetErpResponse = result;
            if (dialog != null)
                dialog.DialogResult = true;
        }
    }
}
