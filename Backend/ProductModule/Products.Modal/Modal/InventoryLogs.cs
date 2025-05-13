using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Modal.Modal
{
    public class InventoryLogs
    {
        public int InventoryLogId { get; set; }
        public int ProductId { get; set; }
        public int ChangeQty { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
