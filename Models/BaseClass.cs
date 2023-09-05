using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public abstract class BaseClass
    {
        public string  Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DateCreated {get;set;}=  DateTime.Now;
        public bool IsDeleted {get;set;} = false;
    }
}