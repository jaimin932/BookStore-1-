using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.DataModels
{
    public class CategoryModel
    {
        public CategoryModel(Category category)
        {
            CategoryId = category.CategoryId;
            Name = category.Name;
        }
         
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
