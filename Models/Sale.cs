using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AdminTienda.Models
{
    public partial class Sale
    {
        public Sale()
        {
            DetailSales = new HashSet<DetailSale>();
        }

        public int Id { get; set; }
        public int IdClient { get; set; }
        public DateTime DateSale { get; set; }
        public decimal TaxSale { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<DetailSale> DetailSales { get; set; }
    }
}
