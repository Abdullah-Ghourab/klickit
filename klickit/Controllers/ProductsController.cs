using klickit.Core.DTOs;
using klickit.Core.Entities;
using klickit.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace klickit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] int page = 1)
        {
            int pageSize = 10;
            var products = await _context.Products.Skip((page - 1) * pageSize)
                                          .Take(pageSize).ToListAsync();
            return Ok( new Response<Product>()
            {
                CurrentPage = page,
                TotalPages = Math.Ceiling((double)_context.Products.Count() / pageSize),
                Data = products

            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id) 
        {
            var product =await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }
    }

   
}
