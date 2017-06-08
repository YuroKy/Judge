using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Judge.Logger
{
    public class LogUpdater
    {
        public void UpdateConfig()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("log4net"))
                    foreach (XmlNode node in element.ChildNodes)
                        if (node.Name.Equals("appender"))
                        {
                            foreach (XmlNode lowerNode in node.ChildNodes)
                                if (lowerNode.Name.Equals("param") && lowerNode.Attributes[0].Value == "File")
                                {
                                    string[] temp = lowerNode.Attributes[1].Value.ToString().Split('_', '.');
                                    lowerNode.Attributes[1].Value = temp[0] + "_" + (int.Parse(temp[1]) + 1).ToString() + ".txt";
                                    ConfigurationManager.RefreshSection("param");


                                }
                            ConfigurationManager.RefreshSection("appender");

                        }
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                ConfigurationManager.RefreshSection("log4net");
            }
        }
    }
}
