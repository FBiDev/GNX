﻿using System;
using System.Xml.Serialization;

namespace GNX
{
    [Serializable()]
    [XmlRoot(ElementName = "Config")]
    public class ConfigXML
    {
        [XmlElement(ElementName = "Server")]
        public Server Servidor { get; set; }

        [XmlElement(ElementName = "WallPaper")]
        public WallPaper WallPaper { get; set; }

        public ConfigXML()
        {
            Servidor = new Server();
            WallPaper = new WallPaper();
        }
    }
}
