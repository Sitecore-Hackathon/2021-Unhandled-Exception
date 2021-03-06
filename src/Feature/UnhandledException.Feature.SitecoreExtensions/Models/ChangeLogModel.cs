using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnhandledException.Feature.SitecoreExtensions.Models
{
    public class ChangeLogModel
    {
        public ChangeLogModel() { }
        public Guid SaveID { get; set; }
        public Guid ItemID { get; set; }
        public string Time { get; set; }
        public string User { get; set; }
        public Guid FieldID { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}