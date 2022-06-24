﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.ViewModels;
using BookStore.Models.Models;
namespace BookStore.Models.ViewModels
{
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
