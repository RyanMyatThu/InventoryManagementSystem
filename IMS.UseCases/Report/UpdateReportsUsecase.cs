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
    public class UpdateReportsUsecase : IUpdateReportsUseCase
    {
        private readonly IReportsRepository reportsRepository;
        public UpdateReportsUsecase(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }
        public async Task<int> ExecuteAsync(Reports report)
        {
           return await reportsRepository.UpdateTotal(report);
        }
    }
}
