using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        [Required]
        public string InventoryName { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }

        public bool DeleteFlag { get; set; } = false;

        public ICollection<CustomerPrice> CustomerPrices { get; set; } = new List<CustomerPrice>();
        public ICollection<Vouchers> Vouchers { get; set; } = new List<Vouchers>();
    }
}
