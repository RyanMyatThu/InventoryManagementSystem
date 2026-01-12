using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Reports
    {
        [Key] 
        public int ReportId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime ReportDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public decimal Profit { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Vouchers> Vouchers { get; set; } = new List<Vouchers>();
    }
}
