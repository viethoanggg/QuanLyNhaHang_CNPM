using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ApplicationCore.Interfaces.IRepositories;

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
        public IEnumerable<ThucDon> GetClassifiedFoods(IEnumerable<ThucDon> source, string tenL)
        {
            var listL = GetLoaiThucAns();
            var loai = listL.Where(s => s.Ten == tenL).FirstOrDefault();
            var list = from m in source
                       where m.IdLoaiMonAn == loai.Id
                       select m;

            return list.ToList();
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