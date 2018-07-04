using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GetWheels.Data.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsPersistent { get; set; }
    }
}
