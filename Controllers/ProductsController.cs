using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminTienda.Context;
using AdminTienda.Models;
using AdminTienda.Services;
using AdminTienda.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Cors;


namespace AdminTienda.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(TiendaContext context)
        {
            productService = new ProductServiceImpl(context);
        }

        // GET: Products
        [HttpGet]        
        public  ActionResult GetListProducts()
        {            
            try
            {                
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = productService.GetListAllProducts()});

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Products
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult ProductById(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = productService.GetProductById(id) });           
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
            
        }

        // POST: Products/Create
        [HttpPost]        
        public ActionResult CreateProduct(ProductDTO productDTO)
        {        
            try
            {

                return StatusCode(StatusCodes.Status201Created, new { message = "ok", response = productService.CreateProduct(productDTO) });            
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Products/Edit/5
        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateProduct(int id, [Bind("Id,CategoryId,Code,NameProd,PriceSale,Stock,Description,Status")] ProductDTO productDTO)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = productService.UpdateProduct(id, productDTO) });               
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: Products/Delete/5
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = productService.DeleteProduct(id) });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
