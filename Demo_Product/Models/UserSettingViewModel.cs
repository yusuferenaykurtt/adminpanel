using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class UserSettingViewModel
    {

        [Required(ErrorMessage = "Please enter the name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please enter the surname")]
        public string surName { get; set; }


        [Required(ErrorMessage = "Please enter the password")]
        public string password { get; set; }


        [Required(ErrorMessage = "Please enter the passowrd again")]
        [Compare("password", ErrorMessage = "Be sure password match")]
        public string confirmedPassword { get; set; }

        [Required(ErrorMessage = "Please enter your e mail")]
        public string eMail { get; set; }
    }
}
