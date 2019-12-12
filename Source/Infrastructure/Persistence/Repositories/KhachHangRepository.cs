using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.IRepositories;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class KhachHangRepository : Repository<KhachHang>, IKhachHangRepository
    {
        public KhachHangRepository(QLNHContext context) : base(context)
        {

        }
        public int KiemTraPhieuDatBanCuaKhachHang(int IdKhachHang)
        {
            IEnumerable<PhieuDatBan> list = QLNHContext.PhieuDatBans.Where(s => s.IdKhachHang.Equals(IdKhachHang));
            if (list == null)
                return -1;
            if (list.Count() > 0)
                return 0;
            return 1;
        }
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }

        public void Update(KhachHang khachHang)
        {
            QLNHContext.Entry(khachHang).State = EntityState.Modified;
        }

    }
}