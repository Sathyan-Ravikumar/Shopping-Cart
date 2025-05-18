using Products.Modal.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.View_Request_Modals.ViewModal
{
    public class ProductsByProductId
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public string Brand { get; set; }
        public string Subcategory { get; set; }

        public List<ProductImages_ViewModal> Images { get; set; }
    }
}
