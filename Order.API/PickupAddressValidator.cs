using FluentValidation;
using Order.API.Models;

namespace Order.API
{
    public class PickupAddressValidator : AbstractValidator<PickupAddress> 
    {
        string regexPatternUnit = @"^(0|1|2|3|4|5|6|7|8|9)\d$";
        string regexPatternStreet = @"^(?:\s+[A-Za-z]+)+\s+$";
        string regexPatternCity = @"^[A-Za-z]{4,20}$";
        string regexPaternSubrub = @"^[A-Za-z_][a-zA-Z_ ]{50}$";
        string regexPatternPostCode = @"^[0-9]{4}$";
        public PickupAddressValidator()
        {
            RuleFor(x => x.Unit).NotEmpty().Matches(regexPatternUnit).WithMessage("Please specify a valid unit");
            RuleFor(x => x.Street).NotEmpty().Matches(regexPatternStreet).WithMessage("Please specify a valid street name");
            RuleFor(x => x.City).NotEmpty().Matches(regexPatternCity).WithMessage("Please specify a valid city");
            RuleFor(x => x.Suburb).NotEmpty().Matches(regexPaternSubrub).WithMessage("Please specify a valid suburb");
            RuleFor(x => x.Postcode).NotEmpty().Matches(regexPatternPostCode).WithMessage("Please specify a valid postcode");
        }
    }
}
