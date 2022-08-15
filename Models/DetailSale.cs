using System;
using System.Collections.Generic;

namespace AdminTienda.Models
{
    public partial class DetailSale
    {
        public int Id { get; set; }
        public int IdSale { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual Sale Sale { get; set; } = null!;
    }
}
