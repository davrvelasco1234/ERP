
using ERP_Common;
using ERP_Log4Net;

namespace ERP.Log4Net
{
    public static class ExtResponseWriteLogGeneric
    {
        public static ErpResponse<T> WriteLog<T>(this ErpResponse<T> response)
            => Write<T>(response, response.Exception is null ? Custom4Net.TracingLevel.ERROR : Custom4Net.TracingLevel.FATAL, null);

        public static ErpResponse<T> WriteLog<T>(this ErpResponse<T> response, Custom4Net.TracingLevel TracingLevel)
            => Write<T>(response, TracingLevel, null);

        public static ErpResponse<T> WriteLog<T>(this ErpResponse<T> response, params object[] paramsObj)
            => Write<T>(response, response.Exception is null ? Custom4Net.TracingLevel.ERROR : Custom4Net.TracingLevel.FATAL, paramsObj);

        public static ErpResponse<T> WriteLog<T>(this ErpResponse<T> response, Custom4Net.TracingLevel TracingLevel, params object[] paramsObj)
            => Write<T>(response, TracingLevel, paramsObj);


        internal static ErpResponse<T> Write<T>(ErpResponse<T> response, Custom4Net.TracingLevel tipoError, params object[] paramsObj)
        {
            if (response.IsSuccess)
            {
                return response;
            }
            else if (response.Exception is null)
            {
                Custom4Net.LogMessage(Custom4Net.TracingLevel.ERROR, GetMessageParams(paramsObj) + response.Message);
                return response;
            }
            else
            {
                Custom4Net.LogMessage(Custom4Net.TracingLevel.ERROR, GetMessageParams(paramsObj) + response.Message, response.Exception);
                return response;
            }
        }

        internal static string GetMessageParams(params object[] paramsObj)
        {

            return "";
        }

    }
}
