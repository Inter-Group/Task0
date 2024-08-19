using Core.Contract.Repository_Contract;
using Core.Contract.Services_Contract;
using Core.DTO.DonHangdto;
using Core.Models;

namespace Core.Services
{
    public class DonHangServices : IDonHangServices
    {
        private readonly IDonHangRepository _donhangRepository;

        public DonHangServices(IDonHangRepository donhangRepository)
        {
            _donhangRepository = donhangRepository;

        }
        public async Task<bool> CreateTaskAsync(DonHang donHang)
        {
            DonHang donhangTemp = await _donhangRepository.AddAsync(donHang);
            if (donhangTemp == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _donhangRepository.DeleteAsycn(id);
        }

        public async Task<IEnumerable<DonHangDTO>> GetAllTasksAsync()
        {
            var donHangs = await _donhangRepository.GetAllAsync();
            return donHangs.Select(dh => new DonHangDTO
            {
                MaDonHang = dh.MaDonHang,
                SoLuong = dh.SoLuong,
                ProductID = dh.Product?.ProductId ?? 0
            });
        }

        public async Task<DonHangDTO?> GetTaskByIdAsync(int id)
        {
            var donHang = await _donhangRepository.GetByIdAsync(id);
            if (donHang == null) return null;

            return new DonHangDTO
            {
                MaDonHang = donHang.MaDonHang,
                SoLuong = donHang.SoLuong,
                ProductID = donHang.Product?.ProductId ?? 0
            };
        }

        public async Task<bool> UpdateTaskAsync(int MaDonHang, DonHangUpdateRequest donhangUpdaterequest)
        {
            DonHang? donHang = await _donhangRepository.UpdateAsycn(MaDonHang, donhangUpdaterequest);
            if (donHang == null)
            {
                return false;
            }
            return true;
        }
    }
}
