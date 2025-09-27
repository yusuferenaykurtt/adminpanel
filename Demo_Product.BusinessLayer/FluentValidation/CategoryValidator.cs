using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Product.BusinessLayer.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {

        public CategoryValidator() { 
        
            RuleFor(x=>x.CategoryId).NotEmpty();
        
        }
    }
}
