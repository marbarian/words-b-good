using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Abstract;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Domain.Concrete
{
    //needs to inherit from IRepository
    public class FakeUserRepository: IUserRepository
    {
        //need to create a fake data store for testing
        List<User> users = new List<User>();
        
        

        //need to add a property for testing purposes
        public List<User> Users { get { return users; } }
        //need a property to test online user list
        List<User> online = new List<User>();
        public List<User> Online { get { return online; } }

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User GetUser(string name, string email)
        {
            return (from u in users
                    where name == u.Name && email == u.Email
                    select u).FirstOrDefault<User>();
        }


        public List<User> GetOnlineUsers()
        {
            online =  (from u in users
                    where u.Online == true
                    select u).ToList<User>();
            return online;
        }


        public void LoginUpdate(User u)
        {
            u.Online = true;
        }
        public void LogoutUpdate(User u)
        {
            u.Online = false;
        }

        public void SaveUser(User u)
        {
            throw new NotImplementedException();
        }


        public User DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
