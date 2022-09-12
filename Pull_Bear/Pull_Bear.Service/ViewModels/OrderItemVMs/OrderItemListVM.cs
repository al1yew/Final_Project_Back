using Pull_Bear.Service.ViewModels.OrderVMs;
using Pull_Bear.Service.ViewModels.ProductVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pull_Bear.Service.ViewModels.OrderItemVMs
{
    public class OrderItemListVM
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int TrackingNumber { get; set; }


        //relations with product and order------ each order has orderitem and each orderitem is product
        public ProductGetVM Product { get; set; }
        public int ProductId { get; set; }
        public OrderListVM Order { get; set; }
        public int OrderId { get; set; }
    }
}
