using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class OrderDal : EfEntityRepositoryBase<Order, KibritBookDbContext>, IOrderDal
    {
        public List<OrderDTO> GetAllOrders()
        {
            using var context = new KibritBookDbContext();

            var orders = context.Orders.Include(x => x.Book).Include(x => x.User).ToList();

            List<OrderDTO> result = new();

            foreach (var order in orders)
            {
                OrderDTO orderDTO = new()
                {
                    Id = order.Id,
                    UserId = order.UserId,
                    UserEmail = order.User.Email,
                    BookId = order.BookId,
                    BookName = order.Book.Name,
                    TotalPrice = order.TotalPrice,
                    TotalQuantity = order.TotalQuantity
                };
                result.Add(orderDTO);
            }

            return result;

        }
        public List<OrderDTO> GetUserOrders(int userId)
        {
            using var context = new KibritBookDbContext();
            var orderList = context.Orders.Include(X => X.Book).Include(x => x.User).Where(x => x.UserId == userId).ToList();

            List<OrderDTO> list = new();

            foreach (var order in orderList)
            {
                OrderDTO orderDTO = new()
                {
                    UserId = userId,
                    Id = order.Id,
                    BookId = order.BookId,
                    BookName = order.Book.Name,
                    UserEmail = order.User.Email,
                    TotalPrice = order.TotalPrice,
                    TotalQuantity = order.TotalQuantity
                };
                list.Add(orderDTO);
            }
            return list;
        }
    }
}
