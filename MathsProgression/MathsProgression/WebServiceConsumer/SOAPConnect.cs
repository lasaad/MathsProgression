using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebServiceConsumer
{
    sealed class  SOAPConnect : IConnection
    {
        private static SOAPConnect _instance = null;
        private static readonly object _padlock = new object();
        private static readonly ILog Log = LogManager.GetLogger("[Logger Class : SOAPConnect]");

        string _url = "";

        SOAPConnect(string url)
        {
            _url = url;
        }
        //Instance of web service connexion
        public static SOAPConnect Instance(string url)
        {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SOAPConnect(url);
                    }
                    return _instance;
                }
        }

        public string CallWebService()
        {
            string soapResult = "";
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(_url);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            try
            {
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();

                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        soapResult = rd.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error("An error happened : " + ex.Message);
            }

            return soapResult;
        }

        public HttpWebRequest CreateWebRequest(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            soapEnvelopeDocument.LoadXml(@"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">
                                       <soapenv:Header/>
                                       <soapenv:Body>
                                          <tem:Fibonacci>
                                             <tem:i>10</tem:i>
                                          </tem:Fibonacci>
                                       </soapenv:Body>
                                    </soapenv:Envelope>");
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
