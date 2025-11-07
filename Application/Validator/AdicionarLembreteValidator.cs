using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validator
{
    public class AdicionarLembreteValidator : AbstractValidator<LembreteRequest>
    {
        public AdicionarLembreteValidator()
        {
            RuleFor(x => x.Mensagem)
            .NotEmpty().WithMessage("A mensagem é obrigatória.")
            .MaximumLength(500).WithMessage("A mensagem deve ter no máximo 500 caracteres.");

            RuleFor(x => x.DataHora)
                .NotEmpty().WithMessage("A data e hora do lembrete são obrigatórias.")
                .GreaterThan(DateTime.Now)
                .WithMessage("A data e hora do lembrete devem ser futuras.");

            RuleFor(x => x.UsuarioId)
                .GreaterThan(0).WithMessage("O usuário associado ao lembrete deve ser informado.");
        }
    }
}
