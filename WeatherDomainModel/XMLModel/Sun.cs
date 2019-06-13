using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Weather.DomainModel.XMLModel
{
    [XmlRoot(ElementName = "sun")]
    public class Sun
    {
        [XmlAttribute(AttributeName = "set")]
        public string Set { get; set; }
        [XmlAttribute(AttributeName = "rise")]
        public string Rise { get; set; }
    }
}
