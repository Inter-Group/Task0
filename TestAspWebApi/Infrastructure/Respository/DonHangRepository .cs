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
            _context.DonHangs.Add(donHang);
            await _context.SaveChangesAsync();
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
                .Include(d => d.CongViec)
                .FirstOrDefaultAsync(d => d.MaDonHang == id);
        }

        public async Task<IEnumerable<DonHang>> GetAllAsync()
        {
            return await _context.DonHangs
                .Include(d => d.Product)
                .Include(d => d.CongViec)
                .ToListAsync();
        }

        public async Task<DonHang?> UpdateAsycn(DonHang donHang)
        {
            var existingDonHang = await _context.DonHangs.FindAsync(donHang.MaDonHang);
            if (existingDonHang == null)
            {
                return null;
            }

            _context.Entry(existingDonHang).CurrentValues.SetValues(donHang);
            await _context.SaveChangesAsync();
            return existingDonHang;
        }
    }
}
