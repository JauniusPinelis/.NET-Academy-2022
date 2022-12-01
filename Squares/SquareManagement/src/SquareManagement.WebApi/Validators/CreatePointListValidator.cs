using FluentValidation;
using SquareManagement.WebApi.Dtos.PointLists;

namespace SquareManagement.WebApi.Validators
{
    public class CreatePointListValidator : AbstractValidator<CreatePointList>
    {
        public CreatePointListValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(4, 30);
            RuleFor(x => x.Name).Must(NotBeForbiddenName).WithMessage("Forbidden name");
        }

        private bool NotBeForbiddenName(string name)
        {
            List<string> forbidden = new List<string>()
            {
                "Jaunius", "Gustas"
            };
            if (forbidden.Contains(name))
            {
                return false;
            }

            return true;
        }
    }
}
