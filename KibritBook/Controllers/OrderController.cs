using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KibritBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpPost("addorder")]
        public IActionResult AddOrder(OrderDTO model)
        {
            try
            {
                Order order = new()
                {
                    UserId = model.UserId,
                    BookId = model.BookId,
                    TotalPrice = model.TotalPrice,
                    TotalQuantity = model.TotalQuantity
                };
                _orderManager.Add(order);

                return Ok(new { status = 200, message = "Sifarisiniz tamamlandi." });
            }
            catch (Exception)
            {
                return BadRequest(new { status = 403, message = "Sifaris zamani xeta bas verdi!" });
            }
        }

        [HttpGet("getall/{userId}")]
        public async Task<IActionResult> UserOrder(int userId)
        {
            var order = _orderManager.GetAll(userId);
            return Ok(new { status = 200, message = order });
        }

        [HttpGet("allorders")]
        public async Task<IActionResult> GetAllOrders()
        {
            var order = _orderManager.GetAllOrders();
            return Ok(new { status = 200, message = order });
        }

        [HttpPost("updatetracking/{orderId}")]
        public async Task<IActionResult> UpdateTracking(int orderId)
        {

            var data = _orderManager.GetOrderById(orderId);
            _orderManager.Update(data);
            return Ok(new { status = 200, message = "Yenilendi." });
        }
    }
}
