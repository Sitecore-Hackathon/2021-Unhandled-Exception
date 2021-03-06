using Sitecore.Data.Fields;
using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using UnhandledException.Feature.SitecoreExtensions.Models;

namespace UnhandledException.Feature.SitecoreExtensions.Pipelines
{
    public class OnItemSavingHandler
    {
        public void OnItemSaving(object sender, EventArgs args)
        {
            var eventArgs = args as Sitecore.Events.SitecoreEventArgs;
            Assert.IsNotNull(eventArgs, "eventArgs");

            var updatedItem = eventArgs.Parameters[0] as Sitecore.Data.Items.Item;
            Assert.IsNotNull(updatedItem, "item");

            var existingItem = updatedItem.Database.GetItem(updatedItem.ID, updatedItem.Language, updatedItem.Version);
            //existing item is null on creation
            //Assert.IsNotNull(existingItem, "existingItem");

            //see if an xml for this item already exists
            var folderPath = $"{AppDomain.CurrentDomain.BaseDirectory}App_Data\\ChangeLogs";

            //ensures that the folder exists
            Directory.CreateDirectory(folderPath);

            var filePath = $"{folderPath}\\{updatedItem.ID.Guid.ToString("N")}.xml";

            var fileExists = File.Exists(filePath);
            //if the file exists we deserialize xml into a c# object, update the object, serialize it back, write it to file
            var changeLogItem = new ChangeLogItem();
            if (fileExists)
            {
                var serializer = new XmlSerializer(typeof(ChangeLogItem));
                using (var fileStream = new FileStream(filePath, FileMode.Open))
                {
                    changeLogItem = (ChangeLogItem)serializer.Deserialize(fileStream);
                }
            }

            //create object to be serialized into xml to be written to a file
            var changeLogSaveState = new ChangeLogSaveState();
            changeLogSaveState.SaveId = Guid.NewGuid().ToString("B");
            changeLogSaveState.UserName = updatedItem[Sitecore.FieldIDs.UpdatedBy];

            changeLogSaveState.Date = DateTime.Now.ToString();

            if (changeLogItem.SaveStates == null)
            {
                changeLogItem.SaveStates = new List<ChangeLogSaveState>();
            }
            changeLogItem.SaveStates.Add(changeLogSaveState);

            var noFieldsWereUpdated = true;
            foreach (Field field in updatedItem.Fields)
            {
                //if existing is null on creation use empty string to represent empty string
                var oldValue = existingItem?[field.ID] ?? "";
                var newValue = updatedItem[field.ID];
                if (oldValue != newValue)
                {
                    noFieldsWereUpdated = false;
                    var changeLogField = new ChangeLogField();

                    changeLogField.fieldName = field.Name;
                    changeLogField.fieldId = field.ID.ToString();
                    changeLogField.oldValue = oldValue;
                    changeLogField.newValue = newValue;

                    if (changeLogSaveState.changeLogFields == null)
                    {
                        changeLogSaveState.changeLogFields = new List<ChangeLogField>();
                    }

                    changeLogSaveState.changeLogFields.Add(changeLogField);
                }
            }

            var max = 3;

            if (changeLogItem.SaveStates.Count() > max)
            {
                changeLogItem.SaveStates.RemoveAt(0);
            }

            //no fields were updated, we don't need to touch the xml file.
            if (noFieldsWereUpdated)
            {
                return;
            }

            //purge the old file to create a new one
            File.Delete(filePath);

            //serialize object into xml string for writing
            var xsSubmit = new XmlSerializer(typeof(ChangeLogItem));
            var subReq = changeLogItem;
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (var writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString(); // Your XML
                    xml = xml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
                }
            }

            //need to dispose of the open stream, using a using statement for now
            if (!File.Exists(filePath))
            {
                using (var myFile = File.Create(filePath))
                {
                    myFile.Close();
                }
            }

            File.WriteAllText(filePath, xml);
        }
    }
}