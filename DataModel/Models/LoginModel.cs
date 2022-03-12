using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataModel.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public DateTime LoginStarted { get; set; }
        public string TwoFactorCode { get; set; }
        public string Error { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public ApplicationUser User { get; set; }
        public bool RememberMachine { get; set; }


    }
}
