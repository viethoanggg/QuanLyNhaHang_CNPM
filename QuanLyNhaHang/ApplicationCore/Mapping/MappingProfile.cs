using ApplicationCore.DTOs;
using ApplicationCore.DTOs.SaveDTOs;
using ApplicationCore.Entities;
using AutoMapper;
namespace ApplicationCore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BanAn, BanAnDTO>();
            CreateMap<SaveBanAnDTO, BanAn>();
            CreateMap<BanAnDTO, SaveBanAnDTO>();

            CreateMap<ChiTietHoaDon, ChiTietHoaDonDTO>();
            CreateMap<SaveChiTietHoaDonDTO, ChiTietHoaDon>();
            CreateMap<ChiTietHoaDonDTO, SaveChiTietHoaDonDTO>();

            CreateMap<HoaDon, HoaDonDTO>();
            CreateMap<SaveHoaDonDTO, HoaDon>();
            CreateMap<HoaDonDTO, SaveHoaDonDTO>();

            CreateMap<KhachHang, KhachHangDTO>();
            CreateMap<SaveKhachHangDTO, KhachHang>();
            CreateMap<KhachHangDTO, SaveKhachHangDTO>();

            CreateMap<LoaiMonAn, LoaiMonAnDTO>();
            CreateMap<SaveLoaiMonAnDTO, LoaiMonAn>();
            CreateMap<LoaiMonAnDTO, SaveLoaiMonAnDTO>();

            CreateMap<NguoiDung, NguoiDungDTO>();
            CreateMap<SaveNguoiDungDTO, NguoiDung>();
            CreateMap<NguoiDungDTO, SaveNguoiDungDTO>();

            CreateMap<PhieuDatBan, PhieuDatBanDTO>();
            CreateMap<SavePhieuDatBanDTO, PhieuDatBan>();
            CreateMap<PhieuDatBanDTO, SavePhieuDatBanDTO>();

            CreateMap<ThucDon, ThucDonDTO>();
            CreateMap<SaveThucDonDTO, ThucDon>();
            CreateMap<ThucDonDTO, SaveThucDonDTO>();
        }
    }
}