using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HOCBusiness.Domain
{
    public class CurrentStatus
    {
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Reason")]
        public string Reason { get; set; }
        [XmlElement(ElementName = "StartDate")]
        public string StartDate { get; set; }
        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName = "IsActive")]
        public string IsActive { get; set; }
    }
}
