using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using log4net;
using log4net.Config;
using Newtonsoft.Json;

namespace MathsProgression
{
    /// <summary>
    /// Class contains  static methods for convert data on specific format 
    /// </summary>
    /// 
    public static class Convert
    {

        private static readonly ILog Log = LogManager.GetLogger("[Logger Class : Convert]");

        /// <summary>
        ///Convert XML string to Json string
        /// </summary>
        /// <param name="xml">xml string</param>
        /// <returns>json string</returns>
        public static string XmlToJson(string xml)
        {
            XmlDocument doc = new XmlDocument();
            string jsonFormat = "";

            try
            {
                doc.LoadXml(xml);
                jsonFormat = JsonConvert.SerializeXmlNode(doc);
            }
            catch (XmlException ex)
            {
                Log.Error("An error happened : " + ex.Message);
                jsonFormat = "Bad Xml format";
            }
            catch (Exception ex)
            {
                Log.Error("An error happened : " + ex.Message);
            }
            return jsonFormat;
        }
    }
}
