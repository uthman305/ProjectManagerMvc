using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class Task:BaseClass
    {
        public string?  DocumentReference {get;set;}
        public string Description {get;set;}
        public string TeamMemberId {get;set;}
         public string ProjectId {get;set;}
    }
    
}