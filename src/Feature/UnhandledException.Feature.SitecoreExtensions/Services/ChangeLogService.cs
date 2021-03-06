using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnhandledException.Feature.SitecoreExtensions.Models;
using System.Xml.Linq;
using Sitecore.Diagnostics;

namespace UnhandledException.Feature.SitecoreExtensions.Services
{
    public class ChangeLogService
    {
        public ChangeLogService() { }
        public List<ChangeLogModel> GetChangeLog(string itemFilter = "")
        {
            string folder = "c:\\inetpub\\wwwroot\\App_Data\\ChangeLogs"; //set something up in config for this!
            List<string> files = new List<string>();
            List<ChangeLogModel> changes = new List<ChangeLogModel>();

            ID itemID = ID.Null;
            if(ID.TryParse(itemFilter, out itemID))
            {
                var ID = itemID.ToShortID().ToString().ToLower();
                files.Add(folder + "/" + ID + ".xml");
            }
            else
            {
                files = Directory.GetFiles(folder)?.ToList();
                // get all files from folder
            }

            foreach (var filePath in files)
                changes.AddRange(MapChanges(filePath));



            return changes;
        }

        private List<ChangeLogModel> MapChanges(string filePath)
        {
            List<ChangeLogModel> results = new List<ChangeLogModel>();
            XElement itemData = XElement.Load(filePath);
            List<XElement> saves = itemData.Descendants("save")?.ToList();

            foreach (var save in saves)
            {
                var itemId = Path.GetFileNameWithoutExtension(filePath);
                //maybe throw an error
                var itemID = Guid.Parse(itemId);
                var saveID = Guid.ParseExact(save.Element("saveId").Value, "B"); //maybe error here too if we have time
                var time = save.Element("date").Value;
                var user = save.Element("userName").Value;

                var fields = save.Descendants("field");

                foreach (var field in fields)
                {
                    ChangeLogModel changeLog= new ChangeLogModel()
                    {
                        ItemID = itemID,
                        SaveID = saveID,
                        Time = time,
                        User = user,
                        FieldID = Guid.Parse(field.Element("fieldId").Value),
                        FieldName = field.Element("fieldName").Value,
                        OldValue = field.Element("oldValue").Value,
                        NewValue = field.Element("newValue").Value
                    };
                    results.Add(changeLog);
                }
            }

            return results;
        }
    }
}