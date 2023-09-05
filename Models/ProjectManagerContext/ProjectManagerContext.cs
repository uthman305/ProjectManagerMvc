using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Models.ProjectManagerContext
{
    public class ProjectManagerContext : DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=ProjectManager;user=root;password=Uthman!10");
        }
        public DbSet<Project> Projects { get; set; } 
        public DbSet<Role> Roles { get; set; } 
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<TeamMember> TeamMembers { get; set;} 
        public DbSet<TeamMemberProject> TeamMemberProjects { get; set; }
         public DbSet<UserRole> UserRoles { get; set; } 
    }
}