using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Entities
{
    public class Car
    {
        //private int v;

        public Car(string vinCode, string brand, string model, int year, decimal price, string collor, DateTime productionDate)
        {
            
            VinCode = vinCode;
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
            Collor = collor;            
            ProductionDate = productionDate;
            Status = CarStatusEnum.Available;
            RegistredAt = DateTime.Now;
        }

     
        //public Car(int v, string vinCode, string brand, string model, int year, string collor, decimal price, DateTime productionDate)
        //{
        //    this.v = v;
        //    VinCode = vinCode;
        //    Brand = brand;
        //    Model = model;
        //    Year = year;
        //    Collor = collor;
        //    Price = price;
        //    ProductionDate = productionDate;
        //}

        //public Car(string vinCode, string brand, string model, int year, string collor, decimal price, DateTime productionDate)
        //{
        //    VinCode = vinCode;
        //    Brand = brand;
        //    Model = model;
        //    Year = year;
        //    Collor = collor;
        //    Price = price;
        //    ProductionDate = productionDate;
        //}

        public int Id { get; private set; }
        public string VinCode { get; private set; }
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public decimal Price { get; private set; }
        public string Collor { get; private set; }
        public DateTime ProductionDate { get; private set; }

        public CarStatusEnum Status { get; private set; }
        public DateTime RegistredAt { get; private set; }

        public void Update(string collor, decimal price) {
            Collor = collor;
            Price = price;
        }

        public void SetAsSuspended()
        {
            Status = CarStatusEnum.Suspended;
        }
    }
}
