using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWhhelsApi.Data;
using CWhhelsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWhhelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {

        private CWheelsDBContext _cWheelsDBContext;

        public VehiclesController(CWheelsDBContext cWheelsDBContext)
        {
            _cWheelsDBContext = cWheelsDBContext;
        }


        // GET: api/Vehicles
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return _cWheelsDBContext.Vehicles;
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}", Name = "Get")]
        public Vehicle Get(int id)
        {
            var vehicle = _cWheelsDBContext.Vehicles.Find(id);
            return vehicle;
        }

        // POST: api/Vehicles
        [HttpPost]
        public void Post([FromBody] Vehicle vehicle)
        {
            _cWheelsDBContext.Vehicles.Add(vehicle);
            _cWheelsDBContext.SaveChanges();
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vehicle vehicle)
        {
            var entity = _cWheelsDBContext.Vehicles.Find(id);
            entity.Title = vehicle.Title;
            entity.Price = vehicle.Price;
            _cWheelsDBContext.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = _cWheelsDBContext.Vehicles.Find(id);
            _cWheelsDBContext.Vehicles.Remove(entity);
            _cWheelsDBContext.SaveChanges();
        }
    }
}
