using System.ComponentModel.DataAnnotations;

namespace Demo_Product.Models
{
    public class UserLoginViewModel
    {


        [Required(ErrorMessage="Please enter your email")]

        public string eMail { get; set; }

        [Required (ErrorMessage ="Please enter your password")]

        public string password { get; set; }
    }
}
