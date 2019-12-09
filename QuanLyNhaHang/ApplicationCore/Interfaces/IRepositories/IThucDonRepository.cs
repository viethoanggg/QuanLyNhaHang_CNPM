using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.Models;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IThucDonRepository : IRepository<ThucDon>
    {

        IEnumerable<LoaiMonAn> GetLoaiThucAns();
        IEnumerable<ThucDonMD> GetListThucDonMD(IEnumerable<ThucDon> source);

        void Update(ThucDon td);

    }
}