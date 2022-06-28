

using ERP_Common;
using System.Windows.Controls;

namespace ERP_MVVM.BaseMVVM
{
    public static class DialogService
    {
        public static ErpResponse OpenDialog(BaseViewModelDialog vm,
                string title = "",
                System.Windows.ResizeMode mode = System.Windows.ResizeMode.NoResize,
                System.Windows.WindowState state = System.Windows.WindowState.Normal,
                System.Windows.SizeToContent sizeToContent = System.Windows.SizeToContent.WidthAndHeight)
        {
            DialogWindow win = new DialogWindow();
            win.DataContext = vm;
            win.Title = title;
            win.ResizeMode = mode;
            win.WindowState = state;
            win.SizeToContent = sizeToContent;

            win.ShowDialog();
            ErpResponse result = (vm as BaseViewModelDialog).GetErpResponse;
            return result;
        }
    }


    public static class DialogService<T>
    {
        public static ErpResponse<T> OpenDialog(BaseViewModelDialog<T> vm,
                string title = "",
                System.Windows.ResizeMode mode = System.Windows.ResizeMode.NoResize,
                System.Windows.WindowState state = System.Windows.WindowState.Normal,
                System.Windows.SizeToContent sizeToContent = System.Windows.SizeToContent.WidthAndHeight)
        {
            DialogWindow win = new DialogWindow();
            win.DataContext = vm;
            win.Title = title;
            win.ResizeMode = mode;
            win.WindowState = state;
            win.SizeToContent = sizeToContent;

            

            win.ShowDialog();
            ErpResponse<T> result = (vm as BaseViewModelDialog<T>).GetErpResponse;
            return result;
        }
    }

}
