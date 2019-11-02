using System.Collections.Generic;
using ApplicationCore.Entitites;

namespace ApplicationCore.Interfaces {
    public interface IThucDonRepository : IRepository<ThucDon> {

        IEnumerable<LoaiMonAn> GetLoaiThucAns();
        IEnumerable<ThucDon> GetClassifiedFoods(IEnumerable<ThucDon> source, string tenL);

        void Update(ThucDon td);

    }
}