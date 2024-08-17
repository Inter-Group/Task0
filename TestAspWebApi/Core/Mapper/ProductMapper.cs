using Core.DTO.Category;
using Core.DTO.Product;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapper
{
    public static class ProductMapper
    {
        public static ProductDTO toProductDTO(this Product product)
        {
            return new ProductDTO {ProductId = product.ProductId,
            ProductName = product.ProductName};
        }
        static Product ProductFromDTO(this ProductDTO productDTO)
        {
            return new Product {ProductName = productDTO.ProductName};
        }
    }
}
