using AdminTienda.Context;
using AdminTienda.DTOs.ProductDTOs;
using AdminTienda.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminTienda.Services
{
    public class ProductServiceImpl: IProductService
    {
        private readonly TiendaContext _context;

        public ProductServiceImpl(TiendaContext context)
        {
            _context = context;
        }

        public List<ProductDTO> GetListAllProducts()
        {
            List<Product> products = new List<Product>();
            List<ProductDTO> productsDTO = new List<ProductDTO>();

            //var queryProduct = (from prod in _context.Products
            //                    where prod.isDelete == false
            //                    select prod).FirstOrDefault<Product>();

            products = _context.Products.Include(p => p.Category).Where(prod => prod.isDelete != true).ToList();
            foreach(Product product in products)
            {
                productsDTO.Add(mapearProduct(product));

            }

            return productsDTO;
        }

        public ProductDTO GetProductById(int id)
        {            
            Product? product = _context.Products.Where(prod => prod.Id == id && prod.isDelete != true).FirstOrDefault();

            if (product == null) throw new Exception("Product no encontrado con id: "+id);
            return mapearProduct(product);
            
        }

        public ProductDTO CreateProduct(ProductDTO productDTO)
        {
            Product product = mapearProductDTO(productDTO);            
            product.NameProd = productDTO.NameProd;
            product.PriceSale = productDTO.PriceSale;
            product.Status = productDTO.Status;
            product.CategoryId = productDTO.CategoryId;
            product.Code = productDTO.Code;
            product.Description = productDTO.Description;
            product.Stock = productDTO.Stock;

            _context.Products.Add(product);
            _context.SaveChanges();

            return mapearProduct(product);
        }

        public ProductDTO UpdateProduct(int id, ProductDTO productDTO)
        {

            Product? product = _context.Products.Where(prod => prod.Id == id).FirstOrDefault();
            if (product == null) throw new Exception("Product no encontrado con id: " + id);

            product.NameProd = productDTO.NameProd;
            product.PriceSale = productDTO.PriceSale;
            product.Status = productDTO.Status;
            product.CategoryId = productDTO.CategoryId;
            product.Code = productDTO.Code;
            product.Description = productDTO.Description;
            product.Stock = productDTO.Stock;
            
            _context.Update(product);
            _context.SaveChanges();

            return mapearProduct(product);
        }

        public int DeleteProduct(int id)
        {
            Product? product = _context.Products.Where(prod => prod.Id == id).FirstOrDefault();
            if (product == null) throw new Exception("Product no encontrado con id: " + id);           

            product.isDelete = true;

            _context.SaveChanges(product);
            return id;
        }

        //Mapear ProductDTO a Product
        public Product mapearProductDTO(ProductDTO productDTO)
        {
            Product product = new Product();
            product.Id              = productDTO.Id;
            product.NameProd        = productDTO.NameProd;
            product.PriceSale       = productDTO.PriceSale;
            product.Status          = productDTO.Status;
            product.CategoryId      = productDTO.CategoryId;
            product.Code            = productDTO.Code;
            product.Description     = productDTO.Description;
            product.Stock           = productDTO.Stock;

            return product;
        }

        //Mapear Product a ProductDTO
        public ProductDTO mapearProduct(Product product)
        {
            ProductDTO productDTO = new ProductDTO();
            productDTO.Id              = product.Id;
            productDTO.NameProd        = product.NameProd;
            productDTO.PriceSale       = product.PriceSale;
            productDTO.Status          = product.Status;
            productDTO.CategoryId      = product.CategoryId;
            productDTO.Code            = product.Code;
            productDTO.Description     = product.Description;
            productDTO.Stock           = product.Stock;

            return productDTO;
        }

    }
}
