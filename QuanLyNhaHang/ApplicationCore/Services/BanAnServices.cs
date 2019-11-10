using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
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
    public class BanAnServices : IBanAnServices {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int pageSize = 10;
        public BanAnServices (IUnitOfWork unitOfWork, IMapper mapper) {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public BanAnVM GetBanAnVM (int pageIndex = 1) {
            Expression<Func<BanAn, bool>> predicate = m => true;

            IEnumerable<PhieuDatBan> phieuDatBans = _unitOfWork.PhieuDatBans.GetAll ();
            var banDatTruocs = _unitOfWork.BanAns.Find (s => s.TrangThai == "Đã đặt trước");
            var banTrongs = _unitOfWork.BanAns.Find (s => s.TrangThai == "Trống");

            // cập nhật trạng thái bàn đặt trước, nếu qua thời gian quy đinh thì sẽ bị hủy
            TimeSpan aInterval = new System.TimeSpan (0, -1, -30, 0);
            // trừ một khoảng thời gian.
            DateTime day = DateTime.Now;
            day = day.Add (aInterval);

            foreach (BanAn ban in banDatTruocs) {
                foreach (PhieuDatBan p in phieuDatBans) {
                    if (p.TrangThai == "Chưa xử lý") {
                        int compare = DateTime.Compare (day, p.ThoiGianDat);
                        if (compare > 0 && ban.Id == p.IdBanAn) {
                            ban.TrangThai = "Trống";
                            _unitOfWork.BanAns.Update (ban);
                            p.TrangThai = "Bị hủy";
                            _unitOfWork.PhieuDatBans.Update (p);
                            _unitOfWork.Complete ();
                        }
                    }
                }
            }

            // cập nhật trạng thái bàn trống,nếu có người đặt bàn mà chưa tới giờ phục vụ
            // thì trong khoảng thời gian phục vụ tồi đa là 3 tiếng
            // thì sẽ cập nhật bàn ăn là dc đặt trước
           
            aInterval = new System.TimeSpan (0, 3, 0, 0);
            // cộng một khoảng thời gian là 3 tiếng.
            day = DateTime.Now;
            day = day.Add (aInterval);

            foreach (BanAn ban in banTrongs) {
                foreach (PhieuDatBan p in phieuDatBans) {
                    if (p.TrangThai == "Chưa xử lý") {
                        int compare = DateTime.Compare (day, p.ThoiGianDat);
                        if (compare > 0 && ban.Id == p.IdBanAn) {
                            ban.TrangThai = "Đã đặt trước";
                            _unitOfWork.BanAns.Update (ban);
                            _unitOfWork.Complete ();
                        }
                    }
                }
            }

            var banAns = _unitOfWork.BanAns.Find (predicate);
            var banAnsDTO = _mapper.Map<IEnumerable<BanAn>, IEnumerable<BanAnDTO>> (banAns);
            return new BanAnVM {
                BanAns = PaginatedList<BanAnDTO>.Create (banAnsDTO, pageIndex, pageSize)
            };
        }

        public BanAnDTO GetBanAn (int id) {
            var ba = _unitOfWork.BanAns.GetById (id);
            if (ba == null)
                return null;
            return _mapper.Map<BanAn, BanAnDTO> (ba);
        }

        public void Edit (SaveBanAnDTO saveBanAnDTO) {
            BanAn banAn = _mapper.Map<SaveBanAnDTO, BanAn> (saveBanAnDTO);
            _unitOfWork.BanAns.Update (banAn);
            _unitOfWork.Complete ();
        }
        public int Delete (int id) {
            var ba = _unitOfWork.BanAns.GetById (id);
            if (ba != null) {
                if (ba.TrangThai == "Trống") {
                    _unitOfWork.BanAns.Remove (ba);
                    _unitOfWork.Complete ();
                    return 1;
                } else {
                    return 0;
                }
            } else
                return -1;

        }
        public void Create (SaveBanAnDTO saveBanAnDTO) {
            if (saveBanAnDTO == null)
                return;
            BanAn banAn = _mapper.Map<SaveBanAnDTO, BanAn> (saveBanAnDTO);
            _unitOfWork.BanAns.Add (banAn);
            _unitOfWork.Complete ();
        }

        public HoaDonDTO CreateBill (SaveHoaDonDTO SaveHoaDonDTO) {

            HoaDon HoaDon = _mapper.Map<SaveHoaDonDTO, HoaDon> (SaveHoaDonDTO);
            HoaDon.TrangThai = "Chưa thanh toán";
            SetTrangThaiBanAn (HoaDon.IdBanAn, "Đang phục vụ");
            _unitOfWork.HoaDons.Add (HoaDon);
            _unitOfWork.Complete ();
            HoaDonDTO hoaDonDTO = _mapper.Map<HoaDon, HoaDonDTO> (HoaDon);
            return hoaDonDTO;
        }
        public HoaDonDTO FindHD (int IdBanAn) {
            IEnumerable<HoaDon> hoaDon = _unitOfWork.HoaDons.Find (s => s.IdBanAn == IdBanAn);
            HoaDon hd = hoaDon.Where (s => s.TrangThai == "Chưa thanh toán").FirstOrDefault ();
            HoaDonDTO hoaDonDTO = _mapper.Map<HoaDon, HoaDonDTO> (hd);
            return hoaDonDTO;
        }
        public void ThanhToan (int IdHoaDon, int IdUser) {
            HoaDon HoaDon = _unitOfWork.HoaDons.GetById (IdHoaDon);
            HoaDon.TrangThai = "Đã thanh toán";
            System.DateTime day = DateTime.Now;
            HoaDon.ThoiGianThanhToan = Convert.ToDateTime (day);
            HoaDon.IdUser = IdUser;
            SetTrangThaiBanAn (HoaDon.IdBanAn, "Trống");

            _unitOfWork.HoaDons.Update (HoaDon);
            _unitOfWork.Complete ();
        }
        public void SetTrangThaiBanAn (int Id, string trangThai) {
            //BanAnDTO baDTO = GetBanAn(Id);
            var ba = _unitOfWork.BanAns.GetById (Id);
            if (ba != null) {
                ba.TrangThai = trangThai;
                _unitOfWork.BanAns.Update (ba);
            }

        }
        public void SetTrangThaiPhieuDatBan (int Id) {
            PhieuDatBan p = new PhieuDatBan ();
            if (Id == 0) {
                TimeSpan aInterval = new System.TimeSpan (0, -3, 0, 0);
                // trừ một khoảng thời gian.
                DateTime day = DateTime.Now;
                day = day.Add (aInterval);

                IEnumerable<PhieuDatBan> phieuDatBans = _unitOfWork.PhieuDatBans.Find (s => s.TrangThai == "Chưa xử lý");
                foreach (PhieuDatBan phieu in phieuDatBans) {

                    if (DateTime.Now - phieu.ThoiGianDat <= new TimeSpan (0, 3, 0, 0)) {
                        p = phieu;
                        break;
                    }
                }
            } else {
                p = _unitOfWork.PhieuDatBans.GetById (Id);
            }

            if (p.Id != 0) {
                p.TrangThai = "Đã xử lý";
                _unitOfWork.PhieuDatBans.Update (p);
            }

        }
        public IEnumerable<LoaiMonAnDTO> GetListLoaiMonAn () {
            IEnumerable<LoaiMonAn> loaiMonAns = _unitOfWork.LoaiMonAns.GetAll ();
            IEnumerable<LoaiMonAnDTO> loaiMonAnsDTO = _mapper.Map<IEnumerable<LoaiMonAn>, IEnumerable<LoaiMonAnDTO>> (loaiMonAns);
            return loaiMonAnsDTO;
        }
        public PaginatedList<ThucDonDTO> GetListMonAn (int? IdLoaiMonAn, int pageIndex = 1) {
            Expression<Func<ThucDon, bool>> predicate = s => true;
            IEnumerable<ThucDon> thucDons = _unitOfWork.ThucDons.GetAll ();
            if (IdLoaiMonAn != null) {
                predicate = s => s.IdLoaiMonAn == IdLoaiMonAn;
                thucDons = _unitOfWork.ThucDons.Find (predicate);
            }
            IEnumerable<ThucDonDTO> thucDonDTOs = _mapper.Map<IEnumerable<ThucDon>, IEnumerable<ThucDonDTO>> (thucDons);
            return PaginatedList<ThucDonDTO>.Create (thucDonDTOs, pageIndex, 5);
        }
        public void ThemCTDH (int IdHoaDon, int IdMonAn, int SoLuong) {
            _unitOfWork.HoaDons.ThemCTDH (IdHoaDon, IdMonAn, SoLuong);
            _unitOfWork.Complete ();
        }

        public IEnumerable<CTHDMD> GetListCTHDMD (int IdHoaDon) {

            var cts = _unitOfWork.HoaDons.GetListCTHD (IdHoaDon);
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
            return list.ToList ();
        }

        public HoaDonDTO CapNhatThanhTien (int id) {
            HoaDon HoaDon = _unitOfWork.HoaDons.CapNhatTongTien (id);
            _unitOfWork.Complete ();
            HoaDonDTO HoaDonDTO = _mapper.Map<HoaDon, HoaDonDTO> (HoaDon);
            return HoaDonDTO;
        }

        public HoaDon GetHDById (int IdHoaDon) {
            HoaDon hoaDon = _unitOfWork.HoaDons.GetById (IdHoaDon);
            return hoaDon;

        }

    }

}