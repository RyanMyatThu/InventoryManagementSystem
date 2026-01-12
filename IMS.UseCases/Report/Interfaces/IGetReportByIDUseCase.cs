using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Report.Interfaces
{
    public interface IGetReportByIDUseCase
    {
        Task<Reports> ExecuteAsync(int reportId);

    }
}
