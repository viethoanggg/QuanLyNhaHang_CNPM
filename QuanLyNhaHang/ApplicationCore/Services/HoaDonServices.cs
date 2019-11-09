using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Entitites;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using AutoMapper;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;

namespace ApplicationCore.Services
{
    public class HoaDonServices : IHoaDonServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HoaDonServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public readonly int pageSize = 5;
        public PaginatedList<HoaDonDTO> GetHoaDonVM(int pageIndex)
        {
            Expression<Func<HoaDon, bool>> predicate = s => true;
            IEnumerable<HoaDon> hoaDons = _unitOfWork.HoaDons.GetAll();
            IEnumerable<HoaDonDTO> hoaDonDTOs = _mapper.Map<IEnumerable<HoaDon>, IEnumerable<HoaDonDTO>>(hoaDons);
            return PaginatedList<HoaDonDTO>.Create(hoaDonDTOs, pageIndex, pageSize);
        }
        public void Delete(SaveHoaDonDTO SaveHoaDonDTO)
        {
            HoaDon HoaDon = _mapper.Map<SaveHoaDonDTO, HoaDon>(SaveHoaDonDTO);
            _unitOfWork.HoaDons.Remove(HoaDon);
            _unitOfWork.Complete();
        }

        public HoaDonDTO FindHD(int id)
        {
            HoaDon hoaDon = _unitOfWork.HoaDons.GetById(id);
            if(hoaDon==null)
                return null;
            HoaDonDTO hoaDonDTO = _mapper.Map<HoaDon,HoaDonDTO>(hoaDon);
            return hoaDonDTO;
        }

        public BanAnDTO FindBanAn(int IdHoaDon)
        {
            BanAn ba = _unitOfWork.HoaDons.FindBanAn(IdHoaDon);
            BanAnDTO banAnDTO = _mapper.Map<BanAn,BanAnDTO>(ba);
            return banAnDTO;
        }
    }
}