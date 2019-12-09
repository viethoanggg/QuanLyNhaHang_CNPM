using System.Linq;
using System;
using System.Linq.Expressions;
using ApplicationCore.Interfaces;

using System.Collections.Generic;
using ApplicationCore.Interfaces.IServices;
using ApplicationCore.ModelsContainData.ViewModels;
using ApplicationCore.ModelsContainData.Models;
using AutoMapper;
using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using ApplicationCore.Specification;

namespace ApplicationCore.Services
{
    public class ThucDonServices : IThucDonServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        // private readonly int pageSize = 5;
        public ThucDonServices(IUnitOfWork unitofwork, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
        }
        public IEnumerable<ThucDonMD> GetListThucDonMD(string searchString, int giaTu, int giaDen, int pageIndex, int pageSize, out int count)
        {
            ThucDonSpecification thucDonSpecFilter = new ThucDonSpecification(searchString, giaTu, giaDen, pageIndex, pageSize);
            ThucDonSpecification thucDonSpec = new ThucDonSpecification(searchString, giaTu, giaDen);
            count = _unitOfWork.ThucDons.Count(thucDonSpec);

            var thucDons = _unitOfWork.ThucDons.FindSpec(thucDonSpecFilter);
            IEnumerable<ThucDonMD> listThucDonMD = _unitOfWork.ThucDons.GetListThucDonMD(thucDons);
            return listThucDonMD;

        }

        public IEnumerable<LoaiMonAnDTO> GetLoaiMonAns()
        {
            IEnumerable<LoaiMonAn> loaiL = _unitOfWork.ThucDons.GetLoaiThucAns();
            IEnumerable<LoaiMonAnDTO> loaiLDTO = _mapper.Map<IEnumerable<LoaiMonAn>, IEnumerable<LoaiMonAnDTO>>(loaiL);
            return loaiLDTO;
        }
        public void Create(SaveThucDonDTO saveThucDonDTO)
        {
            ThucDon td = _mapper.Map<SaveThucDonDTO, ThucDon>(saveThucDonDTO);
            _unitOfWork.ThucDons.Add(td);
            _unitOfWork.Complete();
        }
        public ThucDonDTO GetMonAn(int id)
        {
            ThucDon td = _unitOfWork.ThucDons.GetById(id);
            ThucDonDTO thucDonDTO = _mapper.Map<ThucDon, ThucDonDTO>(td);
            return thucDonDTO;
        }
        public ThucDonMD GetMonAnMD(int id)
        {
            ThucDon monAn = _unitOfWork.ThucDons.GetById(id);
            IEnumerable<LoaiMonAnDTO> listLDTO = GetLoaiMonAns();
            IEnumerable<ThucDonMD> listMonAnMD = from s in listLDTO
                                                 where s.Id == monAn.IdLoaiMonAn
                                                 select new ThucDonMD
                                                 {
                                                     Id = monAn.Id,
                                                     TenLoaiMonAn = s.Ten,
                                                     Ten = monAn.Ten,
                                                     Gia = monAn.Gia
                                                 };
            ThucDonMD monAnMD = listMonAnMD.Where(s => s.Id == monAn.Id).FirstOrDefault();

            return monAnMD;
        }
        public void Edit(SaveThucDonDTO saveThucDonDTO)
        {
            ThucDon td = _mapper.Map<SaveThucDonDTO, ThucDon>(saveThucDonDTO);
            _unitOfWork.ThucDons.Update(td);
            _unitOfWork.Complete();

        }
        public void ThemMonAn(SaveThucDonDTO saveThucDonDTO)
        {
            ThucDon td = _mapper.Map<SaveThucDonDTO, ThucDon>(saveThucDonDTO);
            _unitOfWork.ThucDons.Add(td);
            _unitOfWork.Complete();
        }
        public void Remove(int id)
        {
            //ThucDon td = _mapper.Map<SaveThucDonDTO, ThucDon>(saveThucDonDTO);
            var td = _unitOfWork.ThucDons.GetById(id);
            if (td != null)
            {
                _unitOfWork.ThucDons.Remove(td);
                _unitOfWork.Complete();
            }

        }
    }
}