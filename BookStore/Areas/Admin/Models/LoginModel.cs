using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bạn phải nhập username")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập password")]
        public String Password { get; set; }

        public bool RememberMe { get; set; }

    }
}