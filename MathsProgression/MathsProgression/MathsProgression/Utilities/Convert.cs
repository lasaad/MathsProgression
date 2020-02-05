using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using Newtonsoft.Json;

namespace MathsProgression
{
    /// <summary>
    /// Class contains  static methods for convert data on specific format 
    /// </summary>
    /// 
    public static class Convert
    {
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
            catch (Exception ex)
            {
                jsonFormat = "Bad Xml format";
            }
            return jsonFormat;




        }
    }
}
