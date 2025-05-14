using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Modal.Modal
{
    public class ProductReviews
    {
        public int ProductReviewId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public byte Rating { get; set; }
        public string? ReviewText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
