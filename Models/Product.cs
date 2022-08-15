using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AdminTienda.Models
{
    public partial class Product
    {
        public Product()
        {
            DetailSales = new HashSet<DetailSale>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Code { get; set; }
        public string NameProd { get; set; } = null!;
        public decimal PriceSale { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
        public bool isDelete { get; set; }
        public virtual Category Category { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<DetailSale> DetailSales { get; set; }
    }
}
