using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsBGood.Domain.Entities;

namespace WordsBGood.Domain.Abstract
{
    public interface ICategoryRepository
    {
        //will want to get a list of categories by user
        List<Category> GetCategories(User u);

        //will want to add a category
        void AddCategory(Category c);

        Category GetCategory(string subject);
        void SaveCategory(Category category);
        Category DeleteCategory(int categoryId);
    }
}
