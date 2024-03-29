﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace GNX
{
    public static class XmlManager
    {
        static string xmlFile;
        static string xmlData;

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
            catch (Exception)
            {
                throw;
            }
        }

        public static T Deserialize<T>() where T : class
        {
            using (var sr = new StringReader(xmlData))
            {
                var ser = new XmlSerializer(typeof(T));
                try { return (T)ser.Deserialize(sr); }
                catch (InvalidOperationException) { return null; }
            }
        }

        public static string Serialize<T>(T ObjectToSerialize)
        {
            var xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = false,
                Encoding = Encoding.UTF8
            };

            using (var textWriter = new StringWriterUTF8())
            using (var writer = XmlWriter.Create(textWriter, settings))
            {
                xmlSerializer.Serialize(writer, ObjectToSerialize, emptyNamespaces);
                return textWriter.ToString();
            }
        }
    }
}