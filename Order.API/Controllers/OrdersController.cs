using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Order.API.Models;
using Microsoft.Extensions.Logging;
using Order.API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Order.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger _Logger;
        private readonly IOrderRepository _OrderRepository;
        private readonly IMapper _Mapper;

        public OrdersController(ILogger<OrdersController> logger, IOrderRepository orderRepository, IMapper mapper)
        {
            _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _OrderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            try
            {
                var ordersToReturn = await _OrderRepository.GetOrderAsync();
                var mappedOrders = _Mapper.Map<IEnumerable<OrderDto>>(ordersToReturn);
                if (mappedOrders == null)
                {
                    _Logger.LogDebug("Order information Not Found");
                    return NotFound();
                }
                return Ok(mappedOrders);
            }
            catch (Exception ex)
            {
                _Logger.LogCritical($"Exception while getting orders , {ex}");
                return StatusCode(500, "Problem loading the orders");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(int id)
        {
            try
            {
                var orderId = User.Claims.FirstOrDefault(o => o.Type == "userId")?.Value;
                if(!await _OrderRepository.OrderIdMatch(id))
                {
                    return Forbid();
                }
                var orderToReturn = await _OrderRepository.GetOrdersById(id);
                var mappedOrders = _Mapper.Map<IEnumerable<OrderDto>>(orderToReturn);
                if (mappedOrders == null)
                {
                    _Logger.LogDebug("Order information Not Found");
                    return NotFound();
                }

                return Ok(mappedOrders);
            }

            catch(Exception ex)
            {
                _Logger.LogCritical($"Exception while getting order for Id {id}, {ex}");
                return StatusCode(500, "Problem loading the orders");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto order)
        {
            var orderValidator = new OrderValidator();
            ValidationResult result = orderValidator.Validate(order);

            if(result.IsValid==false)
            {
                return BadRequest(result.Errors[0].ErrorMessage);
            }
            _Mapper.Map<Entities.Orders>(order);
            await _OrderRepository.SaveChangesAsync();
            return Ok();
        }

    }
}
