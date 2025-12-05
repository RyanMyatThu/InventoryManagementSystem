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
    public class GetAllReportsUseCase : IGetAllReportsUseCase
    {
        private IReportsRepository reportsRepository;
        public GetAllReportsUseCase(IReportsRepository reportsRepository)
        {
            this.reportsRepository = reportsRepository;
        }

        public async Task<IEnumerable<Reports>> ExecuteAsync()
        {
            return await reportsRepository.GetAllReports();
        }
    }
}
