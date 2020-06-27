using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWhhelsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWhhelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private static List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle() {Id = 0, Title = "My Car", Price = 300},
            new Vehicle() {Id = 1, Title = "Other Car", Price = 3100},
        };

        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            return vehicles;
        }

        [HttpPost]
        public void Post([FromBody]Vehicle vehicle)
        {
            vehicles.Add(vehicle);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Vehicle vehicle)
        {
            vehicles[id] = vehicle;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            vehicles.RemoveAt(id);
        }
    }
}