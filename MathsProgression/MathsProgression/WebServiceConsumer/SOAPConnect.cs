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
    sealed class SOAPConnect : IConnection
    {
        /// <summary>
        /// Single Instance of class
        /// </summary>
        private static SOAPConnect _instance = null;
        private static readonly object _padlock = new object();
        private static readonly ILog Log = LogManager.GetLogger("[Logger Class : SOAPConnect]");

        /// <summary>
        /// URL of Web Service
        /// </summary>
        string _url = "";

        SOAPConnect(string url)
        {
           _url = url;
           webRequest =  CreateWebRequest(url);
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

        private HttpWebRequest webRequest { get; set; }

        /// <summary>
        /// Send SOAP Message to Web service
        /// </summary>
        /// <param name="envelope"></param>
        /// <returns></returns>
        public string CallWebService(string envelope)
        {
            string soapResult = "";
            XmlDocument soapEnvelopeDocument = new XmlDocument();
           
            try
            {
                soapEnvelopeDocument.LoadXml(envelope);
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeDocument, webRequest);
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

        /// <summary>
        /// Return xml header
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public HttpWebRequest CreateWebRequest(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }


        /// <summary>
        /// Return enveloppe to call Fibonacci function
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string CreateSoapEnvelopeFibonacci(int number)
        {
            return @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org/"">
                                       <soapenv:Header/>
                                       <soapenv:Body>
                                          <tem:Fibonacci>
                                             <tem:i>" + number.ToString() + @"</tem:i>
                                          </tem:Fibonacci>
                                       </soapenv:Body>
                                    </soapenv:Envelope>";
        }

        /// <summary>
        /// Insert Soap Enveloppe to Web Request
        /// </summary>
        /// <param name="soapEnvelopeXml"></param>
        /// <param name="webRequest"></param>
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
