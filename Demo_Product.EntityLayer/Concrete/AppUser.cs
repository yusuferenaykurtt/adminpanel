using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Demo_Product.EntityLayer.Concrete.AppUser
{
    public class AppUser : IdentityUser<int> 
    {
        [PersonalData]
        [MaxLength(50)]
        public string? Name { get; set; }   

        [PersonalData]
        [MaxLength(50)]
        public string? SurName { get; set; }   

        [PersonalData]
        [MaxLength(20)]
        public string? Gender { get; set; }    
    }
}
