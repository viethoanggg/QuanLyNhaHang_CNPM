using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Specification;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class NguoiDungServices : INguoiDungServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int pageSize = 10;
        public NguoiDungServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public IEnumerable<NguoiDungDTO> GetListNguoiDung(string Ten, string TenDangNhap, string VaiTro, int TrangThai, int pageIndex, int pageSize, out int count)
        {
            NguoiDungSpecification NguoiDungSpecFilter = new NguoiDungSpecification(Ten, TenDangNhap, VaiTro, TrangThai, pageIndex, pageSize);
            NguoiDungSpecification NguoiDungSpec = new NguoiDungSpecification(Ten, TenDangNhap, VaiTro, TrangThai);
            count = _unitOfWork.NguoiDungs.Count(NguoiDungSpec);
            IEnumerable<NguoiDung> nd = _unitOfWork.NguoiDungs.FindSpec(NguoiDungSpecFilter);
            IEnumerable<NguoiDungDTO> ndDTOs = _mapper.Map<IEnumerable<NguoiDung>, IEnumerable<NguoiDungDTO>>(nd);
            return ndDTOs;
        }

        public NguoiDungDTO GetNguoiDung(int id)
        {
            NguoiDung NguoiDung = _unitOfWork.NguoiDungs.GetById(id);
            if (NguoiDung == null)
            {
                return null;
            }
            NguoiDungDTO NguoiDungDTO = _mapper.Map<NguoiDung, NguoiDungDTO>(NguoiDung);
            return NguoiDungDTO;
        }

        public SaveNguoiDungDTO GetSaveNguoiDungDTO(int id)
        {
            NguoiDungDTO NguoiDungDTO = GetNguoiDung(id);
            if (NguoiDungDTO == null)
            {
                return null;
            }
            SaveNguoiDungDTO saveNguoiDungDTO = _mapper.Map<NguoiDungDTO, SaveNguoiDungDTO>(NguoiDungDTO);
            return saveNguoiDungDTO;
        }
        public void Edit(SaveNguoiDungDTO SaveNguoiDungDTO)
        {
            NguoiDung NguoiDung = _mapper.Map<SaveNguoiDungDTO, NguoiDung>(SaveNguoiDungDTO);
            _unitOfWork.NguoiDungs.Update(NguoiDung);
            _unitOfWork.Complete();
        }

        public void Create(SaveNguoiDungDTO SaveNguoiDungDTO)
        {
            NguoiDung NguoiDung = _mapper.Map<SaveNguoiDungDTO, NguoiDung>(SaveNguoiDungDTO);
            _unitOfWork.NguoiDungs.Add(NguoiDung);
            _unitOfWork.Complete();
        }

    }
}