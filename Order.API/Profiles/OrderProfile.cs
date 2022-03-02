using AutoMapper;

namespace Order.API.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Entities.Orders, Models.OrderDto>();
            CreateMap<Models.OrderDto, Entities.Orders>();
        }
    }
}
