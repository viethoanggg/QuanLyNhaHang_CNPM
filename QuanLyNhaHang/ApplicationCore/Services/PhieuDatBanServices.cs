using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.Models;
using ApplicationCore.ModelsContainData.ViewModels;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class PhieuDatBanServices : IPhieuDatBanServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int pageSize = 5;

        public PhieuDatBanServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public PhieuDatBanVM GetPhieuDatBanVM(int pageIndex)
        {
            _unitOfWork.PhieuDatBans.CapNhatAllPhieuDatBan();
            Expression<Func<PhieuDatBan, bool>> predicate = s => true;
            IEnumerable<PhieuDatBan> phieuDatBans = _unitOfWork.PhieuDatBans.Find(predicate);

            IEnumerable<PhieuDatBanMD> phieuDatBanMDs = _unitOfWork.PhieuDatBans.GetListPhieuDatBanMD(phieuDatBans);

            return new PhieuDatBanVM
            {
                PhieuDatBans = PaginatedList<PhieuDatBanMD>.Create(phieuDatBanMDs, pageIndex, pageSize)
            };
        }

        public PhieuDatBanDTO GetById(int Id)
        {
            PhieuDatBan phieu = _unitOfWork.PhieuDatBans.GetById(Id);
            PhieuDatBanDTO phieuDatBanDTO = _mapper.Map<PhieuDatBan, PhieuDatBanDTO>(phieu);
            return phieuDatBanDTO;
        }

        public bool Update(SavePhieuDatBanDTO SavePhieuDatBanDTO)
        {
            PhieuDatBan p = _mapper.Map<SavePhieuDatBanDTO, PhieuDatBan>(SavePhieuDatBanDTO);
            IEnumerable<PhieuDatBan> listp = _unitOfWork.PhieuDatBans.Find(s => s.Id != p.Id && s.TrangThai == "Chưa xử lý");
            DateTime pCong3h = p.ThoiGianDat + new TimeSpan(0, 3, 0, 0);
            foreach (PhieuDatBan phieu in listp)
            {
                TimeSpan aInterval = new System.TimeSpan(0, 3, 0, 0);
                // cộng một khoảng thời gian.
                DateTime ThoiGianPCongThem = phieu.ThoiGianDat.Add(aInterval);

                if (phieu.IdBanAn == p.IdBanAn && ((DateTime.Compare(pCong3h, phieu.ThoiGianDat) >= 0 && DateTime.Compare(pCong3h, ThoiGianPCongThem) <= 0) || (DateTime.Compare(p.ThoiGianDat, ThoiGianPCongThem) <= 0 && DateTime.Compare(p.ThoiGianDat, phieu.ThoiGianDat) >= 0)))
                {
                    return false;
                }

            }

            // cập nhật trạng thái bàn ăn sau khi sửa bàn ăn khác trong phiếu đặt bàn
            // update bàn ăn cũ
            int IdBanAnPhieuCu = _unitOfWork.PhieuDatBans.GetIdBanAn(p.Id);
            BanAn banAnCu = _unitOfWork.BanAns.GetById(IdBanAnPhieuCu);

            banAnCu.TrangThai = "Trống";
            _unitOfWork.BanAns.Update(banAnCu);

            // update bàn ăn mới
            _unitOfWork.PhieuDatBans.UpdateBanAnCuaPhieuDatBanInTimeNow(p);

            _unitOfWork.PhieuDatBans.Update(p);
            _unitOfWork.Complete();

            return true;
        }
        public int Add(SavePhieuDatBanDTO SavePhieuDatBanDTO)
        {
            PhieuDatBan p = _mapper.Map<SavePhieuDatBanDTO, PhieuDatBan>(SavePhieuDatBanDTO);
            int i = _unitOfWork.PhieuDatBans.ThemPhieuDatBan(p);
            if (i == 1)
            {
                _unitOfWork.Complete();
                return 1;
            }
            else if (i == -2)
                return -2;
            else if (i == 0)
                return 0;
            else
                return -1; //trạng thái của bàn là Đang phục vụ


        }

        public void Delete(int id)
        {
            var p = _unitOfWork.PhieuDatBans.GetById(id);
            if (p != null)
            {
                BanAn ban = _unitOfWork.BanAns.GetById(p.IdBanAn);
                if (ban.TrangThai == "Được đặt trước")
                {

                    ban.TrangThai = "Trống";
                    _unitOfWork.BanAns.Update(ban);
                }
                _unitOfWork.PhieuDatBans.Remove(p);
                _unitOfWork.Complete();
            }

        }
        public IEnumerable<BanAnDTO> GetListBanAn()
        {
            Expression<Func<BanAn, bool>> predicate = s => true;
            predicate = s => s.TrangThai == "Trống" || s.TrangThai == "Được đặt trước";
            IEnumerable<BanAn> list = _unitOfWork.BanAns.Find(predicate);
            IEnumerable<BanAnDTO> listDTO = _mapper.Map<IEnumerable<BanAn>, IEnumerable<BanAnDTO>>(list);
            return listDTO;
        }

        public IEnumerable<KhachHang> GetListKH()
        {
            return _unitOfWork.KhachHangs.GetAll();
        }

        public KhachHang GetKhachHang(int IdKhachHang)
        {
            return _unitOfWork.KhachHangs.GetById(IdKhachHang);
        }
    }
}