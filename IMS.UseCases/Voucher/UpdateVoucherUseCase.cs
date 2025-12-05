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
    public class UpdateVoucherUseCase : IUpdateVoucherUseCase
    {
        private readonly IVouchersRepository _vouchersRepository;
        public UpdateVoucherUseCase(IVouchersRepository vouchersRepository)
        {
            _vouchersRepository = vouchersRepository;
        }
        public async Task<int> ExecuteAsync()
        {
            return await _vouchersRepository.UpdateVoucher();
        }
    }
}
