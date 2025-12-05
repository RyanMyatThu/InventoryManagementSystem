using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Vouchers
    {
        [Key]
        public int VoucherId { get; set; }
        [Required]
        public int ReportId { get; set; }
        [Required]
        public int InventoryId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal SellPrice { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        public Reports Report { get; set; }
        public Inventory Inventory { get; set; }
    }
}
