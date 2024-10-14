using System;
namespace Parser.Entities
{
    public class Item
    {
        public string Summary { get; set; } = string.Empty;
        public string ChangedFiles { get; set; } = string.Empty;
        public string AddedFiles { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public override string ToString()
        {
            return Summary + "|"  + Description
                + "|" + Purpose + "|" + ChangedFiles + "|" + AddedFiles;
        }
    }
}

