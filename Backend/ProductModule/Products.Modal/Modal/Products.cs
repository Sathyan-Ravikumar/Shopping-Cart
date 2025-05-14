﻿namespace Products.Modal.Modal
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public int BrandId { get; set; }
        public int SubcategoryId { get; set; }
    }
}
