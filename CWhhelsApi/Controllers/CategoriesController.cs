using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CWhhelsApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CWhhelsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private CWheelsDBContext _cWheelsDBContext;
        public CategoriesController(CWheelsDBContext cWheelsDBContext)
        {
            _cWheelsDBContext = cWheelsDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entity = _cWheelsDBContext.Categories;
            return Ok(entity);
        }
    }
}