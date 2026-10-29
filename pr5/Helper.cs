using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;          
using pr5.Models;                 

namespace pr5
{
    internal class Helper
    {
        private static MebelCenterEntities _context; 


        public static MebelCenterEntities GetContext()
        {
            if (_context == null)
                _context = new MebelCenterEntities();
            return _context;
        }

        public void CreateClient(client client)
        {
            _context.client.Add(client);
            _context.SaveChanges();
        }

        public void UpdateClient(client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveClient(int idClient)
        {
            var item = _context.client.Find(idClient);
            _context.client.Remove(item);
            _context.SaveChanges();
        }

        public List<client> FiltrClients()
        {
            return _context.client
                .Where(x => x.last_name.StartsWith("И") || x.last_name.StartsWith("П"))
                .ToList();
        }

        public List<client> SortClients()
        {
            return _context.client.OrderBy(x => x.last_name).ToList();
        }

        public string GetClientLogin(client client)
        {
            return client.user_account.login.ToString();
        }

        public void CreateOrder(orders order)
        {
            _context.orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(orders order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveOrder(int idOrder)
        {
            var item = _context.orders.Find(idOrder);
            _context.orders.Remove(item);
            _context.SaveChanges();
        }

        public string GetOrderStatus(orders order)
        {
            return order.order_status.status_name.ToString();
        }

        public List<orders> OrdersByStatus(int statusId)
        {
            return _context.orders.Where(o => o.status_id == statusId).ToList();
        }

        public List<orders> SortOrders()
        {
            return _context.orders.OrderBy(o => o.order_date).ToList();
        }
    }
}