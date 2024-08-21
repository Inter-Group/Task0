using Core.Contract.Repository_Contract;
using Core.DTO.DonHangdto;
using Core.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;


namespace Core.Repository
{
    public class DonHangRepository : IDonHangRepository
    {
        private readonly ApplicationDbContext _context;

        public DonHangRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DonHang> AddAsync(DonHang donHang)
        {
            // Đảm bảo rằng ProductId đã được thiết lập
            await _context.DonHangs.AddAsync(donHang);
            await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            return donHang;
        }

        public async Task<bool> DeleteAsycn(int id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return false;
            }

            _context.DonHangs.Remove(donHang);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DonHang?> GetByIdAsync(int id)
        {
            return await _context.DonHangs
                .Include(d => d.Product)
                //.Include(d => d.CongViec)
                .FirstOrDefaultAsync(d => d.MaDonHang == id);
        }

        public async Task<IEnumerable<DonHang>> GetAllAsync()
        {
            return await _context.DonHangs
                .Include(d => d.Product)
                .Include(d => d.CongViec)
                .ToListAsync();
        }


        
        public async Task<DonHang?> UpdateAsycn(int MaDonHang, DonHangUpdateRequest donhangUpdateRequest)
        {
            DonHang donHang = await GetByIdAsync(MaDonHang);
            if (donHang == null)
            {
                return null;
            }
            donHang.SoLuong = donhangUpdateRequest.SoLuong;
            donHang.ProductId = donhangUpdateRequest.ProductId;
            await _context.SaveChangesAsync();
            return donHang;
        }
        

        public async Task<IEnumerable<DonHang>> GetPagedDonHangAsync(int pageNumber, int pageSize)
        {
            return await _context.DonHangs
                .Include(c => c.Product)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalDonHangCountAsync()
        {
            return await _context.DonHangs.CountAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .FirstOrDefaultAsync(d => d.ProductId == id);
        }

    }
}
