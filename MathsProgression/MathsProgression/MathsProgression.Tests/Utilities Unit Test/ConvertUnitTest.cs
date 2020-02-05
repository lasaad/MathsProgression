using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathsProgression.Tests
{
    [TestClass]
    public class ConvertUnitTest
    {
        const string XMLsimpleTag = "<foo>bar</foo>",
            XMLcomplexTag = "<TRANS><HPAY><ID>103</ID><STATUS>3</STATUS><EXTRA><IS3DS>0</IS3DS><AUTH>031183</AUTH></EXTRA><INT_MSG/><MLABEL>501767XXXXXX6700</MLABEL><MTOKEN>project01</MTOKEN></HPAY></TRANS>",
            XMLbadFormat = "<foo>hello</bar>",
            JSONsimpleTag = "{\"foo\":\"bar\"}",
            JSONcomplexTag = "{\"TRANS\":{\"HPAY\":{\"ID\":\"103\",\"STATUS\":\"3\",\"EXTRA\":{\"IS3DS\":\"0\",\"AUTH\":\"031183\"},\"INT_MSG\":null,\"MLABEL\":\"501767XXXXXX6700\",\"MTOKEN\":\"project01\"}}}",
            JSONbadFormat = "Bad Xml format";
        

        [TestMethod]
        public void XmlToJsonTest()
        {
            var resultat = Convert.XmlToJson(XMLsimpleTag);
            Assert.AreEqual(JSONsimpleTag, resultat, "Incorrect JSON");

            resultat = Convert.XmlToJson(XMLcomplexTag);
            Assert.AreEqual(JSONcomplexTag, resultat, "Incorrect JSON");

            resultat = Convert.XmlToJson(XMLbadFormat);
            Assert.AreEqual(JSONbadFormat, resultat, "Incorrect JSON");

        }
    }
}
