using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.ViewModels
{
    public class CarItemViewModel
    {
        public CarItemViewModel(int id, string brand, string model, decimal price, string collor)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Price = price;
            Collor = collor;
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Collor { get; set; }

    }
}
