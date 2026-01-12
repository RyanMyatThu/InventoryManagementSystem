using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; }= string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;

        public int TotalItems { get; set; } = 0;

        public bool DeleteFlag { get; set; } = false;
        public ICollection<CustomerPrice> CustomerPrices { get; set; } = new List<CustomerPrice>();
        public ICollection<Reports> Reports { get; set; } = new List<Reports>();
    }
}
