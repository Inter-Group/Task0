using Core.DTO.Category;
using Core.DTO.DonHang;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public static class DonHangMapper
    {
        static DonHangDTO toDonHangDTO(this DonHang donhang)
        {
            return new DonHangDTO
            {
                MaDonHang = donhang.MaDonHang,
                SoLuong = donhang.SoLuong,
                Products = donhang.Product.Select(p => p.toProductDTO()).ToList()
            };
        }
        static DonHang DonHangFromDTO(this DonHangDTO donhangDTO)
        {
            return new DonHang { MaDonHang = donhangDTO.MaDonHang };
        }
    }
}
