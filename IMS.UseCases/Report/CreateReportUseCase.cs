using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Report.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Report
{
    public class CreateReportUseCase : ICreateReportUseCase
    {
        private readonly IReportsRepository reportsRepository;
        public CreateReportUseCase(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }   
        public async Task<int> ExecuteAsync(Reports report)
        {
            return (await reportsRepository.CreateReport(report))!.ReportId;

        }
    }
}
