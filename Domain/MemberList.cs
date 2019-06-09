using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HOCBusiness.Domain
{
    [XmlRoot(ElementName = "Members")]
    public class MemberList
    {
        [XmlElement(ElementName = "Member")]
        public Member Member { get; set; }
    }
}
