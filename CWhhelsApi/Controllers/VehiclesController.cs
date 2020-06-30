using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CWhhelsApi.Data;
using CWhhelsApi.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Authorize]
        public IActionResult Post(Vehicle vehicle)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            var user = _cWheelsDBContext.Users.FirstOrDefault(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound();
            }

            var vehObj = new Vehicle()
            {
                Title = vehicle.Title,
                Description = vehicle.Description,
                Color = vehicle.Color,
                Company = vehicle.Company,
                Condition = vehicle.Condition,
                DatePosted = new DateTime(),
                Engine = vehicle.Engine,
                Price = vehicle.Price,
                Model = vehicle.Model,
                Location = vehicle.Location,
                CategoryId = vehicle.CategoryId,
                IsFeatured = false,
                IsHotAndNew = false,
                UserId = user.Id,
            };

            _cWheelsDBContext.Vehicles.Add(vehObj);
            _cWheelsDBContext.SaveChanges();

            return Ok(new {vehicleId = vehObj.Id, message = "Vehicle added successfully."});
        }
    }
}