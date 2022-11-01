using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Controls.Notification
{
    public class HyperLinkEventArgs : System.EventArgs
    {
        public HyperLinkEventArgs(object hyperlinkObjectForRaisedEvent)
            : this()
        {
            this.HyperlinkObjectForRaisedEvent = hyperlinkObjectForRaisedEvent;
        }

        public HyperLinkEventArgs()
            : base()
        {
        }

        public object HyperlinkObjectForRaisedEvent { get; set; }
    }
}
