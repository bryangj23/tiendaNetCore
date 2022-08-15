﻿namespace AdminTienda.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? Code { get; set; }
        public string NameProd { get; set; } = null!;
        public decimal PriceSale { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; }
    }
}
