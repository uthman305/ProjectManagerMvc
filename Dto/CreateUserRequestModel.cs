using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Dto
{
    public class CreateUserRequestModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed in the name.")]
        public string FirstName { get; set; }
         [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed in the name.")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]$",ErrorMessage ="Invalid email error")]
        public string Email { get; set; }
        public string PassWord { get; set; }
        public IFormFile FormFile { get; set; }
    }
}