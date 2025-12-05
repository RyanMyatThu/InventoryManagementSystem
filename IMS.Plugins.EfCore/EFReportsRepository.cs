using IMS.CoreBusiness;
using IMS.Plugins.EfCore;
using IMS.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class EFReportsRepository : IReportsRepository
    {
        private readonly IMSDbContext _db;

        public EFReportsRepository(IMSDbContext db)
        {
            _db = db;
        }

        public async Task<Reports?> CreateReport(Reports report)
        {
            ArgumentNullException.ThrowIfNull(report);
            _db.Reports.Add(report);
            return await _db.SaveChangesAsync() > 0 ? report : null;
        }

        public async Task<IEnumerable<Reports>> GetAllReports()
        {
            return await _db.Reports.Include(r => r.Customer).ToListAsync();
        }

        public async Task<Reports?> GetReportById(int reportId)
        {
            if(reportId <= 0)
            {
                throw new ArgumentException("Invalid report ID");
            }
            var report = await _db.Reports.Include(r => r.Vouchers).FirstOrDefaultAsync(r => r.ReportId == reportId);
            if (report is null) return null;
            return report;
            
        }

        public async Task<Reports> UpdateTotal(Reports report)
        {
            if(report is null)
            {
                throw new ArgumentNullException("Invalid report ID");
            }
            var existingReport = await _db.Reports.FirstOrDefaultAsync(r => r.ReportId == report.ReportId) ?? throw new Exception("Report not found");
            existingReport.TotalAmount = report.TotalAmount;
            await _db.SaveChangesAsync();
            return existingReport;
        }
    }
}
