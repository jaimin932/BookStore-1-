using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public int Bookid { get; set; }
        public int Quantity { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
