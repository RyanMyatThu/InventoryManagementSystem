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
    public class GetReportByIDUseCase : IGetReportByIDUseCase
    {
        private readonly IReportsRepository _reportsRepository;
        public GetReportByIDUseCase(IReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }
        public async Task<Reports> ExecuteAsync(int reportId)
        {
            return await _reportsRepository.GetReportById(reportId);

        }
    }
}
