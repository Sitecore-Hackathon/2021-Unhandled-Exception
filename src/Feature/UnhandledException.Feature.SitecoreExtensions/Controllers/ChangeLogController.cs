using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using UnhandledException.Feature.SitecoreExtensions.Models;
using UnhandledException.Feature.SitecoreExtensions.Services;

namespace UnhandledException.Feature.SitecoreExtensions.Controllers
{
    
    public class ChangeLogController : Controller
    {
        [HttpGet]
        public JsonResult GetChangeLog(string ItemID = "", string SaveID = "", string Time = "", string User = "", string FieldID = "", string FieldName = "", string OldValue = "", String NewValue = "")
        {
            var changeLogService = new ChangeLogService();
            var changes = changeLogService.GetChangeLog(ItemID);

            changes = changes.OrderByDescending(x => x.Time)?.ToList();

            if (!string.IsNullOrEmpty(ItemID))
                changes = changes.Where(x => string.Equals(x.ItemID.ToString(), ItemID, StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(SaveID))
                changes = changes.Where(x => string.Equals(x.SaveID.ToString(), SaveID, StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(Time))
                changes = changes.Where(x => string.Equals(x.Time, Time, StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(User))
                changes = changes.Where(x => string.Equals(x.User, User, StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(FieldID))
                changes = changes.Where(x => string.Equals(x.FieldID.ToString(), FieldID, StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(FieldName))
                changes = changes.Where(x => string.Equals(x.FieldName, FieldName, StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(OldValue))
                changes = changes.Where(x => string.Equals(x.OldValue, OldValue, StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(NewValue))
                changes = changes.Where(x => string.Equals(x.NewValue, NewValue, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return new JsonResult()
            {
                Data = changes,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public void RevertChange(string ItemID, string FieldID, string FieldValue = "")
        {
            var changeLogService = new ChangeLogService();
            changeLogService.RevertChange(ItemID, FieldID, FieldValue);
        }
    }
}