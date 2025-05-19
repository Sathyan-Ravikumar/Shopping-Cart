using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.View_Request_Modals.ViewModal
{
    public class AllActiveProducts
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public bool IsActive { get; set; }

        public string? PrimaryImage { get; set; } 

        public string Brand { get; set; }

        public string Subcategory { get; set; }
    }
}
