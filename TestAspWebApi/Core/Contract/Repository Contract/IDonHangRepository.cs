using Core.DTO.DonHangdto;
using Core.Models;

namespace Core.Contract.Repository_Contract
{
    public interface IDonHangRepository
    {
        Task<IEnumerable<DonHang>> GetAllAsync();
        Task<DonHang?> GetByIdAsync(int id);
        Task<DonHang?> UpdateAsycn(int v, DonHangUpdateRequest donhangUpdateRequest);

        Task<DonHang> AddAsync(DonHang donhang);

        Task<bool> DeleteAsycn(int id);

        Task<Product?> GetProductByIdAsync(int id);

        // Phân trang
        Task<IEnumerable<DonHang>> GetPagedDonHangAsync(int pageNumber, int pageSize);

        // Lấy tổng số task 
        Task<int> GetTotalDonHangCountAsync();
    }
}
