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
using ApplicationCore.Specification;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class KhachHangServices : IKhachHangServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int pageSize = 10;
        public KhachHangServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public IEnumerable<KhachHangDTO> GetlistKhachHang(string Ten, string SDT, string DiaChi, int pageIndex, int pageSize, out int count)
        {
            KhachHangSpecification khachHangSpecFilter = new KhachHangSpecification(Ten, SDT, DiaChi, pageIndex, pageSize);
            KhachHangSpecification khachHangSpec = new KhachHangSpecification(Ten, SDT, DiaChi);
            count = _unitOfWork.KhachHangs.Count(khachHangSpec);
            IEnumerable<KhachHang> kh = _unitOfWork.KhachHangs.FindSpec(khachHangSpecFilter);
            IEnumerable<KhachHangDTO> khDTOs = _mapper.Map<IEnumerable<KhachHang>, IEnumerable<KhachHangDTO>>(kh);
            return khDTOs;
        }
        public KhachHangDTO GetKhachHang(int id)
        {
            KhachHang khachHang = _unitOfWork.KhachHangs.GetById(id);
            if (khachHang == null)
            {
                return null;
            }
            KhachHangDTO khachHangDTO = _mapper.Map<KhachHang, KhachHangDTO>(khachHang);
            return khachHangDTO;
        }

        public SaveKhachHangDTO GetSaveKhachHangDTO(int id)
        {
            KhachHangDTO khachHangDTO = GetKhachHang(id);
            if (khachHangDTO == null)
            {
                return null;
            }
            SaveKhachHangDTO saveKhachHangDTO = _mapper.Map<KhachHangDTO, SaveKhachHangDTO>(khachHangDTO);
            return saveKhachHangDTO;
        }
        public void Edit(SaveKhachHangDTO SaveKhachHangDTO)
        {
            KhachHang khachHang = _mapper.Map<SaveKhachHangDTO, KhachHang>(SaveKhachHangDTO);
            _unitOfWork.KhachHangs.Update(khachHang);
            _unitOfWork.Complete();
        }
        public int Delete(int id)
        {
            KhachHangDTO khachHangDTO = GetKhachHang(id);
            KhachHang khachHang = _mapper.Map<KhachHangDTO, KhachHang>(khachHangDTO);
            int i = _unitOfWork.KhachHangs.KiemTraPhieuDatBanCuaKhachHang(id);
            if (i.Equals(-1))
                return -1;
            else if (i.Equals(0))
                return 0;
            _unitOfWork.KhachHangs.Remove(khachHang);
            _unitOfWork.Complete();
            return 1;
        }
        public void Create(SaveKhachHangDTO SaveKhachHangDTO)
        {
            KhachHang khachHang = _mapper.Map<SaveKhachHangDTO, KhachHang>(SaveKhachHangDTO);
            _unitOfWork.KhachHangs.Add(khachHang);
            _unitOfWork.Complete();
        }

    }
}