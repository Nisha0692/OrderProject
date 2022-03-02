using FluentValidation;
using Order.API.Models;

namespace Order.API
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        string regexPatternDateTime = @"^(\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2})$";
        public OrderValidator()
        {
            RuleFor(x => x.RequestedPickupTime).NotEmpty().Matches(regexPatternDateTime);
            RuleFor(x => x.PickupInstructions).NotEmpty().Length(0, 200);
            RuleFor(x => x.DeliveryInstructions).NotEmpty().Length(0, 200);
            RuleFor(x => x.PickupAddress).NotNull().SetValidator(new PickupAddressValidator());
            RuleFor(x => x.DeliveryAddress).NotNull().SetValidator(new DeliveryAddressValidator());
            RuleForEach(x => x.Items).SetValidator(new ItemValidator());
        }
    }
}
