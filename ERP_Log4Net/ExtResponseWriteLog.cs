
using ERP_Common;

namespace ERP_Log4Net
{
    public static class ExtResponseWriteLog
    {
        public static ErpResponse WriteLog(this ErpResponse response)
            => Write(response, response.Exception is null ? Custom4Net.TracingLevel.ERROR : Custom4Net.TracingLevel.FATAL, null);

        public static ErpResponse WriteLog(this ErpResponse response, Custom4Net.TracingLevel TracingLevel)
            => Write(response, TracingLevel, null);

        public static ErpResponse WriteLog(this ErpResponse response, params object[] paramsObj)
            => Write(response, response.Exception is null ? Custom4Net.TracingLevel.ERROR : Custom4Net.TracingLevel.FATAL, paramsObj);

        public static ErpResponse WriteLog(this ErpResponse response, Custom4Net.TracingLevel TracingLevel, params object[] paramsObj)
            => Write(response, TracingLevel, paramsObj);


        internal static ErpResponse Write(ErpResponse response, Custom4Net.TracingLevel tipoError, params object[] paramsObj)
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
