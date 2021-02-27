using System.ComponentModel.DataAnnotations;

namespace backend.Models{
    public class User{
        [Key]
        public long Id {get; set;}

        
        [Required(ErrorMessage = "Required field")]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name {get; set;}

        [MaxLength(80)]
        public string UserName {get; set;}
        
        [Required]
        [MaxLength(200)]
        public string Email {get; set;}

        [Required]
        [MinLength(6)]
        public string Password {get; set;}
    }

}