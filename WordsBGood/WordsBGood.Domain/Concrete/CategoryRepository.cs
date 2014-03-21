using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Abstract;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Domain.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {

        public List<Category> GetCategories(User u)
        {
            //throw new NotImplementedException();

            var db = new WordsBGoodDbContext();
            List<Category> categories = (from c in db.Categories
                                     where c.User.UserId == u.UserId || c.User.UserId == 1
                                     select c).ToList<Category>();
            return categories;
        }

        public void AddCategory(Category c)
        {
            var db = new WordsBGoodDbContext();
            c.User = db.Users.Find(c.User.UserId);
            db.Categories.Add(c);
            db.SaveChanges();
        }


        public Category GetCategory(string subject)
        {
            var db = new WordsBGoodDbContext();
            return (from c in db.Categories
                    where c.Subject == subject
                    select c).FirstOrDefault();
        }


        public void SaveCategory(Category category)
        {
            var db = new WordsBGoodDbContext();
            if (category.CategoryId == 0)
            {
                db.Categories.Add(category);
            }
            else
            {
                Category dbEntry = db.Categories.Find(category.CategoryId);
                if (dbEntry != null)
                {
                    dbEntry.Subject = category.Subject;
                }
            }
            db.SaveChanges();
        }


        public Category DeleteCategory(int categoryId)
        {
            var db = new WordsBGoodDbContext();
            Category dbEntry = db.Categories.Find(categoryId);
            if (dbEntry != null)
            {
                db.Categories.Remove(dbEntry);
                db.SaveChanges();
            }
            return dbEntry;
        }
    }
}
