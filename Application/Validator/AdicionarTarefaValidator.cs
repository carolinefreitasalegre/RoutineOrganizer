using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validator
{
    public class AdicionarTarefaValidator : AbstractValidator<TarefaRequest>
    {
        public AdicionarTarefaValidator()
        {
            RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("A descrição é obrigatória.")
            .MaximumLength(255).WithMessage("A descrição deve ter no máximo 255 caracteres.");

            RuleFor(x => x.Prioridade)
                .IsInEnum().WithMessage("A prioridade informada é inválida.");

            RuleFor(x => x.DataPrevista)
                .NotEmpty().WithMessage("A data prevista é obrigatória.")
                .GreaterThan(DateTime.Now.Date)
                .WithMessage("A data prevista deve ser uma data futura.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("O status informado é inválido.");

            RuleFor(x => x.UsuarioId)
                .GreaterThan(0).WithMessage("O usuário deve ser informado.");

        }
    }
}
