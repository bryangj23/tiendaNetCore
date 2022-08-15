using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AdminTienda.Models
{
    public partial class Client
    {
        public Client()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string FirstSurname { get; set; } = null!;
        public string? SecondSurname { get; set; }
        public string TypeDocument { get; set; } = null!;
        public string? NumDocument { get; set; }
        public string? Address { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        [JsonIgnore]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
