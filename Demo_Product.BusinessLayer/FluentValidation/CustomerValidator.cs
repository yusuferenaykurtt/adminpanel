using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_Product.EntityLayer.Concrete;
namespace Demo_Product.BusinessLayer.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator() { 
        
        RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Name cant be empty");
            RuleFor(x => x.CustomerName).MinimumLength(3);

        }
          
    }
}
