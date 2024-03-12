using Application.Features.Colaboradors.Command.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colaboradors.Command.Update
{
    public class UpdateColaboradorCommandValidator : AbstractValidator<UpdateColaboradorCommand>
    {
        public UpdateColaboradorCommandValidator()
        {
            RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("{PropertyName} no puede ser 0");
         
            
            RuleFor(x => x.PrimerNombre)
            .NotEmpty().WithMessage("{PropertyName} Campo requerido no puede ser vacio")
            .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLenth} caracteres")
                .Matches(@"^\D*$").WithMessage("{PropertyName} no debe contener numeros");

            RuleFor(x => x.SegundoNombre)
             .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLenth} caracteres")
                .Matches(@"^\D*$").WithMessage("{PropertyName} no debe contener numeros");

            RuleFor(x => x.PrimerApellido)
          .NotEmpty().WithMessage("{PropertyName} Campo requerido no puede ser vacio")
          .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLenth} caracteres")
            .Matches(@"^\D*$").WithMessage("{PropertyName} no debe contener numeros");


            RuleFor(x => x.SegundoApellido)
            .NotEmpty().WithMessage("{PropertyName} Campo requerido no puede ser vacio")
            .MaximumLength(50).WithMessage("{PropertyName} no debe exceder de {MaxLenth} caracteres");

            RuleFor(x => x.FechaNacimiento)
           .NotEmpty().WithMessage("{PropertyName} Campo requerido no puede ser vacio");

            RuleFor(x => x.Sueldo)
              .GreaterThan(0).WithMessage("{PropertyName} no puede ser 0 ");


        }
    }
}
