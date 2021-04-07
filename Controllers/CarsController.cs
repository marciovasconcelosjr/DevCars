using Dapper;
using DevCars.API.Entities;
using DevCars.API.InputModels;
using DevCars.API.Persistence;
using DevCars.API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevCars.API.Controllers
{ 

    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly DevCarsDbContext _dbContext;
        private readonly string _connectionString;

        public CarsController(DevCarsDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;

            _connectionString = configuration.GetConnectionString("DevCarsCS");
            
        }
        //GET api/cars
        [HttpGet]
        public IActionResult Get()
        {
            //RETORNA LISTA DE CarItemViewModel
            var cars = _dbContext.Cars;

            var carsViewModel = cars
                .Where(c => c.Status == CarStatusEnum.Available)
                .Select(c => new CarItemViewModel(c.Id, c.Brand, c.Model,c.Price,c.Collor))      
                .ToList();

            return Ok(carsViewModel);


            //ABAIXO ESTOU USANDO O DAPPER
            //using (var sqlConnection = new SqlConnection(_connectionString))
            //{
            //    var query = "SELECT Id, Brand, Model, Price FROM Cars WHERE Status = 0";

            //    var carsViewModel = sqlConnection.Query<CarItemViewModel>(query);

            //    return Ok(carsViewModel);
            //}

        }


        // GET api/cars/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //SE CARRO DE IDENTIFICADOR ID NAO EXISTIR, RETORNA NOTFOUND
            //SENAO RETORN OK
            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            var carDetailsViewModel = new CarDetailsViewModel(
                car.Id,
                car.Brand,
                car.Model,
                car.VinCode,
                car.Year,
                car.Price,
                car.ProductionDate
                );
              
            return Ok(carDetailsViewModel);
        }



        //POST api/cars
        /// <summary>
        /// Cadastrar um carro
        /// </summary>
        /// <remarks>
        /// Requisição de exemplo:
        /// {
        ///     "brand": "Chevrolet",
        ///     "model": "Onix",
        ///     "vinCode": "ABC123",
        ///     "Year": 2021,
        ///     "collor": "Cinza",
        ///     "produtionDate": "2021-04-05"
        /// }
        /// </remarks>
        /// <param name="model">Dados de um novo carro</param>
        /// <returns>Objeto recem criado</returns>
        /// <response code="201">Objeto criado com sucesso</response>
        /// <response code="400">Dados Invalidos</response>
        [HttpPost]
        public IActionResult Post([FromBody] AddCarInputModel model)
        {
            //SE O CADASTRO FUNCIONAR, RETORNA CREATED(201)
            //SE OS DADOS DE ENTRADA ESTIVEREM INCORRETOS, RETORNA BAD REQUEST(400)
            //SE O CADASTRO FUNCIONAR, MAS NAO TIVER UMA API DE CONSULTA, RETORNA NOCONTENT(204)

            if (model.Model.Length > 50)
            {
                return BadRequest("Modelo não pode ter mais que 50 caracteres");
            }
            var car = new Car(model.VinCode, model.Brand, model.Model, model.Year, model.Price, model.Collor, model.ProductionDate);

            _dbContext.Cars.Add(car);

            _dbContext.SaveChanges();

            return CreatedAtAction(
                nameof(GetById),
                new { id = car.Id },
                model
                );
        }

        //PUT api/cars/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCarInputModel model)
        {
            //SE A ATUALIZAÇÃO FUNCIONAR, RETORNAR 204 NO CONTENT
            //SE DADOS DE ENTRADA ESTIVEREM INCORRETOS, RETORNA 400 BAD REQUEST
            //SE NAO EXISTIR, RETORNA NOT FOUND 404

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }

            car.Update(model.Collor, model.Price);

            //using (var sqlConnection = new SqlConnection(_connectionString))
            //{
            //    var query = "UPDATE Cars SET Collor = @collor, Price = @price, WHERE Id = @id";

            //    sqlConnection.Execute(query, new { collor = car.Collor, price = car.Price, car.Id });   
            //}

            _dbContext.SaveChanges();

            return NoContent();
        }

        //DELETE api/cars/2
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //SE NAO EXISTIR, RETORNA NOT FOUND 404
            //SE FOR UM SUCESSO, RETORNA NO CONTENT 204

            var car = _dbContext.Cars.SingleOrDefault(c => c.Id == id);

            if(car == null)
            {
                return NotFound();
            }

            car.SetAsSuspended();

            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}
