using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.View_Request_Modals.ViewModal
{
    public class ProductImages_ViewModal
    {
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
