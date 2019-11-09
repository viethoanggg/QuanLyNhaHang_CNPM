using System.IO.Enumeration;
using System.Collections;
using System.Linq;
using System;
using System.Linq.Expressions;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuanLyNhaHang.ViewModels;
using System.Collections.Generic;
using QuanLyNhaHang.Models;
using QuanLyNhaHang.Services.Interfaces;

namespace QuanLyNhaHang.Services
{
    public class BanAnServices : IBanAnServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly int pageSize = 10;
        public BanAnServices(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public BanAnVM GetBanAnVM(int pageIndex = 1)
        {
            Expression<Func<BanAn, bool>> predicate = m => true;

            IEnumerable<PhieuDatBan> phieuDatBans = _unitOfWork.PhieuDatBans.GetAll();
            var banDatTruocs = _unitOfWork.BanAns.Find(s => s.TrangThai == "Đã đặt trước");
            var banTrongs = _unitOfWork.BanAns.Find(s => s.TrangThai == "Trống");

            // cập nhật trạng thái bàn đặt trước, nếu qua thời gian quy đinh thì sẽ bị hủy
            TimeSpan aInterval = new System.TimeSpan(0, -1, -30, 0);
            // trừ một khoảng thời gian.
            DateTime day = DateTime.Now;
            day = day.Add(aInterval);

            foreach (BanAn ban in banDatTruocs)
            {
                foreach (PhieuDatBan p in phieuDatBans)
                {
                    if (p.TrangThai == "Chưa xử lý")
                    {
                        int compare = DateTime.Compare(day, p.ThoiGianDat);
                        if (compare > 0 && ban.Id == p.IdBanAn)
                        {
                            ban.TrangThai = "Trống";
                            _unitOfWork.BanAns.Update(ban);
                            p.TrangThai = "Bị hủy";
                            _unitOfWork.PhieuDatBans.Update(p);
                            _unitOfWork.Complete();
                        }
                    }
                }
            }

            // cập nhật trạng thái bàn trống,nếu có người đặt trong khoảng thời gian phục vụ tồi đa
            // thì sẽ cập nhật bàn ăn là dc đặt trước
            aInterval = new System.TimeSpan(0, 3, 0, 0);
            // cộng một khoảng thời gian.
            day = DateTime.Now;
            day = day.Add(aInterval);

            foreach (BanAn ban in banTrongs)
            {
                foreach (PhieuDatBan p in phieuDatBans)
                {
                    if (p.TrangThai == "Chưa xử lý")
                    {
                        int compare = DateTime.Compare(day, p.ThoiGianDat);
                        if (compare > 0 && ban.Id == p.IdBanAn)
                        {
                            ban.TrangThai = "Đã đặt trước";
                            _unitOfWork.BanAns.Update(ban);
                            _unitOfWork.Complete();
                        }
                    }
                }
            }


            var banAns = _unitOfWork.BanAns.Find(predicate);
            return new BanAnVM
            {
                BanAns = PaginatedList<BanAn>.Create(banAns, pageIndex, pageSize)
            };
        }

        public BanAn GetBanAn(int id)
        {
            BanAn banAn = _unitOfWork.BanAns.GetById(id);
            if (banAn == null)
                return null;
            return banAn;
        }
        public void Edit(BanAn banAn)
        {
            _unitOfWork.BanAns.Update(banAn);
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            BanAn banAn = GetBanAn(id);
            _unitOfWork.BanAns.Remove(banAn);
            _unitOfWork.Complete();
        }
        public void Create(BanAn banAn)
        {
            if (banAn == null)
                return;
            _unitOfWork.BanAns.Add(banAn);
            _unitOfWork.Complete();
        }

        public HoaDon CreateBill(HoaDon HoaDon)
        {
            HoaDon hd = HoaDon;
            hd.TrangThai = "Chưa thanh toán";
            SetTrangThaiBanAn(HoaDon.IdBanAn, "Đang phục vụ");
            // SetTrangThaiPhieuDatBan(IdPhieuDatBan);
            _unitOfWork.HoaDons.Add(hd);
            _unitOfWork.Complete();
            return hd;
        }
        public HoaDon FindHD(int IdBanAn)
        {
            IEnumerable<HoaDon> hoaDon = _unitOfWork.HoaDons.Find(s => s.IdBanAn == IdBanAn);
            HoaDon hd = hoaDon.Where(s => s.TrangThai == "Chưa thanh toán").FirstOrDefault();
            return hd;
        }
        public void ThanhToan(HoaDon HoaDon)
        {
            HoaDon.TrangThai = "Đã thanh toán";
            SetTrangThaiBanAn(HoaDon.IdBanAn, "Trống");
            _unitOfWork.HoaDons.Update(HoaDon);
            _unitOfWork.Complete();
        }
        public void SetTrangThaiBanAn(int Id, string trangThai)
        {
            BanAn ba = GetBanAn(Id);
            ba.TrangThai = trangThai;
            _unitOfWork.BanAns.Update(ba);
        }
        public void SetTrangThaiPhieuDatBan(int Id)
        {
            PhieuDatBan p = new PhieuDatBan();
            if (Id == 0)
            {
                TimeSpan aInterval = new System.TimeSpan(0, -3, 0, 0);
                // trừ một khoảng thời gian.
                DateTime day = DateTime.Now;
                day = day.Add(aInterval);
                IEnumerable<PhieuDatBan> phieuDatBans = _unitOfWork.PhieuDatBans.Find(s => s.TrangThai == "Chưa xử lý");
                foreach (PhieuDatBan phieu in phieuDatBans)
                {
                    
                    if (DateTime.Now - phieu.ThoiGianDat <=new TimeSpan(0,3,0,0))
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
            
            if(p.Id!=0)
            {
                p.TrangThai = "Đã xử lý";
                _unitOfWork.PhieuDatBans.Update(p);
            }
            
            
        }
        public IEnumerable<LoaiMonAn> GetListLoaiMonAn()
        {
            return _unitOfWork.LoaiMonAns.GetAll();
        }
        public PaginatedList<ThucDon> GetListMonAn(int? IdLoaiMonAn, int pageIndex = 1)
        {
            Expression<Func<ThucDon, bool>> predicate = s => true;
            IEnumerable<ThucDon> thucDons = _unitOfWork.ThucDons.GetAll();
            if (IdLoaiMonAn != null)
            {
                predicate = s => s.IdLoaiMonAn == IdLoaiMonAn;
                thucDons = _unitOfWork.ThucDons.Find(predicate);
            }
            return PaginatedList<ThucDon>.Create(thucDons, pageIndex, 5);
        }
        public void ThemCTDH(int IdHoaDon, int IdMonAn, int SoLuong)
        {
            _unitOfWork.HoaDons.ThemCTDH(IdHoaDon, IdMonAn, SoLuong);
            _unitOfWork.Complete();
        }

        public IEnumerable<ChiTietHoaDon> GetListCTHD(int IdHoaDon)
        {
            IEnumerable<ChiTietHoaDon> list = _unitOfWork.HoaDons.GetListCTHD(IdHoaDon);
            return list;
        }
        public IEnumerable<CTHDMD> GetListCTHDMD(int IdHoaDon)
        {
            IEnumerable<ChiTietHoaDon> cts = GetListCTHD(IdHoaDon);
            IEnumerable<CTHDMD> list = from s in cts
                                       join t in _unitOfWork.ThucDons.GetAll()
                        on s.IdMonAn equals t.Id
                                       select new CTHDMD
                                       {
                                           IdHoaDon = s.IdHoaDon,
                                           IdMonAn = s.IdMonAn,
                                           TenMonAn = t.Ten,
                                           SoLuong = s.SoLuong.Value,
                                           DonGia = s.DonGia.Value
                                       };

            return list;
        }

        public HoaDon CapNhatThanhTien(HoaDon HoaDon)
        {
            int? tt = _unitOfWork.HoaDons.TongTien(HoaDon.Id);
            HoaDon.ThanhTien = tt.Value;
            _unitOfWork.HoaDons.Update(HoaDon);
            _unitOfWork.Complete();
            return HoaDon;
        }

        public HoaDon GetHDById(int IdHoaDon)
        {
            return (_unitOfWork.HoaDons.GetById(IdHoaDon));

        }
    }

}