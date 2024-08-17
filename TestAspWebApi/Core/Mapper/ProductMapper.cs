
using Core.DTO.Productdto;
using Core.Models;


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
