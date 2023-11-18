using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order order)
        {
            _orderDal.Add(order);
        }

        public List<OrderDTO> GetAll(int userId)
        {
            return _orderDal.GetUserOrders(userId);
        }

        public List<OrderDTO> GetAllOrders()
        {
            return _orderDal.GetAllOrders();
        }

        public Order GetOrderById(int id)
        {
            return _orderDal.Get(x => x.Id == id);
        }

        public void Remove(Order order)
        {
            _orderDal.Delete(order);
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }
    }
}
