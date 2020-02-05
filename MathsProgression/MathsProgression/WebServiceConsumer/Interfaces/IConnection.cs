using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebServiceConsumer
{
    interface IConnection
    {
        HttpWebRequest CreateWebRequest(string url, string action);

        string CallWebService();
    }
}