using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class User:BaseClass
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string PhoneNumber {get;set;}
         [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string? ImageReference {get;set;} 
         public ICollection<UserRole> UserRoles{get; set;}
    }
}