using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.InputModels
{
    public class AddOrderInputModel
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public List<ExtraItemInputModel> ExtraItens { get; set; }
        public int IdCar { get; internal set; }
    }

    public class ExtraItenmInputModel
    {
        public string Descrition { get; set; }
        public decimal Price { get; set; }

    }
}
