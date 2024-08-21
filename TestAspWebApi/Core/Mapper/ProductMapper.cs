
using Core.DTO.Productdto;
using Core.Models;


namespace Core.Mapper
{
    public static class ProductMapper
    {
        public static ProductDTO toProductDTO(this Product product)
        {
            return new ProductDTO
            {
                ProductName = product.ProductName,CategoryId = product.CategoryId,ProductId = product.ProductId
            };
        }
        public static Product ProductFromDTO(this ProductDTO productDTO)
        {
            return new Product {ProductName = productDTO.ProductName,CategoryId = productDTO.CategoryId,ProductId = productDTO.ProductId };
        }
        public static Product ProductFromAddRequest(this ProductAddRequest productAddrequest)
        {
            return new Product { ProductName = productAddrequest.ProductName, CategoryId = productAddrequest.CategoryId };
        }
        public static Product ProductFromUpdateRequest(this ProductUpdateRequest productUpdaterequest)
        {
            return new Product { ProductName = productUpdaterequest.ProductName, CategoryId = productUpdaterequest.CategoryId };
        }
    }
}
