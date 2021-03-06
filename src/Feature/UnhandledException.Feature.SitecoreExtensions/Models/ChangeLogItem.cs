using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace UnhandledException.Feature.SitecoreExtensions.Models
{
    [XmlRoot("item")]
    public class ChangeLogItem
    {
        [XmlElement("save")]
        public List<ChangeLogSaveState> SaveStates { get; set; }
    }

    public class ChangeLogSaveState
    {
        [XmlElement("saveId")]
        public string SaveId { get; set; }
        [XmlElement("userName")]
        public string UserName { get; set; }
        [XmlElement("date")]
        public string Date { get; set; }
        [XmlElement("field")]
        public List<ChangeLogField> changeLogFields { get; set; }
    }

    public class ChangeLogField
    {
        //public ChangeLogField() { }

        [XmlElement("fieldName")]
        public string fieldName { get; set; }
        [XmlElement("fieldId")]
        public string fieldId { get; set; }
        [XmlElement("oldValue")]
        public string oldValue { get; set; }
        [XmlElement("newValue")]
        public string newValue { get; set; }
    }
}
