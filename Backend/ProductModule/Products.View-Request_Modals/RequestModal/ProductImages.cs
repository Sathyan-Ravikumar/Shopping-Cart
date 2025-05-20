using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Products.View_Request_Modals.RequestModal
{
    public class ProductImages
    {
        public IFormFile ImageFile { get; set; }
        public bool IsPrimary { get; set; }
    }
}
