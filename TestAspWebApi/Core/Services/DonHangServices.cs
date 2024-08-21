using Core.Contract.Repository_Contract;
using Core.Contract.Services_Contract;
using Core.DTO.DonHangdto;
using Core.DTO.Task;
using Core.Mapper;
using Core.Models;

namespace Core.Services
{
    public class DonHangServices : IDonHangServices
    {
        private readonly IDonHangRepository _donhangRepository;
        private readonly IProductRepository _ProductRepository;
        public DonHangServices(IDonHangRepository donhangRepository, IProductRepository _productRepository)
        {
            _donhangRepository = donhangRepository;
            _ProductRepository = _productRepository;
        }
        public async Task<bool> CreateTaskAsync(DonHang donHang)
        {
            // Kiểm tra xem donHang có phải là null không
            if (donHang == null)
            {
                throw new ArgumentNullException(nameof(donHang), "Đơn hàng không được null.");
            }

            // Kiểm tra xem ProductId có tồn tại trong bảng Products hay không
            var existingProduct = await _ProductRepository.GetProductByIdAsync(donHang.ProductId);
            if (existingProduct == null)
            {
                throw new ArgumentException("Mã sản phẩm không hợp lệ");
            }

            // Nếu sản phẩm hợp lệ, tiếp tục thêm đơn hàng
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
                ProductId = dh.Product?.ProductId ?? 0
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
                ProductId = donHang.Product?.ProductId ?? 0
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
        public async Task<IEnumerable<DonHangDTO>> GetPagedDonHangAsync(int pageNumber, int pageSize)
        {
            var donhang = await _donhangRepository.GetPagedDonHangAsync(pageNumber, pageSize);
            return donhang.Select(donhang => donhang.ToDonHangDTO()) ;
        }
        public async Task<int> GetTotalDonHangCountAsync()
        {
            return await _donhangRepository.GetTotalDonHangCountAsync();
        }
    }
}
