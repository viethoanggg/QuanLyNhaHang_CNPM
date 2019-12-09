using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Specification;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class BanAnServices : IBanAnServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int pageSize = 10;
        public BanAnServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public BanAnVM GetBanAnVM(string trangThai, int pageIndex = 1)
        {
            BanAnSpecification banAnSpecFilter = new BanAnSpecification(trangThai, pageIndex, pageSize);
            BanAnSpecification banAnSpec = new BanAnSpecification(trangThai);
            int count = _unitOfWork.BanAns.Count(banAnSpec);
            var banAns = _unitOfWork.BanAns.FindSpec(banAnSpecFilter);
            _unitOfWork.BanAns.BanAn_Load();

            var banAnsDTO = _mapper.Map<IEnumerable<BanAn>, IEnumerable<BanAnDTO>>(banAns);
            return new BanAnVM
            {
                BanAns = new PaginatedList<BanAnDTO>(banAnsDTO, pageIndex, pageSize, count)
            };
        }

        public BanAnDTO GetBanAn(int id)
        {
            var ba = _unitOfWork.BanAns.GetById(id);
            if (ba == null)
                return null;
            return _mapper.Map<BanAn, BanAnDTO>(ba);
        }

        public void Edit(SaveBanAnDTO saveBanAnDTO)
        {
            BanAn banAn = _mapper.Map<SaveBanAnDTO, BanAn>(saveBanAnDTO);
            _unitOfWork.BanAns.Update(banAn);
            _unitOfWork.Complete();
        }
        public int Delete(int id)
        {
            var ba = _unitOfWork.BanAns.GetById(id);
            if (ba != null)
            {
                if (ba.TrangThai == "Trống")
                {
                    _unitOfWork.BanAns.Remove(ba);
                    _unitOfWork.Complete();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
                return -1;

        }
        public void Create(SaveBanAnDTO saveBanAnDTO)
        {
            if (saveBanAnDTO == null)
                return;
            BanAn banAn = _mapper.Map<SaveBanAnDTO, BanAn>(saveBanAnDTO);
            _unitOfWork.BanAns.Add(banAn);
            _unitOfWork.Complete();
        }

        public HoaDonDTO CreateBill(SaveHoaDonDTO SaveHoaDonDTO)
        {

            HoaDon HoaDon = _mapper.Map<SaveHoaDonDTO, HoaDon>(SaveHoaDonDTO);
            HoaDon.TrangThai = "Chưa thanh toán";
            SetTrangThaiBanAn(HoaDon.IdBanAn, "Đang phục vụ");
            _unitOfWork.HoaDons.Add(HoaDon);
            _unitOfWork.Complete();
            HoaDonDTO hoaDonDTO = _mapper.Map<HoaDon, HoaDonDTO>(HoaDon);
            return hoaDonDTO;
        }
        public HoaDonDTO FindHD(int IdBanAn)
        {
            IEnumerable<HoaDon> hoaDon = _unitOfWork.HoaDons.Find(s => s.IdBanAn == IdBanAn);
            HoaDon hd = hoaDon.Where(s => s.TrangThai == "Chưa thanh toán").FirstOrDefault();
            HoaDonDTO hoaDonDTO = _mapper.Map<HoaDon, HoaDonDTO>(hd);
            return hoaDonDTO;
        }
        public void ThanhToan(int IdHoaDon, int IdUser)
        {
            HoaDon HoaDon = _unitOfWork.HoaDons.GetById(IdHoaDon);
            HoaDon.TrangThai = "Thanh toán xong";
            System.DateTime day = DateTime.Now;
            HoaDon.ThoiGianThanhToan = Convert.ToDateTime(day);
            HoaDon.IdUser = IdUser;
            SetTrangThaiBanAn(HoaDon.IdBanAn, "Trống");

            _unitOfWork.HoaDons.Update(HoaDon);
            _unitOfWork.Complete();
        }
        public void SetTrangThaiBanAn(int Id, string trangThai)
        {
            //BanAnDTO baDTO = GetBanAn(Id);
            var ba = _unitOfWork.BanAns.GetById(Id);
            if (ba != null)
            {
                ba.TrangThai = trangThai;
                _unitOfWork.BanAns.Update(ba);
            }

        }
        public void SetTrangThaiPhieuDatBan(int Id)
        {
            // update phiếu đặt bàn thành xử lý xong nếu có phiếu đặt bàn đặt cho bàn được chọn khi bấm phục vụ
            PhieuDatBan p = new PhieuDatBan();
            if (Id == 0)
            {

                IEnumerable<PhieuDatBan> phieuDatBans = _unitOfWork.PhieuDatBans.Find(s => s.TrangThai == "Chưa xử lý");
                foreach (PhieuDatBan phieu in phieuDatBans)
                {

                    if (DateTime.Compare(DateTime.Now, phieu.ThoiGianDat) >= 0 && DateTime.Compare(DateTime.Now, phieu.ThoiGianDat + new TimeSpan(0, 1, 30, 0)) <= 0)
                    {
                        p = phieu;
                        break;
                    }
                }
            }
            else
            {
                p = _unitOfWork.PhieuDatBans.GetById(Id);
            }

            if (p.Id != 0)
            {
                p.TrangThai = "Xử lý xong";
                _unitOfWork.PhieuDatBans.Update(p);
            }

        }
        public IEnumerable<LoaiMonAnDTO> GetListLoaiMonAn()
        {
            IEnumerable<LoaiMonAn> loaiMonAns = _unitOfWork.LoaiMonAns.GetAll();
            IEnumerable<LoaiMonAnDTO> loaiMonAnsDTO = _mapper.Map<IEnumerable<LoaiMonAn>, IEnumerable<LoaiMonAnDTO>>(loaiMonAns);
            return loaiMonAnsDTO;
        }
        public PaginatedList<ThucDonDTO> GetListMonAn(int? IdLoaiMonAn, int pageIndex = 1)
        {
            Expression<Func<ThucDon, bool>> predicate = s => true;
            IEnumerable<ThucDon> thucDons = _unitOfWork.ThucDons.GetAll();
            if (IdLoaiMonAn != null)
            {
                predicate = s => s.IdLoaiMonAn == IdLoaiMonAn;
                thucDons = _unitOfWork.ThucDons.Find(predicate);
            }
            IEnumerable<ThucDonDTO> thucDonDTOs = _mapper.Map<IEnumerable<ThucDon>, IEnumerable<ThucDonDTO>>(thucDons);
            return PaginatedList<ThucDonDTO>.Create(thucDonDTOs, pageIndex, 5);
        }
        public async Task ThemCTHD(int IdHoaDon, int IdMonAn, int SoLuong)
        {
            await _unitOfWork.HoaDons.ThemCTHD(IdHoaDon, IdMonAn, SoLuong);
            _unitOfWork.Complete();
        }

        public IEnumerable<CTHDMD> GetListCTHDMD(int IdHoaDon)
        {
            IEnumerable<CTHDMD> list = _unitOfWork.HoaDons.GetListCTHDMD(IdHoaDon);
            return list.ToList();
        }

        public HoaDonDTO CapNhatThanhTien(int id)
        {
            HoaDon HoaDon = _unitOfWork.HoaDons.CapNhatTongTien(id);
            _unitOfWork.Complete();
            HoaDonDTO HoaDonDTO = _mapper.Map<HoaDon, HoaDonDTO>(HoaDon);
            return HoaDonDTO;
        }

        public HoaDon GetHDById(int IdHoaDon)
        {
            HoaDon hoaDon = _unitOfWork.HoaDons.GetById(IdHoaDon);
            return hoaDon;

        }

        public ThucDon GetMonAn(int IdMonAn)
        {
            return _unitOfWork.ThucDons.GetById(IdMonAn);
        }

        public void DeleteCTHD(int IdHoaDon, int IdMonAn)
        {
            _unitOfWork.HoaDons.DeleteCTHD(IdHoaDon, IdMonAn);
            _unitOfWork.Complete();
        }
    }

}