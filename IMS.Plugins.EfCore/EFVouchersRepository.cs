using IMS.CoreBusiness;
using IMS.Plugins.EfCore;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore
{
    public class EFVouchersRepository : IVouchersRepository
    {
        private readonly IMSDbContext _db;
        public EFVouchersRepository(IMSDbContext db)
        {
            _db = db;
        }

        public async Task<Vouchers?> AddVoucher(Vouchers voucher)
        {
            if (voucher is null)
            {
                throw new ArgumentNullException(nameof(voucher), "Voucher cannot be null");
            }
            _db.Vouchers.Add(voucher);
            return await _db.SaveChangesAsync() > 0 ? voucher : null;
        }

        public async Task<int> UpdateVoucher()
        {
            var res = await _db.SaveChangesAsync();
            return res;
        }
    }
}
