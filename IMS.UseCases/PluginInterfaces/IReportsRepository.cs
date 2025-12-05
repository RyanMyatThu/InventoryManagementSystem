using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IReportsRepository
    {
        Task<IEnumerable<Reports>> GetAllReports();
        Task<Reports?> CreateReport(Reports report);
        Task<Reports?> GetReportById(int reportId);
        Task<Reports> UpdateTotal(Reports report);
    }
}
