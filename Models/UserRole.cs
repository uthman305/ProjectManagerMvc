using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class UserRole :BaseClass
    {
        public string UserId{get; set;}
          public User User{get; set;}
          public string RoleId{get; set;}
          public Role Role{get; set;}
    }
}