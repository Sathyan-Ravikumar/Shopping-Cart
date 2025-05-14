using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Modal.Modal
{
    public class ProductImages
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public bool IsPrimary { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
