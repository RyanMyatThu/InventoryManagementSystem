using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Voucher.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Voucher
{
    public class AddVoucherUseCase : IAddVoucherUseCase
    {
        private IVouchersRepository _vouchersRepository;
        public AddVoucherUseCase(IVouchersRepository vouchersRepository)
        {
            _vouchersRepository = vouchersRepository;
        }   
        public async Task ExecuteAsync(Vouchers voucher)
        {
            await _vouchersRepository.AddVoucher(voucher);
        }
    }
}
