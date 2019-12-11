using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.Specification;
using AutoMapper;
namespace ApplicationCore.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HoaDonServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IEnumerable<HoaDonMD> GetListHoaDonMD(int IdBanAn, string trangThai, int pageIndex, int pageSize, out int count)
        {
            HoaDonSpecification hoaDonSpecFilter = new HoaDonSpecification(IdBanAn, trangThai, pageIndex, pageSize);
            HoaDonSpecification hoaDonSpec = new HoaDonSpecification(IdBanAn, trangThai);
            IEnumerable<HoaDon> hoaDons = _unitOfWork.HoaDons.FindSpec(hoaDonSpecFilter);
            count = _unitOfWork.HoaDons.Count(hoaDonSpec);
            IEnumerable<HoaDonMD> hoaDonMDs = _unitOfWork.HoaDons.GetListHoaDonMD(hoaDons);
            return new PaginatedList<HoaDonMD>(hoaDonMDs, pageIndex, pageSize, count);

        }
        public int Delete(int IdHoaDon)
        {

            int i = _unitOfWork.HoaDons.DeleteAllCTHD(IdHoaDon);
            if (i == 1)
            {
                _unitOfWork.Complete();
                return 1;
            }
            else if (i == 0)
                return 0;
            else
                return -1;


        }

        public void Edit(SaveHoaDonDTO saveHoaDonDTO)
        {
            HoaDon hoaDon = _mapper.Map<SaveHoaDonDTO, HoaDon>(saveHoaDonDTO);
            _unitOfWork.HoaDons.Update(hoaDon);
            _unitOfWork.Complete();
        }
        public HoaDonDTO FindHD(int id)
        {
            HoaDon hoaDon = _unitOfWork.HoaDons.GetById(id);
            if (hoaDon == null)
                return null;
            HoaDonDTO hoaDonDTO = _mapper.Map<HoaDon, HoaDonDTO>(hoaDon);
            return hoaDonDTO;
        }

        public IEnumerable<CTHDMD> DetailsHD(int id)
        {
            var cts = _unitOfWork.HoaDons.GetListCTHD(id);
            IEnumerable<CTHDMD> list = from s in cts
                                       join t in _unitOfWork.ThucDons.GetAll()
                                       on s.IdMonAn equals t.Id
                                       select new CTHDMD
                                       {
                                           IdHoaDon = s.IdHoaDon,
                                           IdMonAn = s.IdMonAn,
                                           TenMonAn = t.Ten,
                                           SoLuong = s.SoLuong,
                                           DonGia = s.DonGia
                                       };
            return list;

        }

        public BanAnDTO FindBanAn(int IdHoaDon)
        {
            BanAn ba = _unitOfWork.HoaDons.FindBanAn(IdHoaDon);
            BanAnDTO banAnDTO = _mapper.Map<BanAn, BanAnDTO>(ba);
            return banAnDTO;
        }

        public IEnumerable<BanAnDTO> GetListBanAn()
        {
            Expression<Func<BanAn, bool>> predicate = s => true;
            predicate = s => s.TrangThai == "Trống";
            IEnumerable<BanAn> list = _unitOfWork.BanAns.Find(predicate);
            IEnumerable<BanAnDTO> listDTO = _mapper.Map<IEnumerable<BanAn>, IEnumerable<BanAnDTO>>(list);
            return listDTO;
        }

        public string GetNameUser(int IdUser)
        {
            NguoiDung user = _unitOfWork.NguoiDungs.GetById(IdUser);
            return user.Ten;
        }
    }
}