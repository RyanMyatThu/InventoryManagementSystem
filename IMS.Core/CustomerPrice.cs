using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class CustomerPrice
    {
        public int CustomerPriceId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int InventoryId { get; set; }
        [Required]
        public decimal SellPrice { get; set; }

        public Customer Customer { get; set; }
        public Inventory Inventory { get; set; }
    }
}
