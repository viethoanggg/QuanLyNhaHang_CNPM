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
using ApplicationCore.ModelsContainData.ViewModels;
using AutoMapper;

namespace ApplicationCore.Services {
    public class KhachHangServices : IKhachHangServices {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly int pageSize = 10;
        public KhachHangServices (IUnitOfWork unitOfWork,IMapper mapper) {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public KhachHangVM GetKhachHangVM (int pageIndex = 1) {
            Expression<Func<KhachHang, bool>> predicate = m => true;
            var khachHangs = _unitOfWork.KhachHangs.Find (predicate);
            IEnumerable<KhachHang> kh=_unitOfWork.KhachHangs.Find(predicate);
            // IEnumerable<KhachHangMD> kh = from k in khachHangs
            //                               select new KhachHangMD
            //                               {
            //                                   Id = k.Id,
            //                                   Ten = k.Ten,
            //                                   SDT = k.SDT,
            //                                   DiaChi = k.DiaChi.GetDiaChi
            //                               };

            IEnumerable<KhachHangDTO> khDTOs = _mapper.Map<IEnumerable<KhachHang>,IEnumerable<KhachHangDTO>>(kh);
            return new KhachHangVM {
                KhachHangs = PaginatedList<KhachHangDTO>.Create (khDTOs, pageIndex, pageSize)
            };
        }
        public KhachHangDTO GetKhachHang (int id) {
            KhachHang khachHang = _unitOfWork.KhachHangs.GetById (id);
            if (khachHang == null) {
                return null;
            }
            KhachHangDTO khachHangDTO = _mapper.Map<KhachHang, KhachHangDTO>(khachHang);
            return khachHangDTO;
        }
        public void Edit (SaveKhachHangDTO SaveKhachHangDTO) {
            KhachHang khachHang = _mapper.Map<SaveKhachHangDTO, KhachHang>(SaveKhachHangDTO);
            _unitOfWork.KhachHangs.Update (khachHang);
            _unitOfWork.Complete ();
        }
        public void Delete (int id) {
            KhachHangDTO khachHangDTO = GetKhachHang (id);
            KhachHang khachHang = _mapper.Map<KhachHangDTO,KhachHang>(khachHangDTO);
            _unitOfWork.KhachHangs.Remove (khachHang);
            _unitOfWork.Complete ();
        }
        public void Create (SaveKhachHangDTO SaveKhachHangDTO) {
            KhachHang khachHang = _mapper.Map<SaveKhachHangDTO,KhachHang>(SaveKhachHangDTO);
            _unitOfWork.KhachHangs.Add (khachHang);
            _unitOfWork.Complete ();
        }

    }
}