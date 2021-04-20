using System;
using System.Text;
//
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace GNX
{
    public class cXML
    {
        private static string xmlFile;
        private static string xmlData;

        public static bool Load(string file, bool baseDirectory = true)
        {
            try
            {
                if (baseDirectory) { xmlFile = AppDomain.CurrentDomain.BaseDirectory + "\\" + file; }
                xmlData = File.ReadAllText(xmlFile);
                xmlData = Regex.Replace(xmlData, ">FALSE<", ">0<", RegexOptions.IgnoreCase);
                xmlData = Regex.Replace(xmlData, ">TRUE<", ">1<", RegexOptions.IgnoreCase);

                return true;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }

        public static T Deserialize<T>() where T : class
        {
            using (StringReader sr = new StringReader(xmlData))
            {
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
                try { return (T)ser.Deserialize(sr); }
                catch (InvalidOperationException) { return null; }
            }
        }

        public static string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;
            settings.Encoding = Encoding.UTF8;

            using (var textWriter = new StringWriterUTF8())
            using (var writer = XmlWriter.Create(textWriter, settings))
            {
                xmlSerializer.Serialize(writer, ObjectToSerialize, emptyNamespaces);
                return textWriter.ToString();
            }
        }
    }
}
