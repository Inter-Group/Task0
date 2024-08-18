using Core.Contract.Repository_Contract;
using Core.Models;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Respository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<CongViec> AddAsync(CongViec congViec)
        {
            _context.congViecs.Add(congViec);
            await _context.SaveChangesAsync();
            return congViec;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var congViec = await _context.congViecs.FindAsync(id);
            if (congViec == null)
            {
                return false;
            }

            _context.congViecs.Remove(congViec);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CongViec>> GetAllAsync()
        {
            return await _context.congViecs.ToListAsync();
        }

        public async Task<CongViec?> GetByIdAsync(int id)
        {
            return await _context.congViecs.FindAsync(id);
        }

        public async Task<IEnumerable<CongViec>> GetPagedTasksAsync(int pageNumber, int pageSize)
        {
            return await _context.congViecs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalTasksCountAsync()
        {
            return await _context.congViecs.CountAsync();
        }

        public async Task<CongViec?> UpdateAsync(CongViec congViec)
        {
            var existingTask = await _context.congViecs.FindAsync(congViec.MaCongViec);
            if (existingTask == null)
            {
                return null;
            }

            existingTask.TenCongViec = congViec.TenCongViec;
            existingTask.Start = congViec.Start;
            existingTask.End = congViec.End;
            existingTask.DonHang = congViec.DonHang;

            await _context.SaveChangesAsync();
            return existingTask;
        }
    }
}
