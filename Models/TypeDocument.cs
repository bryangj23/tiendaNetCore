using System;
using System.Collections.Generic;

namespace AdminTienda.Models
{
    public partial class TypeDocument
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
    }
}
