using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HOCBusiness.Domain
{
    public class Member
    {
        [XmlElement(ElementName = "DisplayAs")]
        public string DisplayAs { get; set; }
        [XmlElement(ElementName = "ListAs")]
        public string ListAs { get; set; }
        [XmlElement(ElementName = "FullTitle")]
        public string FullTitle { get; set; }
        [XmlElement(ElementName = "LayingMinisterName")]
        public string LayingMinisterName { get; set; }
        [XmlElement(ElementName = "DateOfBirth")]
        public Nullable<DateTime> DateOfBirth { get; set; }
        [XmlElement(ElementName = "DateOfDeath")]
        public Nullable<DateTime> DateOfDeath { get; set; }
        [XmlElement(ElementName = "Gender")]
        public string Gender { get; set; }
        [XmlElement(ElementName = "Party")]
        public Party Party { get; set; }
        [XmlElement(ElementName = "House")]
        public string House { get; set; }
        [XmlElement(ElementName = "MemberFrom")]
        public string MemberFrom { get; set; }
        [XmlElement(ElementName = "HouseStartDate")]
        public Nullable<DateTime> HouseStartDate { get; set; }
        [XmlElement(ElementName = "HouseEndDate")]
        public Nullable<DateTime> HouseEndDate { get; set; }
        [XmlElement(ElementName = "CurrentStatus")]
        public CurrentStatus CurrentStatus { get; set; }
        [XmlAttribute(AttributeName = "Member_Id")]
        public string Member_Id { get; set; }
        [XmlAttribute(AttributeName = "Dods_Id")]
        public string Dods_Id { get; set; }
        [XmlAttribute(AttributeName = "Pims_Id")]
        public string Pims_Id { get; set; }
        [XmlAttribute(AttributeName = "Clerks_Id")]
        public string Clerks_Id { get; set; }
    }
}
