using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Abstract;
using WordsBGood.Domain.Entities;


namespace WordsBGood.Domain.Concrete
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        List<Category> categories = new List<Category>();

        //need to add a property for testing purposes
        public List<Category> Categories { get { return categories; } }
        

        public List<Entities.Category> GetCategories(Entities.User u)
        {
            return (from c in categories
                    where c.User.UserId == u.UserId
                    select c).ToList<Category>();
        }

        public void AddCategory(Category c)
        {
            categories.Add(c);
        }


        public Entities.Category GetCategory(string subject)
        {
            return (from c in categories
                    where c.Subject == subject
                    select c).FirstOrDefault();
        }


        public void SaveCategory(Category category)
        {
            throw new NotImplementedException();
        }


        public Category DeleteCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
