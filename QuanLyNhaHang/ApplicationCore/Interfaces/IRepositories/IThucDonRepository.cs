using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IThucDonRepository : IRepository<ThucDon>
    {

        IEnumerable<LoaiMonAn> GetLoaiThucAns();
        IEnumerable<ThucDon> GetClassifiedFoods(IEnumerable<ThucDon> source, string tenL);

        void Update(ThucDon td);

    }
}