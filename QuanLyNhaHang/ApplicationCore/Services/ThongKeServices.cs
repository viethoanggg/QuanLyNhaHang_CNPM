using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class ThongKeServices : IThongKeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ThongKeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public Expression<Func<HoaDon, bool>> GetExpressionHoaDon(DateTime thoiGianTu, DateTime thoiGianDen)
        {
            Expression<Func<HoaDon, bool>> predicate = s => true;
            if (thoiGianTu != null && thoiGianDen != null)
                predicate = s => s.ThoiGianThanhToan >= thoiGianTu && s.ThoiGianThanhToan <= thoiGianDen;
            if (thoiGianTu != null && thoiGianDen == null)
                predicate = s => s.ThoiGianThanhToan >= thoiGianTu;
            if (thoiGianDen != null && thoiGianTu == null)
                predicate = s => s.ThoiGianThanhToan <= thoiGianDen;
            return predicate;
        }
        public Expression<Func<PhieuDatBan, bool>> GetExpressionPhieuDatBan(DateTime thoiGianTu, DateTime thoiGianDen)
        {
            Expression<Func<PhieuDatBan, bool>> predicate = s => true;
            if (thoiGianTu != null && thoiGianDen != null)
                predicate = s => s.ThoiGianDat >= thoiGianTu && s.ThoiGianDat <= thoiGianDen;
            if (thoiGianTu != null && thoiGianDen == null)
                predicate = s => s.ThoiGianDat >= thoiGianTu;
            if (thoiGianDen != null && thoiGianTu == null)
                predicate = s => s.ThoiGianDat <= thoiGianDen;
            return predicate;
        }
        public IEnumerable<ThongKeSLMonAnMD> GetListMonAnBanDuoc(DateTime thoiGianTu, DateTime thoiGianDen)
        {
            Expression<Func<HoaDon, bool>> predicate = GetExpressionHoaDon(thoiGianTu, thoiGianDen);

            IEnumerable<ThongKeSLMonAnMD> listMonAnBanDuoc = _unitOfWork.ThucDons.GetListThongKeMonAnMD();
            IEnumerable<HoaDon> listHoaDon = _unitOfWork.HoaDons.Find(predicate);
            listMonAnBanDuoc = _unitOfWork.HoaDons.GetThongKeSLMonAnBanDuoc(listMonAnBanDuoc, listHoaDon);
            return listMonAnBanDuoc;
        }

        public int GetThongKeTongDoanhThu(DateTime thoiGianTu, DateTime thoiGianDen)
        {
            int tongDoanhThu = 0;
            Expression<Func<HoaDon, bool>> predicate = GetExpressionHoaDon(thoiGianTu, thoiGianDen);
            tongDoanhThu = _unitOfWork.HoaDons.GetThongKeTongDoanhThu(predicate);
            return tongDoanhThu;
        }

        public int GetThongKeTongPhieuDatBan(DateTime thoiGianTu, DateTime thoiGianDen)
        {
            int t = 0;
            Expression<Func<PhieuDatBan, bool>> predicate = GetExpressionPhieuDatBan(thoiGianTu, thoiGianDen);
            t = _unitOfWork.PhieuDatBans.GetThongKeTongPhieuDatBan(predicate);
            return t;
        }
        public int GetThongKePhieuDatBanBiHuy(DateTime thoiGianTu, DateTime thoiGianDen)
        {
            int t = 0;
            Expression<Func<PhieuDatBan, bool>> predicate = GetExpressionPhieuDatBan(thoiGianTu, thoiGianDen);
            t = _unitOfWork.PhieuDatBans.GetThongKePhieuDatBanBiHuy(predicate);
            return t;
        }
        public int GetThongKePhieuDatBanXuLyXong(DateTime thoiGianTu, DateTime thoiGianDen)
        {
            int t = 0;
            Expression<Func<PhieuDatBan, bool>> predicate = GetExpressionPhieuDatBan(thoiGianTu, thoiGianDen);
            t = _unitOfWork.PhieuDatBans.GetThongKePhieuDatBanXuLyXong(predicate);
            return t;
        }
        public int GetTongSoBanDuocPhucVu(DateTime thoiGianTu, DateTime thoiGianDen)
        {
            int t = 0;
            Expression<Func<HoaDon, bool>> predicate = GetExpressionHoaDon(thoiGianTu, thoiGianDen);
            t = _unitOfWork.HoaDons.GetTongSoBanAnDuocPhucVu(predicate);
            return t;
        }
        public int GetThongKePhieuDatBanChuaXuLy(DateTime thoiGianTu, DateTime thoiGianDen)
        {
            int t = 0;
            Expression<Func<PhieuDatBan, bool>> predicate = GetExpressionPhieuDatBan(thoiGianTu, thoiGianDen);
            t = _unitOfWork.PhieuDatBans.GetThongKePhieuDatBanChuaXuLy(predicate);
            return t;
        }
    }
}