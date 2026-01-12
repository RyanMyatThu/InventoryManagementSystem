using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS.WebApp.Models
{
    public class ReportViewModel
    {
        public Guid Id { get; set; }

        public string ReportNumber { get; set; } = string.Empty;

        public DateTime Date { get; set; } = DateTime.Today;

        public string CustomerName { get; set; } = string.Empty;

        public string CustomerAddress { get; set; } = string.Empty;

        public string CreatedBy { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        public decimal Tax { get; set; }

        public List<ReportItemViewModel> Items { get; set; } = new();

        // Calculated fields convenient for UI
        public decimal Subtotal => Items?.Sum(i => i.LineTotal) ?? 0m;

        public decimal Total => Subtotal + Tax;
    }

    public class ReportItemViewModel
    {
        public Guid? InventoryId { get; set; }

        public string Description { get; set; } = string.Empty;

        public decimal Quantity { get; set; }

        public string Unit { get; set; } = string.Empty;

        public decimal UnitPrice { get; set; }

        public decimal LineTotal => Quantity * UnitPrice;
    }
}