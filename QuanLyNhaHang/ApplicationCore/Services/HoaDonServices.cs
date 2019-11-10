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
using ApplicationCore.ModelsContainData.ViewModels;
using AutoMapper;
namespace ApplicationCore.Services {
    public class HoaDonServices : IHoaDonServices {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HoaDonServices (IUnitOfWork unitOfWork, IMapper mapper) {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public readonly int pageSize = 7;
        public HoaDonVM GetHoaDonVM (int pageIndex) {
            Expression<Func<HoaDon, bool>> predicate = s => true;
            IEnumerable<HoaDon> hoaDons = _unitOfWork.HoaDons.GetAll ();
            IEnumerable<NguoiDung> nguoiDungs = _unitOfWork.NguoiDungs.GetAll ();
            IEnumerable<HoaDonMD> hoaDonMDs = from h in hoaDons
            join nd in nguoiDungs
            on h.IdUser equals nd.Id
            select new HoaDonMD {
                Id = h.Id,
                IdBanAn = h.IdBanAn,
                IdUser = h.IdUser,
                TenNhanVien = nd.Ten,
                ThoiGianLap = h.ThoiGianLap,
                ThoiGianThanhToan = h.ThoiGianThanhToan,
                ThanhTien = h.ThanhTien,
                TrangThai = h.TrangThai
            };

            return new HoaDonVM {
                ListHoaDonMD = PaginatedList<HoaDonMD>.Create (hoaDonMDs, pageIndex, pageSize)
            };
        }
        public void Delete (SaveHoaDonDTO SaveHoaDonDTO) {
            HoaDon HoaDon = _mapper.Map<SaveHoaDonDTO, HoaDon> (SaveHoaDonDTO);
            _unitOfWork.HoaDons.Remove (HoaDon);
            _unitOfWork.Complete ();
        }

        public void Edit (SaveHoaDonDTO saveHoaDonDTO) {
            HoaDon hoaDon = _mapper.Map<SaveHoaDonDTO, HoaDon> (saveHoaDonDTO);
            _unitOfWork.HoaDons.Update (hoaDon);
            _unitOfWork.Complete ();
        }
        public HoaDonDTO FindHD (int id) {
            HoaDon hoaDon = _unitOfWork.HoaDons.GetById (id);
            if (hoaDon == null)
                return null;
            HoaDonDTO hoaDonDTO = _mapper.Map<HoaDon, HoaDonDTO> (hoaDon);
            return hoaDonDTO;
        }

        public HoaDonVM Details (int id) {
            HoaDon hoaDon = _unitOfWork.HoaDons.GetById (id);
            var cts = _unitOfWork.HoaDons.GetListCTHD (id);
            IEnumerable<CTHDMD> list = from s in cts
            join t in _unitOfWork.ThucDons.GetAll ()
            on s.IdMonAn equals t.Id
            select new CTHDMD {
                IdHoaDon = s.IdHoaDon,
                IdMonAn = s.IdMonAn,
                TenMonAn = t.Ten,
                SoLuong = s.SoLuong,
                DonGia = s.DonGia
            };
            return new HoaDonVM {
                HoaDon = _mapper.Map<HoaDon, HoaDonDTO> (hoaDon),
                    ChiTietHoaDonMD = list
            };

        }

        public BanAnDTO FindBanAn (int IdHoaDon) {
            BanAn ba = _unitOfWork.HoaDons.FindBanAn (IdHoaDon);
            BanAnDTO banAnDTO = _mapper.Map<BanAn, BanAnDTO> (ba);
            return banAnDTO;
        }

        public IEnumerable<BanAnDTO> GetListBanAn () {
            Expression<Func<BanAn, bool>> predicate = s => true;
            predicate = s => s.TrangThai == "Trống";
            IEnumerable<BanAn> list = _unitOfWork.BanAns.Find (predicate);
            IEnumerable<BanAnDTO> listDTO = _mapper.Map<IEnumerable<BanAn>, IEnumerable<BanAnDTO>> (list);
            return listDTO;
        }

        public string GetNameUser (int IdUser) {
            NguoiDung user = _unitOfWork.NguoiDungs.GetById (IdUser);
            return user.Ten;
        }
    }
}