using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnhandledException.Feature.SitecoreExtensions.Pipelines
{
    public class OnItemSavingHandler
    {
        public void OnItemSaving(object sender, EventArgs args)
        {
            Log.Error("SUCCESS GUYS", this);
            Sitecore.Events.SitecoreEventArgs eventArgs = args as Sitecore.Events.SitecoreEventArgs;
            Sitecore.Diagnostics.Assert.IsNotNull(eventArgs, "eventArgs");
            Sitecore.Data.Items.Item updatedItem = eventArgs.Parameters[0] as Sitecore.Data.Items.Item;
            Sitecore.Diagnostics.Assert.IsNotNull(updatedItem, "item");
            Sitecore.Data.Items.Item existingItem = updatedItem.Database.GetItem(
              updatedItem.ID,
              updatedItem.Language,
              updatedItem.Version);
            Sitecore.Diagnostics.Assert.IsNotNull(existingItem, "existingItem");
            Sitecore.Data.Fields.TextField title = updatedItem.Fields["title"];
            if (title == null)
            {
                return;
            }
            title.Value += new Random().Next();

        }
    }
}