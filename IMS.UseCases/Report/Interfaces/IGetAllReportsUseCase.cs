using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness;
namespace IMS.UseCases.Report.Interfaces
{
    public interface IGetAllReportsUseCase 
    {
        Task<IEnumerable<Reports>> ExecuteAsync();
    }
}
