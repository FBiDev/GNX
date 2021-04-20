using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GNX
{
    public class cXMLConfig
    {
        //Definir variáveis de configuração a serem carregadas a partir de um arquivo Config.XML
        private static string gServerProd;
        private static string gServerDsv;
        private static bool gEhDsv;
        private static string gServerAtual;
        public static string SistemaDB { get { return gServerAtual; } }
        private static string gBaseSistema;
        public static string BaseDB { get { return gBaseSistema; } }
        private static string gImgSplash;
        private static string gImgPassword;
        private static string gImgDesktop;

        public static bool Load()
        {
            try
            {
                XmlDocument xmlFile = new XmlDocument();
                xmlFile.Load(cApp.ApplicationStartupPath() + "\\Config.xml");

                gServerProd = xmlFile.SelectSingleNode("Config").ChildNodes[0].ChildNodes[0].InnerText.ToString();
                gServerDsv = xmlFile.SelectSingleNode("Config").ChildNodes[0].ChildNodes[1].InnerText.ToString();
                gEhDsv = Convert.ToBoolean(xmlFile.SelectSingleNode("Config").ChildNodes[0].ChildNodes[2].InnerText);
                gBaseSistema = xmlFile.SelectSingleNode("Config").ChildNodes[0].ChildNodes[3].InnerText.ToString();

                string dirImagem = string.Empty;
                dirImagem = xmlFile.SelectSingleNode("Config").ChildNodes[1].ChildNodes[0].InnerText.ToString();
                if (dirImagem == "Application.StartupPath")
                {
                    dirImagem = AppDomain.CurrentDomain.BaseDirectory.ToString();
                }
                gImgSplash = dirImagem + "\\" + xmlFile.SelectSingleNode("Config").ChildNodes[1].ChildNodes[1].InnerText.ToString();
                gImgPassword = dirImagem + "\\" + xmlFile.SelectSingleNode("Config").ChildNodes[1].ChildNodes[2].InnerText.ToString();
                gImgDesktop = dirImagem + "\\" + xmlFile.SelectSingleNode("Config").ChildNodes[1].ChildNodes[3].InnerText.ToString();

                if (!gEhDsv)
                    gServerAtual = gServerProd;
                else
                    gServerAtual = gServerDsv;

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }
    }
}
