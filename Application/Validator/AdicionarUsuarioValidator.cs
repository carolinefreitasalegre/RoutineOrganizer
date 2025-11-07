using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validator
{
    public class AdicionarUsuarioValidator : AbstractValidator<UsuarioRequest>
    {
        public AdicionarUsuarioValidator()
        {

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("Formato de email inválido.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.")
                .Matches("[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
                .Matches("[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula.")
                .Matches("[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                .Matches(@"[!@#$%&*\-_=+]").WithMessage("A senha deve conter pelo menos um caractere especial (!, @, #, $, %, &, *, -, _, +, =).");

            RuleFor(x => x.TipoPlano)
                .IsInEnum().WithMessage("O tipo de plano informado é inválido.");
        }

    }
}
