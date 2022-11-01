using System;
using System.Collections.Generic;

namespace ERP_Controls.Loading
{

    internal class CommandManagerHelper
    {
        public static void CallWeakReferenceHandlers(List<WeakReference> handlers)
        {
            if (handlers != null)
            {
                var callees = new EventHandler[handlers.Count];
                var count = 0;

                for (var i = handlers.Count - 1; i >= 0; i--)
                {
                    var reference = handlers[i];
                    var handler = reference.Target as EventHandler;

                    if (handler == null)
                    {
                        handlers.RemoveAt(i);
                    }
                    else
                    {
                        callees[count] = handler;
                        count++;
                    }
                }

                for (var i = 0; i < count; i++)
                {
                    var handler = callees[i];
                    handler(null, EventArgs.Empty);
                }
            }
        }

        public static void AddWeakReferenceHandler(ref List<WeakReference> handlers, EventHandler handler)
        {
            if (handlers == null)
            {
                handlers = new List<WeakReference>();
            }

            handlers.Add(new WeakReference(handler));
        }

        public static void RemoveWeakReferenceHandler(List<WeakReference> handlers, EventHandler handler)
        {
            if (handlers != null)
            {
                for (var i = handlers.Count - 1; i >= 0; i--)
                {
                    var reference = handlers[i];
                    var existingHandler = reference.Target as EventHandler;

                    if ((existingHandler == null) || (existingHandler == handler))
                    {
                        handlers.RemoveAt(i);
                    }
                }
            }
        }

    }
}
