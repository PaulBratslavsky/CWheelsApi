using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CWhhelsApi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title should not be empty or null!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Price should not be empty or null!")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Color should not be empty or null!")]
        public string Color { get; set; }
    }
}
