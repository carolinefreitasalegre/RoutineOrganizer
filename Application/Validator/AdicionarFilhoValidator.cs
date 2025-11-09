using Application.Dtos.Request;
using FluentValidation;

namespace Application.Validator
{
    public class AdicionarFilhoValidator : AbstractValidator<FilhoRequest>
    {
        public AdicionarFilhoValidator()
        {
            RuleFor(u => u.Nome)
              .NotEmpty().WithMessage("O nome é obrigatório.")
              .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.")
              .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(u => u.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Today).WithMessage("A data de nascimento deve ser anterior à data atual.")
                .Must(TerMaisDeUmAno)
                    .WithMessage("O usuário deve ter pelo menos 1 ano de idade.");
        }

        private bool TerMaisDeUmAno(DateTime dataNascimento)
        {
            var idade = DateTime.Today.Year - dataNascimento.Year;
            if (dataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--;
            return idade >= 1;
        }
    }
}
