using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Weather.DomainModel.XMLModel
{
    [XmlRoot(ElementName = "visibility")]
    public class Visibility
    {
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }
}
