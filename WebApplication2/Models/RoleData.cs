using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class RoleData
    {
        [Key]
        public int DBID { get; set; }
        public string Account_ID { get; set; }
        public string RoleName { get; set; }
    }
}
