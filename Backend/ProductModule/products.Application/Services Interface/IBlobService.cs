using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace products.Application.Services_Interface
{
    public interface IBlobService
    {
        Task<string> UploadImageAsync(IFormFile file);
    }
}
