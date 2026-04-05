using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Report.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Report
{
    public class RemoveReportUseCase : IRemoveReportUseCase
    {
        private readonly IReportsRepository reportsRepository;
        public RemoveReportUseCase(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }
        public async Task<int> ExecuteAsync(int reportId)
        {
            return await reportsRepository.RemoveReport(reportId);
        }
    }
}
