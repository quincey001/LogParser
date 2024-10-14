using System;
using Parser.Entities;
using Parser.Interfaces;
using System.Text.RegularExpressions;

namespace Parser
{
	public class AnotherChangeParser : IParser
	{
        List<ChangeEntry> changes = new List<ChangeEntry>();

        // Helper function to reset all flags at once
        private static void ResetFlags(ref bool inSummary, ref bool inChangedFiles, ref bool inPurpose, ref bool inDescription, ref bool inAddedFiles, ref bool inComments)
        {
            inSummary = inChangedFiles = inPurpose = inDescription = inAddedFiles = inComments = false;
        }


        public void Parse(string filePath)
		{
			// read all lines from the file
			try
			{
				string content = File.ReadAllText(filePath);
                string pattern = @"(?<date>\d{2}/\d{2}/\d{4}), (?<author>\w+)\s+(?<content>(?:(?!\d{2}/\d{2}/\d{4}, \w+).)*)";

                MatchCollection matches = Regex.Matches(content, pattern, RegexOptions.Singleline);
                Console.WriteLine(matches.Count);
                int change_id = 0;
                

                foreach (Match item in matches)
				{
                    ChangeEntry change = new ChangeEntry();
                    change_id += 1;
                    change.ChangeID = change_id;
                    change.ChangedDate = item.Groups["date"].ToString();
                    change.ChangedBy = item.Groups["author"].ToString();


                    //Console.WriteLine(item.Groups["content"].ToString() + "\n------------------------");
                    string[] lines = item.Groups["content"].ToString().Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                    // Flags for sections
                    bool inSummary = false, inChangedFiles = false, inPurpose = false, inDescription = false, inAddedFiles = false, inComments = false;

                    foreach (string line in lines)
                    {
                        string trimmedLine = line.Trim();

                        // Detect section headers
                        if (trimmedLine.StartsWith("*)"))
                        {
                            ResetFlags(ref inSummary, ref inChangedFiles, ref inPurpose, ref inDescription, ref inAddedFiles, ref inComments);
                            inSummary = true;
                            change.Summaries.Add(trimmedLine.Split(new string[] { "*)" }, StringSplitOptions.None)[1].Trim());
                            continue;
                        }

                        if (trimmedLine.StartsWith("Changed Files:", StringComparison.OrdinalIgnoreCase))
                        {
                            ResetFlags(ref inSummary, ref inChangedFiles, ref inPurpose, ref inDescription, ref inAddedFiles, ref inComments);
                            inChangedFiles = true;
                            change.ChangedFiles.Add(trimmedLine.Split(':')[1].Trim());
                            continue;
                        }

                        if (trimmedLine.StartsWith("Purpose:", StringComparison.OrdinalIgnoreCase))
                        {
                            ResetFlags(ref inSummary, ref inChangedFiles, ref inPurpose, ref inDescription, ref inAddedFiles, ref inComments);
                            inPurpose = true;
                            continue;
                        }

                        if (trimmedLine.StartsWith("Description:", StringComparison.OrdinalIgnoreCase))
                        {
                            ResetFlags(ref inSummary, ref inChangedFiles, ref inPurpose, ref inDescription, ref inAddedFiles, ref inComments);
                            inDescription = true;
                            continue;
                        }

                        if (trimmedLine.StartsWith("Added Files:", StringComparison.OrdinalIgnoreCase))
                        {
                            ResetFlags(ref inSummary, ref inChangedFiles, ref inPurpose, ref inDescription, ref inAddedFiles, ref inComments);
                            inAddedFiles = true;
                            change.AddedFiles.Add(trimmedLine.Split(':')[1].Trim());
                            continue;
                        }

                        // Skip the Comments section
                        if (trimmedLine.StartsWith("Comments:", StringComparison.OrdinalIgnoreCase))
                        {
                            ResetFlags(ref inSummary, ref inChangedFiles, ref inPurpose, ref inDescription, ref inAddedFiles, ref inComments);
                            inComments = true;
                            continue;
                        }

                        // Collect content for sections
                        if (inSummary) change.Summaries.Add(trimmedLine);
                        else if (inChangedFiles) change.ChangedFiles.Add(trimmedLine);
                        else if (inPurpose) change.Purpose.Add(trimmedLine);
                        else if (inDescription) change.Description.Add(trimmedLine);
                        else if (inAddedFiles) change.AddedFiles.Add(trimmedLine);
                        else if (inComments) continue;
                    }

                    // Output the parsed data without Comments
                    Console.WriteLine(change.ToString());
                    changes.Add(change);

                }
			}
			catch (FileLoadException e)
			{
                Console.WriteLine("Error: File not found. Please check the path.");
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while reading the file.");
                Console.WriteLine(e.Message);
            }
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

