using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.Repository.Interface
{
    public interface IUserRepository
    {
        User Add(User user);
        void Delete(User user);
        List<User> GetAll();
        User GetUser(string id);
        User GetEmail(string email);
        User GetUserForLogIn( string email, string password);
        void Update(User user);
    }
}