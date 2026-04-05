using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Report.Interfaces
{
    public interface IRemoveReportUseCase
    {
        Task<int> ExecuteAsync(int reportId);
    }
}
