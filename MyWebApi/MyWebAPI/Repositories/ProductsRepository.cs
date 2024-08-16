using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data;
using MyWebAPI.Models;
using SQLitePCL;

namespace MyWebAPI.Repositories
{
    public class ProductsRepository : IRepository
    {
        private readonly ProductsConText _context;
        private readonly IMapper _mapper;

        public ProductsRepository(ProductsConText context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ProductsModel> GetALLByIDAsync(int id)
        {
            var pro = await _context.Products!.FindAsync(id);
            return _mapper.Map<ProductsModel>(pro);
        }

        public async Task<List<ProductsModel>> GetALLAsync()
        {
            var pro = await _context.Products!.ToListAsync();
            return _mapper.Map<List<ProductsModel>>(pro);
        }

        public async Task UpdateAsync(int id, ProductsModel model)
        {
            if(id == model.Id)
            {
                var sua = _mapper.Map<Products>(model);
                _context.Products!.Update(sua);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> AddAsync(ProductsModel model)
        {
            var them = _mapper.Map<Products>(model);
            _context.Products!.Add(them);
            await _context.SaveChangesAsync();
            return them.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var xoa = _context.Products!.SingleOrDefault(x => x.Id == id);
            if (xoa != null)
            {
                _context.Products!.Remove(xoa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
