using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class RoleDataBillBoardInfoViewModel
    {
        [Key]
        public int DBID { get; set; }
        public string RoleName { get; set; }
        public int RANK { get; internal set; }
        public int Type { get; internal set; }
        public string TypeName { get; set; }
        public List<BillBoardInfo> BillBoardInfo { get; set; }
    }
}
