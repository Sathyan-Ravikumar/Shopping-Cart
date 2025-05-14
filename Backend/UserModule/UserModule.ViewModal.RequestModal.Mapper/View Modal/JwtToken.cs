using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserModule.ViewModal.RequestModal.Mapper.View_Modal
{
    public class JwtToken
    {
        public string? Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
