using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Domain.Abstract
{
    public interface IUserRepository
    {
        //want to add a user with the given name
        void AddUser(User user);

        //want to get a user with given name
        User GetUser(string name, string email);

        //want to get a list of users that are currently online
        List<User> GetOnlineUsers();

        void LoginUpdate(User u);

        void LogoutUpdate(User u);

        void SaveUser(User u);
        User DeleteUser(int userId);

    }
}
