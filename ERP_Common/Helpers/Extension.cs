using System;

namespace ERP_Common.Helpers
{
    public static class Extension
    {
        public static string FnxGetMessage(this Exception exception)
        {
            System.Diagnostics.StackTrace trace = new System.Diagnostics.StackTrace(exception, true);
            string method = trace.GetFrame(0) is null ? "" : trace.GetFrame(0).GetMethod().ToString();
            string line = trace.GetFrame(0) is null ? "" : trace.GetFrame(0).GetFileLineNumber().ToString();
            string fullName = exception.TargetSite is null ? "" : exception.TargetSite.DeclaringType.FullName;

            var resp = exception.Message + Environment.NewLine +
                  exception.GetType() + Environment.NewLine +
                  fullName + Environment.NewLine +
                  method + Environment.NewLine +
                  line + Environment.NewLine +
                  exception.Source + Environment.NewLine +
                  exception.StackTrace + Environment.NewLine + 
                  
                  exception.HelpLink + Environment.NewLine +
                  exception.HResult + Environment.NewLine +
                  exception.InnerException + Environment.NewLine +
                  exception.TargetSite + Environment.NewLine +
                  exception.Data;
            return resp;
        }
        

    }
}
