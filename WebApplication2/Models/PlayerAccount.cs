using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{

    public class PlayerAccount
    {

        [Required]
        [Key]
        public string Account_ID { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public bool IsMd5Password { get; set; }
        [Required]

        public bool IsAutoConvertMd5 { get; set; }

    }
}
