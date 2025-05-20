using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.View_Request_Modals.RequestModal
{
    public class AddNewProduct_RequestModal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
        public int BrandId { get; set; }
        public int SubcategoryId { get; set; }
        public List<ProductImages> Images { get; set; }
    }
}
