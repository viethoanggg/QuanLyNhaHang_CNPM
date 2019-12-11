using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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

        public NguoiDungDTO GetNguoiDungDTOByUserName(string userName)
        {
            NguoiDung nguoiDung = _unitOfWork.NguoiDungs.Find(x => x.TenDangNhap == userName).FirstOrDefault();
            NguoiDungDTO NguoiDungDTO = _mapper.Map<NguoiDung, NguoiDungDTO>(nguoiDung);
            return NguoiDungDTO;
        }
        public void Edit(SaveNguoiDungDTO SaveNguoiDungDTO)
        {
            NguoiDung NguoiDung = _mapper.Map<SaveNguoiDungDTO, NguoiDung>(SaveNguoiDungDTO);
            _unitOfWork.NguoiDungs.Update(NguoiDung);
            _unitOfWork.Complete();
        }

        public int Create(string NhapLaiMatKhau, SaveNguoiDungDTO SaveNguoiDungDTO)
        {
            if (!SaveNguoiDungDTO.MatKhau.Equals(NhapLaiMatKhau))
            {
                return -1;
            }
            using (MD5 mD5 = MD5.Create())
            {
                SaveNguoiDungDTO.MatKhau = GetMd5Hash(mD5, SaveNguoiDungDTO.MatKhau);
            }
            NguoiDung NguoiDung = _mapper.Map<SaveNguoiDungDTO, NguoiDung>(SaveNguoiDungDTO);
            _unitOfWork.NguoiDungs.Add(NguoiDung);
            _unitOfWork.Complete();
            return 1;
        }
        public string GetMd5Hash(MD5 md5, string input)
        {
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                s.Append(bytes[i].ToString("X2"));

            }
            return s.ToString();
        }

        public bool VerifyMd5Hash(MD5 md5, string input, string sqlString)
        {
            string md5Hash = GetMd5Hash(md5, input);
            if (md5Hash.Equals(sqlString))
                return true;
            return false;
        }
        public int LockUser(int IdUser, int IdCurrentUser)
        {
            if (IdUser.Equals(IdCurrentUser))
                return -1;
            NguoiDung nguoiDung = _unitOfWork.NguoiDungs.GetById(IdUser);
            if (nguoiDung.TrangThai.Equals(-1))
                nguoiDung.TrangThai = 1;
            else
                nguoiDung.TrangThai = -1;
            _unitOfWork.NguoiDungs.Update(nguoiDung);
            _unitOfWork.Complete();
            return 1;
        }

        public IEnumerable<HoaDon> GetListHDCuaNguoiDung(int idUser)
        {
            IEnumerable<HoaDon> listHD = _unitOfWork.HoaDons.Find(s => s.IdUser.Equals(idUser));
            return listHD;

        }
        public void SuaThongTinCaNhan(int IdUser, string HoTen)
        {
            NguoiDung user = _unitOfWork.NguoiDungs.Find(s => s.Id.Equals(IdUser)).FirstOrDefault();
            if (user == null)
                return;
            user.Ten = HoTen;
            _unitOfWork.NguoiDungs.Update(user);
            _unitOfWork.Complete();
        }

        public string DoiMatKhau(int IdUser, string MatKhauMoi, string MatKhauCu)
        {
            NguoiDung user = _unitOfWork.NguoiDungs.GetById(IdUser);
            if (user == null)
                return "-1";

            using (MD5 mD5 = MD5.Create())
            {
                if (!VerifyMd5Hash(mD5, MatKhauCu, user.MatKhau))
                    return "0";
                string mkMoi = GetMd5Hash(mD5, MatKhauMoi);
                user.MatKhau = mkMoi;
            }
            _unitOfWork.NguoiDungs.Update(user);
            _unitOfWork.Complete();
            return "1";
        }
    }
}