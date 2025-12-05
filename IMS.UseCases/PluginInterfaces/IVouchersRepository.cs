using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.PluginInterfaces
{
    public interface IVouchersRepository
    {
        Task<Vouchers?> AddVoucher(Vouchers voucher);
        Task<int> UpdateVoucher();


    }
}
