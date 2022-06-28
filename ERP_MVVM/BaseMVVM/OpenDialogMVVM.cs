using ERP_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_MVVM.BaseMVVM
{
    public class OpenDialogMVVM
    {
        public static ErpResponse Show(BaseViewModelDialog param,
                                            string title,
                                            System.Windows.ResizeMode mode = System.Windows.ResizeMode.NoResize,
                                            System.Windows.WindowState state = System.Windows.WindowState.Normal,
                                            System.Windows.SizeToContent sizeToContent = System.Windows.SizeToContent.WidthAndHeight)
        {
            BaseViewModelDialog dialog = param;
            var response = DialogService.OpenDialog(dialog, title, mode, state, sizeToContent);
            if (response == null)
            {
                return new ErpResponse("Ventana cerrada", ERP_Common.Helpers.Constantes.MessageCodeWindowsClose);
            }
            return response;
        }

        public static ErpResponse<T> Show<T>(BaseViewModelDialog<T> param,
                                            string title,
                                            System.Windows.ResizeMode mode = System.Windows.ResizeMode.NoResize,
                                            System.Windows.WindowState state = System.Windows.WindowState.Normal,
                                            System.Windows.SizeToContent sizeToContent = System.Windows.SizeToContent.WidthAndHeight)
        {
            BaseViewModelDialog<T> dialog = param;
            var response = DialogService<T>.OpenDialog(dialog, title, mode, state, sizeToContent);
            if (response == null)
            {
                return new ErpResponse<T>("Ventana cerrada", ERP_Common.Helpers.Constantes.MessageCodeWindowsClose);
            }
            return response;
        }
    }
}
