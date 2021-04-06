using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Orders
    {
        protected Orders() { }
        public Orders(int idCar, int idCustomer, decimal price, List<ExtraOrderItem> itens)
        {
            IdCar = idCar;
            IdCustomer = idCustomer;
            TotalCost = itens.Sum(i => i.Price) + price;

            ExtraItens = itens;
        }

        public int Id { get; private set; }
        public int IdCar { get; private set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public int IdCustomer { get; private set; }
        public decimal TotalCost { get; private set; }
        public List<ExtraOrderItem> ExtraItens { get; private set; }
    }

    public class ExtraOrderItem
    {
        protected ExtraOrderItem() { }
        public ExtraOrderItem(string description, decimal price)
        {
            Description = description;
            Price = price;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int IdOrder { get; private set; }

    }
}
