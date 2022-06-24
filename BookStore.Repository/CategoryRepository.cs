using BookStore.Models.ViewModels;
using BookStore.Models.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models;

namespace BookStore.Repository
{
    public  class CategoryRepository : BaseRepository
    {
        public ListResponse<Category> GetCategories(int pageIndex, int pagesize, string keyword)
        {
            keyword = keyword?.ToLower().Trim();
            var query = _context.Categories.Where(c => keyword == null || c.Name.ToLower().Contains(keyword)).AsQueryable();
            int totalRecords = query.Count();
            List<Category> categories = query.Skip((pageIndex-1)*pagesize).Take(pagesize).ToList();

            return new ListResponse<Category>()
            {
                Results = categories,
                TotalRecords = totalRecords,
            };
        }
        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }
        public Category AddCategory(Category category)
        {
            var entry = _context.Categories.Add(category);
            return entry.Entity;
        }
        public Category UpdateCategory(Category category)
        {
            var entry = _context.Categories.Update(category);
            return entry.Entity;
        }
        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
                return false;
            
            var entry = _context.Categories.Remove(category);
            return true;
        }

    }
}
