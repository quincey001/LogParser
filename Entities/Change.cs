using System;
namespace Parser.Entities
{
    public class Change
    {
        public int ChangeID { get; set; }
        public string ChangedDate { get; set; }
        public string ChangedBy { get; set; }
        public List<Item> ItemList { get; set; }

        public Change()
        {
            ItemList = new List<Item>();
        }

        public override string ToString()
        {
            var str = ChangeID + "|" + ChangedDate + "|" +  ChangedBy + "|";
            foreach (var item in ItemList)
            {
                str += item.ToString();
            }
            return str + "\n";
        }
    }
}

