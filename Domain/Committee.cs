using System;
using System.Collections.Generic;

namespace HOCBusiness.Domain
{
    public class Committee
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<object> Inquiries { get; set; }
    }
}