using System.Collections.Generic;
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

        public IEnumerable<ThongKeSLMonAnMD> GetListMonAnBanDuoc()
        {
            IEnumerable<ThongKeSLMonAnMD> listMonAnBanDuoc = _unitOfWork.ThucDons.GetListThongKeMonAnMD();
            IEnumerable<HoaDon> listHoaDon = _unitOfWork.HoaDons.GetAll();
            listMonAnBanDuoc = _unitOfWork.HoaDons.GetThongKeSLMonAnBanDuoc(listMonAnBanDuoc, listHoaDon);
            return listMonAnBanDuoc;
        }

        public int GetThongKeTongDoanhThu()
        {
            int tongDoanhThu = 0;
            tongDoanhThu = _unitOfWork.HoaDons.GetThongKeTongDoanhThu();
            return tongDoanhThu;
        }

        public int GetThongKeTongPhieuDatBan()
        {
            int t = 0;
            t = _unitOfWork.PhieuDatBans.GetThongKeTongPhieuDatBan();
            return t;
        }
        public int GetThongKePhieuDatBanBiHuy()
        {
            int t = 0;
            t = _unitOfWork.PhieuDatBans.GetThongKePhieuDatBanBiHuy();
            return t;
        }
        public int GetThongKePhieuDatBanXuLyXong()
        {
            int t = 0;
            t = _unitOfWork.PhieuDatBans.GetThongKePhieuDatBanXuLyXong();
            return t;
        }
        public int GetTongSoBanDuocPhucVu()
        {
            int t = 0;
            t = _unitOfWork.HoaDons.GetTongSoBanAnDuocPhucVu();
            return t;
        }
    }
}