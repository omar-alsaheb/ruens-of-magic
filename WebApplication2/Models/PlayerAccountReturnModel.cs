using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication2.Models
{
    [NotMapped]
    public class PlayerAccountReturnModel
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
        public PlayerAccount PlayerAccount { get; set; }
    }
}
