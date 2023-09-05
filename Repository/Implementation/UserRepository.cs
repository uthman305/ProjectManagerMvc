using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;
using ProjectManager.Models.ProjectManagerContext;
using ProjectManager.Repository.Interface;

namespace ProjectManager.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ProjectManagerContext _projectManagerContext;
         public UserRepository(ProjectManagerContext projectManagerContext)
        {
            _projectManagerContext = projectManagerContext;
        }
        public User Add(User user)
        {
            _projectManagerContext.Users.Add(user);
            _projectManagerContext.SaveChanges();
            return user;
        }
        public void Delete(User user)
        {
            _projectManagerContext.Users.Remove(user);
            _projectManagerContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _projectManagerContext.Users
            .ToList();
        }

        public User GetUser(string id)
        {
            return _projectManagerContext.Users
             .SingleOrDefault(x => x.Id == id);
        }
         public User GetEmail(string email)
        {
            return _projectManagerContext.Users
             .SingleOrDefault(x => x.Email == email);
        }
         public User GetUserForLogIn( string email, string password)
        {
            return _projectManagerContext.Users
            .SingleOrDefault( x=> x.Email == email && x.PassWord == password);
        }


        public void Update(User user)
        {
            _projectManagerContext.Update(user);
            _projectManagerContext.SaveChanges();
        }
    }
}