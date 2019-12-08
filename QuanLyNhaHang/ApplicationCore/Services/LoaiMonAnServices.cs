using System.Net.Mime;
using System;
using System.Linq.Expressions;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.Services;
using AutoMapper;
using ApplicationCore.DTOs;
using System.Collections.Generic;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;

namespace ApplicationCore.Services
{
    public class LoaiMonAnServices : ILoaiMonAnServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int pageSize=10;
        public LoaiMonAnServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public LoaiMonAnVM GetLoaiMonAnVM(int pageIndex=1)
        {
            Expression<Func<LoaiMonAn, bool>> predicate = m => true;
            var loaiMonAns = _unitOfWork.LoaiMonAns.Find(predicate);

            IEnumerable<LoaiMonAnDTO> loaiMonAnDTOs=_mapper.Map<IEnumerable<LoaiMonAn>,IEnumerable<LoaiMonAnDTO>> (loaiMonAns);
            return new LoaiMonAnVM
            {
                LoaiMonAns = PaginatedList<LoaiMonAnDTO>.Create(loaiMonAnDTOs, pageIndex, pageSize)
            };
        }

        public LoaiMonAnDTO GetLoaiMonAn(int id)
        {
            LoaiMonAn loaiMonAn = _unitOfWork.LoaiMonAns.GetById(id);
            if(loaiMonAn==null)
            {
                return null;
            }
            LoaiMonAnDTO loaiMonAnDTO = _mapper.Map<LoaiMonAn, LoaiMonAnDTO>(loaiMonAn);
            return loaiMonAnDTO;
        }
        public void Edit(SaveLoaiMonAnDTO SaveLoaiMonAnDTO)
        {
            LoaiMonAn loaiMonAn = _mapper.Map<SaveLoaiMonAnDTO, LoaiMonAn>(SaveLoaiMonAnDTO);
            _unitOfWork.LoaiMonAns.Update(loaiMonAn);
            _unitOfWork.Complete();
        }
        public void Delete(int id)
        {
            LoaiMonAnDTO loaiMonAnDTO = GetLoaiMonAn(id);
            LoaiMonAn loaiMonAn = _mapper.Map<LoaiMonAnDTO, LoaiMonAn>(loaiMonAnDTO);
            _unitOfWork.LoaiMonAns.Remove(loaiMonAn);
            _unitOfWork.Complete();
        }
        public void Create(SaveLoaiMonAnDTO SaveLoaiMonAnDTO)
        {
            if(SaveLoaiMonAnDTO==null)
                return;
            LoaiMonAn loaiMonAn = _mapper.Map<SaveLoaiMonAnDTO,LoaiMonAn>(SaveLoaiMonAnDTO);
            _unitOfWork.LoaiMonAns.Add(loaiMonAn);
            _unitOfWork.Complete();
        }
    }
}