using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ApplicationCore.Interfaces.IRepositories;
using ApplicationCore.ModelsContainData.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;

namespace Infrastructure.Persistence.Repositories
{
    public class ThucDonRepository : Repository<ThucDon>, IThucDonRepository
    {
        public ThucDonRepository(QLNHContext context) : base(context)
        {

        }

        public IEnumerable<LoaiMonAn> GetLoaiThucAns()
        {

            IEnumerable<LoaiMonAn> list = from t in QLNHContext.LoaiMonAns
                                          orderby t.Ten
                                          select t;

            return list.Distinct().ToList();
        }
        public IEnumerable<ThucDonMD> GetListThucDonMD(IEnumerable<ThucDon> source)
        {

            IEnumerable<ThucDonMD> list = source.Join(QLNHContext.LoaiMonAns, s => s.IdLoaiMonAn, t => t.Id,
                        (s, t) => new ThucDonMD
                        {
                            Id = s.Id,
                            TenLoaiMonAn = t.Ten,
                            Ten = s.Ten,
                            Gia = s.Gia
                        }
            );

            return list;
        }

        public IEnumerable<ThongKeSLMonAnMD> GetListThongKeMonAnMD()
        {
            IEnumerable<ThucDonMD> listMonAnMD = GetListThucDonMD(QLNHContext.ThucDons.ToList());
            IEnumerable<ThongKeSLMonAnMD> listThongKeMonAnMD = listMonAnMD.Where(s => true)
                                                                .Select(s => new ThongKeSLMonAnMD
                                                                {
                                                                    Id = s.Id,
                                                                    TenLoaiMonAn = s.TenLoaiMonAn,
                                                                    Ten = s.Ten,
                                                                    Gia = s.Gia,
                                                                    SoLuongBanDuoc = 0

                                                                });
            return listThongKeMonAnMD;
        }
        public void Update(ThucDon td)
        {
            QLNHContext.Entry(td).State = EntityState.Modified;
        }
        protected QLNHContext QLNHContext
        {
            get { return Context as QLNHContext; }
        }
    }
}