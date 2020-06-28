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
        public IActionResult Get()
        {
            // return _cWheelsDBContext.Vehicles;
            // return StatusCode(StatusCodes.Status200OK);
            return Ok(_cWheelsDBContext.Vehicles);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var entity = _cWheelsDBContext.Vehicles.Find(id);
            if (entity == null )
            {
                return NotFound("No record found with this ID!");
            } else
            {
                return Ok(entity);
            }
        }

        // POST: api/Vehicles
        [HttpPost]
        public IActionResult Post([FromBody] Vehicle vehicle)
        {
            _cWheelsDBContext.Vehicles.Add(vehicle);
            _cWheelsDBContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Vehicles/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Vehicle vehicle)
        {
            var entity = _cWheelsDBContext.Vehicles.Find(id);
            if (entity == null)
            {
                return NotFound("No record found with this ID!");
            } else
            {
                entity.Title = vehicle.Title;
                entity.Price = vehicle.Price;
                entity.Color = vehicle.Color;
                _cWheelsDBContext.SaveChanges();
                return Ok("Record updated successfully!");
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _cWheelsDBContext.Vehicles.Find(id);
            if (entity == null)
            {
                return NotFound("No record found with this ID!");
            }
            else
            {
                _cWheelsDBContext.Vehicles.Remove(entity);
                _cWheelsDBContext.SaveChanges();
                return Ok("Record deleted!");
            }
            
        }
    }
}
