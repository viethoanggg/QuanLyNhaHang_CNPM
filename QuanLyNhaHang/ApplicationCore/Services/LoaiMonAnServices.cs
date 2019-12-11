using System.Linq;
using System.Net.Mime;
using System;
using System.Linq.Expressions;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.Services;
using AutoMapper;
using ApplicationCore.DTOs;
using System.Collections.Generic;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.Specification;

namespace ApplicationCore.Services
{
    public class LoaiMonAnServices : ILoaiMonAnServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        // private readonly int pageSize = 10;
        public LoaiMonAnServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public IEnumerable<LoaiMonAnDTO> GetListLoaiMonAn(string searchString, int pageIndex, int pageSize, out int count)
        {
            LoaiMonAnSpecification LoaiMonAnSpecFilter = new LoaiMonAnSpecification(searchString, pageIndex, pageSize);
            var loaiMonAns = _unitOfWork.LoaiMonAns.FindSpec(LoaiMonAnSpecFilter);
            count = _unitOfWork.LoaiMonAns.Count(new LoaiMonAnSpecification(searchString));

            IEnumerable<LoaiMonAnDTO> loaiMonAnDTOs = _mapper.Map<IEnumerable<LoaiMonAn>, IEnumerable<LoaiMonAnDTO>>(loaiMonAns);
            return loaiMonAnDTOs;
        }

        public LoaiMonAnDTO GetLoaiMonAn(int id)
        {
            LoaiMonAn loaiMonAn = _unitOfWork.LoaiMonAns.GetById(id);
            if (loaiMonAn == null)
            {
                return null;
            }
            LoaiMonAnDTO loaiMonAnDTO = _mapper.Map<LoaiMonAn, LoaiMonAnDTO>(loaiMonAn);
            return loaiMonAnDTO;
        }
        public SaveLoaiMonAnDTO GetSaveLoaiMonAnDTO(int id)
        {
            LoaiMonAnDTO loaiMonAn = GetLoaiMonAn(id);
            if (loaiMonAn == null)
            {
                return null;
            }
            SaveLoaiMonAnDTO saveLoaiMonAnDTO = _mapper.Map<LoaiMonAnDTO, SaveLoaiMonAnDTO>(loaiMonAn);
            return saveLoaiMonAnDTO;
        }
        public void Edit(SaveLoaiMonAnDTO SaveLoaiMonAnDTO)
        {
            if (SaveLoaiMonAnDTO == null)
                return;
            LoaiMonAn loaiMonAn = _mapper.Map<SaveLoaiMonAnDTO, LoaiMonAn>(SaveLoaiMonAnDTO);
            _unitOfWork.LoaiMonAns.Update(loaiMonAn);
            _unitOfWork.Complete();
        }
        public int Delete(int id)
        {
            List<ThucDon> list = _unitOfWork.ThucDons.Find(s => s.IdLoaiMonAn.Equals(id)).ToList();
            if (list.Count() > 0)
                return -1;
            LoaiMonAn loaiMonAn = _unitOfWork.LoaiMonAns.GetById(id);
            _unitOfWork.LoaiMonAns.Remove(loaiMonAn);
            _unitOfWork.Complete();
            return 1;
        }
        public void Create(SaveLoaiMonAnDTO SaveLoaiMonAnDTO)
        {
            if (SaveLoaiMonAnDTO == null)
                return;
            LoaiMonAn loaiMonAn = _mapper.Map<SaveLoaiMonAnDTO, LoaiMonAn>(SaveLoaiMonAnDTO);
            _unitOfWork.LoaiMonAns.Add(loaiMonAn);
            _unitOfWork.Complete();
        }

    }
}