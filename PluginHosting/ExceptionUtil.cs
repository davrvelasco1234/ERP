using System;
using System.Collections.Generic;
using System.Linq;

namespace PluginHosting
{
    public class ExceptionUtil
    {
        public static string GetUserMessage(Exception ex)
        {
            return String.Join("\r\n",
                GetInnerExceptions(ex).Select(
                    e => String.Format("{0}: {1}", e.GetType().Name, e.Message)).ToArray());
        }

        private static IEnumerable<Exception> GetInnerExceptions(Exception ex)
        {
            for (var exception = ex; exception != null; exception = exception.InnerException)
            {
                yield return exception;
            }
        }

    }
}
