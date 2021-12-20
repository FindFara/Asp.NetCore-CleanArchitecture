using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.Users
{
    public class AccountRegisterVm
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "{0} is not correct")]
        [Required(ErrorMessage = "{0} Pleas Enter Your")]
        public string Email { get; set; }
        [Display(Name = "Password ")]
        [Required(ErrorMessage = "{0} Pleas Enter Your")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "{0} Pleas Enter Your")]
        [Compare( nameof(Password) , ErrorMessage = "{0} is not correct")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }

    public class AccountLoginVm
    {
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "{0} شما صحیح نمی باشد")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Email { get; set; }
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Password { get; set; }
        [Display(Name = "مرا به خاطر بسپار")]
        public bool IsRemember { get; set; }
    }
}
