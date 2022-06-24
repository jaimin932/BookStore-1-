using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public partial class Ordermst
    {
        public Ordermst()
        {
            Orderdtls = new HashSet<Orderdtl>();
        }

        public int Id { get; set; }
        public int? Userid { get; set; }
        public DateTime? Orderdate { get; set; }
        public decimal? Totalprice { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Orderdtl> Orderdtls { get; set; }
    }
}
