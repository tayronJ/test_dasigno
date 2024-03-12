using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colaboradors.Command.Delete
{
    internal class DeleteColaboradorCommandValidators : AbstractValidator<DeleteColaboradorCommand>
    {
        public DeleteColaboradorCommandValidators()
        {
            RuleFor(v => v.Id)
             .GreaterThan(0).WithMessage("{PropertyName} no puede ser 0");
        }
    }
}
