using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Abstract;
using System.Data.Entity;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Domain.Concrete
{
    public class WordsBGoodDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories {get; set;}
        public DbSet<Vocab> Vocabs { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        
    }

    public class UserRepository: IUserRepository
    {
        //List<User> users = new List<User>();

        //need to add a property for testing purposes
        //public List<User> Users { get { return users; } }
        //need a property to test online user list
       
        public void AddUser(Entities.User user)
        {
            var db = new WordsBGoodDbContext();
            user.Online = false;
            user.Permission = "Registered";
            db.Users.Add(user);
            db.SaveChanges();
        }

        public Entities.User GetUser(string name, string email)
        {
            var db = new WordsBGoodDbContext();
            return (from u in db.Users
                    where u.Name == name && email == u.Email
                    select u).FirstOrDefault();
        }

        public List<Entities.User> GetOnlineUsers()
        {
            var db = new WordsBGoodDbContext();
            List<User> online = (from u in db.Users
                      where u.Online == true
                      select u).ToList<User>();
            return online;
        }

        public void LoginUpdate(User u)
        {
           
            var db = new WordsBGoodDbContext();
            User b = (from a in db.Users
                      where a.UserId == u.UserId
                      select a).FirstOrDefault();
            b.Online = true;
            
            db.SaveChanges();
        }

        public void LogoutUpdate(User u)
        {

            var db = new WordsBGoodDbContext();
            User b = (from a in db.Users
                      where a.UserId == u.UserId
                      select a).FirstOrDefault();
            b.Online = false;

            db.SaveChanges();
        }

        public void SaveUser(User u)
        {
            var db = new WordsBGoodDbContext();
            if (u.UserId == 0)
            {
                db.Users.Add(u);
            }
            else
            {
                User dbEntry = db.Users.Find(u.UserId);
                if (dbEntry != null)
                {
                    dbEntry.Name = u.Name;
                    dbEntry.Email = u.Email;
                    dbEntry.Permission = u.Permission;
                }
            }
            db.SaveChanges();
        }

        public User DeleteUser(int userId)
        {
            var db = new WordsBGoodDbContext();
            User dbEntry = db.Users.Find(userId);
            if (dbEntry != null)
            {
                db.Users.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}
