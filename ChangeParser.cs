using System;
using System.Collections.Generic;
using System.IO;
using Parser.Interfaces;
using Parser.Entities;

namespace Parser
{
    public class ChangesParser : IParser
    {
        List<Change> changes;

        public void Parse(string filename)
        {
            changes = new List<Change>();
            StreamReader streamReader = new StreamReader(filename);
            var str = "";
            int i = 0;
            Change change = null;
            Item item = null;
            string type = "";
            string result = "";

            while (true)
            {
                str = streamReader.ReadLine();
                if (str == null)
                {
                    switch (type)
                    {
                        case "Summary":
                            item.Summary = result;
                            break;
                        case "Description":
                            item.Description = result;
                            break;
                        case "Purpose":
                            item.Purpose = result;
                            break;
                        case "ChangedFiles":
                            item.ChangedFiles = result;
                            break;
                        case "AddedFiles":
                            item.AddedFiles = result;
                            break;
                    }
                    if (item != null)
                    {
                        change.ItemList.Add(item);
                    }
                    changes.Add(change);
                    break;
                }

                while (string.IsNullOrEmpty(str.Trim()))
                {
                    str = streamReader.ReadLine();
                }
                str = str.Trim();
                var dt_name = str.Split(',');
                if (dt_name.Length == 2)
                {
                    var dt = str.Split(',')[0];
                    if (dt == "12/13/2004")
                    {
                        int x = 0;
                    }
                    var name = str.Split(',')[1];
                    if (dt.Split('/').Length == 3)
                    {
                        if (i > 0)
                        {
                            switch (type)
                            {
                                case "Summary":
                                    item.Summary = result;
                                    break;
                                case "Description":
                                    item.Description = result;
                                    break;
                                case "Purpose":
                                    item.Purpose = result;
                                    break;
                                case "ChangedFiles":
                                    item.ChangedFiles = result;
                                    break;
                                case "AddedFiles":
                                    item.AddedFiles = result;
                                    break;
                            }
                            if (item != null)
                            {
                                change.ItemList.Add(item);
                            }
                            changes.Add(change);
                        }
                        i++;

                        change = new Change();
                        item = null;
                        change.ChangeID = i;
                        change.ChangedDate = dt;
                        change.ChangedBy = name;
                        continue;
                    }
                }
                if (str.StartsWith("*)"))
                { 
                    if (item != null)
                    {
                        switch (type)
                        {
                            case "Summary":
                                item.Summary = result;
                                break;
                            case "Description":
                                item.Description = result;
                                break;
                            case "Purpose":
                                item.Purpose = result;
                                break;
                            case "ChangedFiles":
                                item.ChangedFiles = result;
                                break;
                            case "AddedFiles":
                                item.AddedFiles = result;
                                break;
                        }
                        change.ItemList.Add(item);
                    }

                    item = new Item();
                    type = "Summary";
                    result = str.Replace("*)", "");
                    continue;
                }

                if (str.StartsWith("Description:"))
                {
                    switch (type)
                    {
                        case "Summary":
                            item.Summary = result;
                            break;
                        case "Description":
                            item.Description = result;
                            break;
                        case "Purpose":
                            item.Purpose = result;
                            break;
                        case "ChangedFiles":
                            item.ChangedFiles = result;
                            break;
                        case "AddedFiles":
                            item.AddedFiles = result;
                            break;
                    }
                    type = "Description";
                    result = str.Replace("Description:", "");
                    continue;
                }

                if (str.StartsWith("Purpose:"))
                {
                    switch (type)
                    {
                        case "Summary":
                            item.Summary = result;
                            break;
                        case "Description":
                            item.Description = result;
                            break;
                        case "Purpose":
                            item.Purpose = result;
                            break;
                        case "ChangedFiles":
                            item.ChangedFiles = result;
                            break;
                        case "AddedFiles":
                            item.AddedFiles = result;
                            break;
                    }
                    type = "Purpose";
                    result = str.Replace("Purpose:", "");
                    continue;
                }

                if (str.StartsWith("Changed Files:") || str.StartsWith("Changed files:"))
                {
                    switch (type)
                    {
                        case "Summary":
                            item.Summary = result;
                            break;
                        case "Description":
                            item.Description = result;
                            break;
                        case "Purpose":
                            item.Purpose = result;
                            break;
                        case "ChangedFiles":
                            item.ChangedFiles = result;
                            break;
                        case "AddedFiles":
                            item.AddedFiles = result;
                            break;
                    }
                    type = "ChangedFiles";
                    result = str.Replace("Changed Files:", "").Replace("Changed files:", "");
                    continue;
                }

                if (str.StartsWith("Added Files:") || str.StartsWith("Added files:"))
                {
                    switch (type)
                    {
                        case "Summary":
                            item.Summary = result;
                            break;
                        case "Description":
                            item.Description = result;
                            break;
                        case "Purpose":
                            item.Purpose = result;
                            break;
                        case "ChangedFiles":
                            item.ChangedFiles = result;
                            break;
                        case "AddedFiles":
                            item.AddedFiles = result;
                            break;
                    }
                    type = "AddedFiles";
                    result = str.Replace("Added Files:", "").Replace("Added files:", "");
                    continue;
                }
                result += str;
            }
            streamReader.Close();
        }

        public void SaveParsedData(string saveFile)
        {

            StreamWriter sw = new StreamWriter(saveFile, false);
            foreach (var c in changes)
            {
                sw.WriteLine(c.ToString());
            }
            sw.Close();
        }
    }
}
