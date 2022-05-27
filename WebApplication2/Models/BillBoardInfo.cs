using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class BillBoardInfo
    {
        [Key]
        public int PlayerDBID { get; set; }
        public int SortValue { get; set; }
        public int Type { get; set; }
    }
}
