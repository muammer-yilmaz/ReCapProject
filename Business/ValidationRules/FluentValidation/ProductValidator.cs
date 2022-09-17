using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation {
    public class ProductValidator : AbstractValidator<Car> {
        public ProductValidator() {
            RuleFor(c => c.CarName.Length).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
        }
    }
}
