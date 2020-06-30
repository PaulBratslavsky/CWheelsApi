using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CWhhelsApi.Models
{
    public class ChangePasswordModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "New password and confirmed password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
