using klickit.Core.Constants;
using klickit.Core.DTOs;
using klickit.Core.Entities;
using klickit.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace klickit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Authorize(Roles = AppRoles.Shopper)]
        public async Task<ActionResult> SubmitOrder(List<OrderedItemsDto> orderedItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Order order = new Order();
            order.Status = Status.requested;
            order.Items = new List<OrderedItems>();
            foreach (OrderedItemsDto item in orderedItems)
            {
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product == null)
                {
                    return BadRequest();
                }
                var orderedItem = new OrderedItems();
                orderedItem.ProductId = item.ProductId;
                orderedItem.ProductName = product.Name;
                orderedItem.ProductQuantity = item.ProductQuantity;
                orderedItem.ProductPrice = product.Price;
                order.Items.Add(orderedItem);
            }
            order.TotalPrice = order.Items.Sum(o => o.ProductQuantity * o.ProductPrice);
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return Ok(order);
        }

        [HttpGet]
        [Authorize(Roles = AppRoles.Supplier)]
        public async Task<ActionResult> GetOrders([FromQuery] int page = 1)
        {
            int pageSize = 10;
            var order = await _context.Orders.Where(order =>order.Status==Status.requested).Skip((page - 1) * pageSize)
                                          .Take(pageSize).Include(o => o.Items)
                .ThenInclude(oi => oi.Product).ToListAsync();
            return Ok(new Response<Order>()
            {
                CurrentPage = page,
                TotalPages = Math.Ceiling((double)_context.Products.Count() / pageSize),
                Data = order
            });
        }

        [HttpPut]
        [Authorize(Roles = AppRoles.Supplier)]
        public async Task<ActionResult> ChangeOrderStatus(ChangeOrderStatusDto changeOrderStatusDto)
        {
          var order = await _context.Orders.Where(o=>o.Id==changeOrderStatusDto.OrderId).Include(o => o.Items)
                .ThenInclude(oi => oi.Product).FirstOrDefaultAsync();
            if (order ==null)
            {
                return NotFound();
            }
            foreach (var orderItem in order.Items)
            {
                var product = orderItem.Product;

                if (changeOrderStatusDto.Status == Status.approved)
                {
                    
                    product.Quantity -= orderItem.ProductQuantity;
                }

            }

            order.Status = changeOrderStatusDto.Status;
            await _context.SaveChangesAsync();
            return Ok();
        }



     }
 }
 
