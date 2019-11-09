using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using AutoMapper;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;

namespace ApplicationCore.Services
{
    public class PhieuDatBanServices : IPhieuDatBanServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int pageSize = 5;

        public PhieuDatBanServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public PhieuDatBanVM GetPhieuDatBanVM(int pageIndex)
        {
            Expression<Func<PhieuDatBan, bool>> predicate=s=>true;
            DateTime day = DateTime.Now;
            
            // trừ 1 giờ 30 phút
            TimeSpan aInterval = new System.TimeSpan(0, -1,-30, 0);
            // trừ một khoảng thời gian.
            day = day.Add(aInterval);

            IEnumerable<PhieuDatBan> phieuDatBans = _unitOfWork.PhieuDatBans.Find(predicate);
            foreach(PhieuDatBan p in phieuDatBans)
            {
                if(p.TrangThai=="Chưa xử lý")
                {
                    int compare = DateTime.Compare(day, p.ThoiGianDat);
                    //nếu quá 1h30 so với thời gian đặt thì sẽ bị hủy
                    if (compare > 0)
                    {
                        p.TrangThai = "Bị hủy";
                        BanAn b = _unitOfWork.BanAns.GetById(p.IdBanAn);
                        b.TrangThai = "Trống";
                        _unitOfWork.BanAns.Update(b);
                        _unitOfWork.PhieuDatBans.Update(p);
                        _unitOfWork.Complete();
                    }
                }
                
            }

            IEnumerable<PhieuDatBanDTO> phieuDatBanDTOs = _mapper.Map<IEnumerable<PhieuDatBan>, IEnumerable<PhieuDatBanDTO>>(phieuDatBans);
            return new PhieuDatBanVM
            {
                PhieuDatBans = PaginatedList<PhieuDatBanDTO>.Create(phieuDatBanDTOs, pageIndex, pageSize)
            };
        }

        public PhieuDatBanDTO GetById(int Id)
        {
            PhieuDatBan phieu= _unitOfWork.PhieuDatBans.GetById(Id);
            PhieuDatBanDTO phieuDatBanDTO = _mapper.Map<PhieuDatBan,PhieuDatBanDTO>(phieu);
            return phieuDatBanDTO;
        }

        public void Update(SavePhieuDatBanDTO SavePhieuDatBanDTO)
        {
            PhieuDatBan p = _mapper.Map<SavePhieuDatBanDTO, PhieuDatBan>(SavePhieuDatBanDTO);
            _unitOfWork.PhieuDatBans.Update(p);
            _unitOfWork.Complete();
        }
        public int Add(SavePhieuDatBanDTO SavePhieuDatBanDTO)
        {
            PhieuDatBan p = _mapper.Map<SavePhieuDatBanDTO, PhieuDatBan>(SavePhieuDatBanDTO);
            BanAn ba = _unitOfWork.BanAns.GetById(p.IdBanAn);
            KhachHang kh = _unitOfWork.KhachHangs.GetById(p.IdKhachHang);
            if(kh==null)
                return -2;
            if(ba.TrangThai=="Trống")
            {
                ba.TrangThai = "Được đặt trước";
                _unitOfWork.BanAns.Update(ba);
                p.TrangThai = "Chưa xử lý";
                _unitOfWork.PhieuDatBans.Add(p);
                _unitOfWork.Complete();
                return 1;
            }
            else if (ba.TrangThai == "Được đặt trước")
            {
                return 0;
            }
            else
                return -1;  //trạng thái của bàn là Đang phục vụ
        }

        public void Delete(int id)
        {
            var p = _unitOfWork.PhieuDatBans.GetById(id);
            if(p!=null)
            {
                _unitOfWork.PhieuDatBans.Remove(p);
                _unitOfWork.Complete();
            }
           
        }
        public IEnumerable<BanAnDTO> GetListBanAn()
        {
            Expression<Func<BanAn, bool>> predicate = s =>true;
            predicate = s => s.TrangThai == "Trống";
            IEnumerable<BanAn> list = _unitOfWork.BanAns.Find(predicate);
            IEnumerable<BanAnDTO> listDTO = _mapper.Map<IEnumerable<BanAn>,IEnumerable<BanAnDTO>>(list);
            return listDTO;
        }
    }
}