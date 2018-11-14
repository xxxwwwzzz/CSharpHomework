using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\xx.xml");
                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();
                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load(@".\..\..\xx.xslt");
                FileStream outFileStream = File.OpenWrite(@"..\..\xx.html");
                XmlTextWriter writer =new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);

            }
            catch(XmlException e)
            {
                Console.WriteLine("XML Exception:" + e.ToString());
            }
            catch(XsltException e)
            {
                Console.WriteLine("XSLT Exception:" + e.ToString());
            }
        }
    }
}
