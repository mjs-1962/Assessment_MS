using Assessment_MS.Models;
using FluentValidation;
using System.Text.RegularExpressions;
namespace Assessment_MS.Validations
{
    public class SurveyRecordValidator : AbstractValidator<SurveyRecord>
    {
        public SurveyRecordValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Please include your full name");
            RuleFor(x => x.FullName).Length(3, 50);
            RuleFor(x => x.EmailAddress).Length(0, 150);
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.BrightnessAcceptance).Must(BeTrueOrFalse).WithMessage("Please specify true or false");
            RuleFor(x => x.BrightnessLevel).NotNull().WithMessage("Please enter a value between 1 and 10");
            RuleFor(x => x.BrightnessLevel).InclusiveBetween(1, 10).WithMessage("Please enter a value between 1 and 10");
            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("Please include your address");
            RuleFor(x => x.AddressLine1).Length(3, 50);
            RuleFor(x => x.Town).NotEmpty().WithMessage("Please include your postal Town");
            RuleFor(x => x.Town).Length(3, 50);
            RuleFor(x => x.County).NotEmpty().WithMessage("Please include your county");
            RuleFor(x => x.County).Length(3, 50);
            RuleFor(x => x.Postcode).Must(BeAValidPostcode).WithMessage("Please specify a valid postcode");
        }

        private bool BeAValidPostcode(string? postcode)
        {
            Regex regex = new Regex(@"(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})");

            return string.IsNullOrEmpty(postcode) ? false : regex.IsMatch(postcode);

        }

        private bool BeTrueOrFalse(bool? brightnessAcceptance)
        {

            return (brightnessAcceptance == true || brightnessAcceptance == false) ? true : false;

        }
        

    }
}
