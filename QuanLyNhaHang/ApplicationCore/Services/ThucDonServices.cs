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

namespace ApplicationCore.Services
{
    public class ThucDonServices : IThucDonServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int pageSize = 5;
        public ThucDonServices(IUnitOfWork unitofwork,IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _mapper = mapper;
        }
        public ThucDonVM GetThucDonVM(string sort, string searchString, string currentFilter, string tenLoaiMonAn, int pageIndex = 1)
        {
            Expression<Func<ThucDon, bool>> predicate = m => true;
            if (!String.IsNullOrEmpty(searchString))
            {
                predicate = m => m.Ten.ToLower().Contains(searchString.ToLower());
            }

            var thucDons = _unitOfWork.ThucDons.Find(predicate);

            if (!String.IsNullOrEmpty(tenLoaiMonAn))
            {
                thucDons = _unitOfWork.ThucDons.GetClassifiedFoods(thucDons, tenLoaiMonAn);
            }
           
            var Loai = _unitOfWork.ThucDons.GetLoaiThucAns();
            var listThucDonMD = from s in thucDons
                                join t in Loai
                                 on s.IdLoaiMonAn equals t.Id
                                select new ThucDonMD
                                {
                                    Id = s.Id,
                                    TenLoaiMonAn = t.Ten,
                                    Ten = s.Ten,
                                    Gia = s.Gia
                                };
           
            return new ThucDonVM
            {
                ThucDonsMD = PaginatedList<ThucDonMD>.Create(listThucDonMD, pageIndex, pageSize)
            };
        }

        public IEnumerable<LoaiMonAnDTO> GetLoaiMonAns()
        {
            IEnumerable<LoaiMonAn> loaiL = _unitOfWork.ThucDons.GetLoaiThucAns();
            IEnumerable<LoaiMonAnDTO> loaiLDTO = _mapper.Map<IEnumerable<LoaiMonAn>,IEnumerable<LoaiMonAnDTO>>(loaiL);
            return loaiLDTO;
        }
        public void Create(SaveThucDonDTO saveThucDonDTO)
        {
            ThucDon td = _mapper.Map<SaveThucDonDTO,ThucDon>(saveThucDonDTO);
            _unitOfWork.ThucDons.Add(td);
            _unitOfWork.Complete();          
        }
        public ThucDonDTO GetMonAn(int id)
        {
            ThucDon td=_unitOfWork.ThucDons.GetById(id);
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
            if(td!=null)
            {
                _unitOfWork.ThucDons.Remove(td);
                _unitOfWork.Complete();
            }
           
        }
    }
}