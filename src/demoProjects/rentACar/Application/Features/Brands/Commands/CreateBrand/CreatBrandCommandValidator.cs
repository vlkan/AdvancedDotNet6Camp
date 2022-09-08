using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Features.Brands.Commands.CreateBrand;

public class CreatBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreatBrandCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MinimumLength(2);
    }
}