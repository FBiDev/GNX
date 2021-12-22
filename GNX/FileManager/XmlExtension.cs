using System;
using System.Xml;

namespace GNX
{
    public static class XmlExtension
    {
        public static XmlNode Child(this XmlNode father, string childName)
        {
            XmlNode child = null;

            try
            {
                child = father.SelectSingleNode(childName);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return child;
        }

        public static string ChildValue(this XmlNode father, string childName)
        {
            try
            {
                return father.SelectSingleNode(childName).InnerText;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return string.Empty;
            }
        }
    }
}
