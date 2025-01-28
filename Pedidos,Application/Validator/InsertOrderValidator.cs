using FluentValidation;
using Pedidos.Core.Entities;
using Pedidos_Application.Commands.InsertOrder;

namespace Pedidos_Application.Validator
{
    public class InsertOrderValidator : AbstractValidator<InsertOrderCommand> 
    {
        public InsertOrderValidator()
        {
            RuleFor(o => o.Product)
                .NotEmpty()
                .WithMessage("Por Favor Preencher o Produto")
                .MinimumLength(3)
                .WithMessage("Caracteres insuficiente")
                .MaximumLength(25).
                WithMessage("No Máximo Caracteres");

            RuleFor(o => o.ClientName)
                .NotEmpty()
                .WithMessage("Por Favor Preencher o Nome do Cliente")
                .MinimumLength(3)
                .WithMessage("Caracteres insuficiente")
                .MaximumLength(25).
                WithMessage("No Máximo Caracteres");

            RuleFor(o => o.ClientDoc)
                .NotEmpty()
                .WithMessage("Por Favor Preencher o Número do Documento")
                .MinimumLength(3)
                .WithMessage("Caracteres insuficiente")
                .MaximumLength(20).          
                WithMessage("No Máximo Caracteres");

            RuleFor(o => o.TotalCost)
                .NotEmpty()
                .WithMessage("Por Favor Preencher o Valor Total")
                .GreaterThanOrEqualTo(10);
        }
    }
}
