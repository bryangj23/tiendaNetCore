using AdminTienda.DTOs.ProductDTOs;

namespace AdminTienda.Services
{
    public interface IProductService
    {
        public List<ProductDTO> GetListAllProducts();
        public ProductDTO GetProductById(int id);
        public ProductDTO CreateProduct(ProductDTO productDTO);
        public int DeleteProduct(int id);
        public ProductDTO UpdateProduct(int id, ProductDTO productDTO);
    }
}
