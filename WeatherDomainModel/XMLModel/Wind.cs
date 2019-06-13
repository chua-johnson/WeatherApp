using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Weather.DomainModel.XMLModel
{
    [XmlRoot(ElementName = "wind")]
    public class Wind
    {
        [XmlElement(ElementName = "speed")]
        public Speed Speed { get; set; }
        [XmlElement(ElementName = "gusts")]
        public string Gusts { get; set; }
        [XmlElement(ElementName = "direction")]
        public Direction Direction { get; set; }
    }
}
