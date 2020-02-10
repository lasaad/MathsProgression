using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using log4net;
using MathsProgression.Services;
using Newtonsoft.Json.Linq;

namespace WebServiceConsumer
{
    public partial class MainForm : Form
    {
        private static string _url = "https://localhost:44342/Services/MathsProgressionService.asmx";
        private static readonly ILog Log = LogManager.GetLogger("[Logger Class : MainForm]");

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Function call when the button is clicked 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Compute_Click(object sender, EventArgs e)
        {
            string resultXML = "",
                   resultString = "";
            JObject json = null;

            try
            {
                var connexion = SOAPConnect.Instance(_url);
                string envelope = connexion.CreateSoapEnvelopeFibonacci(10);
                resultXML = connexion.CallWebService(envelope);
       
                json = JObject.Parse(MathsProgression.Convert.XmlToJson(resultXML));
                resultString = json["soap:Envelope"]["soap:Body"]["FibonacciResponse"]["FibonacciResult"].ToString();
                ResultOutput.Text = resultString;
            }
            catch (Exception ex)
            {
                Log.Error("An error happened : " + ex.Message);
            }
        }
    }
}
