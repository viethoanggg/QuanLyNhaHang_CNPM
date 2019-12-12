using System;
using System.Collections.Generic;
using ApplicationCore.Entities;
using ApplicationCore.ModelsContainData.Models;

namespace ApplicationCore.Interfaces.IRepositories
{
    public interface IThucDonRepository : IRepository<ThucDon>
    {

        IEnumerable<LoaiMonAn> GetLoaiThucAns();
        IEnumerable<ThucDonMD> GetListThucDonMD(IEnumerable<ThucDon> source);
        IEnumerable<ThongKeSLMonAnMD> GetListThongKeMonAnMD();
        void Update(ThucDon td);

    }
}