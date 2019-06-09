using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HOCBusiness.Domain
{
    public class Party
    {
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlText]
        public string Name { get; set; }
    }
}
