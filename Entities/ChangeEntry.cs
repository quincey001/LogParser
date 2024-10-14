using System;
namespace Parser.Entities
{
	public class ChangeEntry
	{
        public int ChangeID { get; set; }
        public string ChangedDate { get; set; }
        public string ChangedBy { get; set; }
        public List<string> Summaries { get; set; } = new List<string>();
        public List<string> ChangedFiles { get; set; } = new List<string>();
        public List<string> AddedFiles { get; set; } = new List<string>();
        public List<string> Purpose { get; set; } = new List<string>();
        public List<string> Description { get; set; } = new List<string>();

        public override string ToString()
        {
            return "Change ID:" + ChangeID + "|\n" +
                "Changed Date:" + ChangedDate + "|\n" +
                "Changed By:" + ChangedBy + "|\n" +
                "Summary:" + string.Join(",", Summaries) + "|\n" +
                "Description:" + string.Join("", Description) + "|\n" +
                "Purpose:" + string.Join("", Purpose) + "|\n" +
                "Changed Files:" + string.Join(",", ChangedFiles) + "|\n" +
                "Added Files:" + string.Join(",", AddedFiles) + "|\n";
        }
    }
}

