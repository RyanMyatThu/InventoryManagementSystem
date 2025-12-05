using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Voucher.Interfaces
{
    public interface IUpdateVoucherUseCase
    {
        Task<int> ExecuteAsync();
    }
}
