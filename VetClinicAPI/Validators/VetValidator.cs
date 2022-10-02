using FluentValidation;

namespace VetClinicAPI.Validators
{
    public class VetValidator : AbstractValidator<Models.DTO.Vet>
    {
        public VetValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Birthday).Must(BeAValidDate).WithMessage("Please insert a valid date (yyyy-mm-dd");
        }

        private bool BeAValidDate(DateTime dateTime)
        {
            if (dateTime.CompareTo(DateTime.Now) >= 0)
            {
                return false;
            }

            return true;
        }
    }
}
