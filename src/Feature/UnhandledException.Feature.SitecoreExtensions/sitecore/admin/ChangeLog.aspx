﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeLog.aspx.cs" Inherits="UnhandledException.Feature.SitecoreExtensions.admin.ChangeLog" %>

<!DOCTYPE html>
<html>
<head>
    <title>Change Log</title>
    <style>
        th, td, p, input {
            font:14px Verdana;
        }
        table, th, td 
        {
            border: solid 1px #DDD;
            border-collapse: collapse;
            padding: 2px 3px;
            text-align: center;
        }
        th {
            font-weight:bold;
        }
    </style>
    <script src="../../scripts/jquery-3.6.0.min.js"></script>
</head>
<body>
    <input type="button" onclick="UpdateTableFromJSON()" value="Search" />
    <p id="showData"></p>
</body>

<script>
    window.onload = CreateTableFromJSON;
    function RevertItem(itemID, fieldID, fieldValue) {
        $.ajax({
            type: "POST",
            url: "/api/sitecore/ChangeLog/RevertChange",
            data: { ItemID: itemID, FieldID: fieldID, FieldValue: fieldValue },
            success: function (data) {
                UpdateTableFromJSON();
            }
        });
    }
    function CreateTableFromJSON() {
        $.ajax({
            type: "GET",
            url: "/api/sitecore/ChangeLog/GetChangeLog",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                CreateTable(data);
            }
        });
    }

    function UpdateTableFromJSON() {
        var query = "?ItemID=" + $("#ItemID").val();
        query += "&SaveID=" + $("#SaveID").val();
        query += "&Time=" + $("#Time").val();
        query += "&User=" + $("#User").val();
        query += "&FieldID=" + $("#FieldID").val();
        query += "&FieldName=" + $("#FieldName").val();
        query += "&OldValue=" + $("#OldValue").val();
        query += "&NewValue=" + $("#NewValue").val();

        $.ajax({
            type: "GET",
            url: "/api/sitecore/ChangeLog/GetChangeLog" + query,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                CreateTable(data);
            }
        });
    }

    function CreateTable(logs) {

        var col = [];
        for (var i = 0; i < logs.length; i++) {
            for (var key in logs[i]) {
                if (col.indexOf(key) === -1) {
                    col.push(key);
                }
            }
        }

        // CREATE DYNAMIC TABLE.
        var filterTable = document.createElement("table");
        var table = document.createElement("table");

        // CREATE HTML TABLE HEADER ROW USING THE EXTRACTED HEADERS ABOVE.

        var labels = ["SaveID", "ItemID", "Time", "User", "FieldID", "FieldName", "OldValue", "NewValue"];

        var tr = table.insertRow(-1);                   // TABLE ROW.

        //Render input row
        for (var i = 0; i < labels.length; i++) {
            var td = document.createElement("td");      // TABLE HEADER.
            td.innerHTML = "<input type=\"text\" id=\"" + labels[i] + "\" name=\"" + labels[i] + "\">";
            tr.appendChild(td);
        }

        var td = document.createElement("td");
        tr.appendChild(td);

        var tr = table.insertRow(-1);  

        //Render headers
        for (var i = 0; i < labels.length; i++) {
            var th = document.createElement("th");      // TABLE HEADER.
            th.innerHTML = labels[i];
            tr.appendChild(th);
        }

        var th = document.createElement("th");
        th.innerHTML = "Revert";
        tr.appendChild(th);

        // ADD JSON DATA TO THE TABLE AS ROWS.
        for (var i = 0; i < logs.length; i++) {

            tr = table.insertRow(-1);
            var itemID = logs[i][col[(labels.indexOf("ItemID"))]];
            var fieldID = logs[i][col[(labels.indexOf("FieldID"))]];
            var fieldValue = logs[i][col[(labels.indexOf("OldValue"))]];
            fieldValue = encodeURIComponent(fieldValue);
            console.log(fieldValue);

            for (var j = 0; j < col.length + 1; j++) {
                var tabCell = tr.insertCell(-1);
                if (j == col.length) {
                    tabCell.innerHTML = "<input type=\"button\" value=\"Revert\" onclick=\"RevertItem('" + itemID + "', '" + fieldID + "', '" + fieldValue + "')\">";
                }
                else {
                    var value = logs[i][col[j]];
                    value = value.replace(/"/g, '&quot;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
                    tabCell.innerHTML = value;
                }


            }
        }

        // FINALLY ADD THE NEWLY CREATED TABLE WITH JSON DATA TO A CONTAINER.
        var divContainer = document.getElementById("showData");
        divContainer.innerHTML = "";
        divContainer.appendChild(table);
    }
</script>
</html>
