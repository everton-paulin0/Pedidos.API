using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Core.Entities;
using Pedidos.Infraestucture;
using Pedidos_Application.Commands.CancelOrder;
using Pedidos_Application.Commands.CompleteOrder;
using Pedidos_Application.Commands.DeleteOrder;
using Pedidos_Application.Commands.InsertOrder;
using Pedidos_Application.Commands.SetAsPemding;
using Pedidos_Application.Commands.UpdateOrder;
using Pedidos_Application.Model;
using Pedidos_Application.Queries.GetAllOrderQuery;
using Pedidos_Application.Queries.GetOrderById;
using Pedidos_Application.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IOrderServices _service;
        private readonly IMediator _mediator;
        public OrderController(AppDbContext context, IOrderServices service, IMediator mediator)
        {

            _context = context;
            _service = service;
            _mediator = mediator;
        }

        
        /*
        [HttpPost]
        public async Task<IActionResult> PostAsync ([FromServices] AppDbContext context,[FromBody] CreateOrderInputModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var orders = new Order
            {
                Product = order.Product,
                Quantity = order.Quantity,
                ClientDoc = order.ClientDoc,
                ClientName = order.ClientName,
                Price = order.Price,
                TotalCost = order.TotalCost
            };


            try
            {
                await context.Orders.AddAsync(orders);
                await context.SaveChangesAsync();

                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        */
        
        [HttpPost]
        public async Task<IActionResult> Post(InsertOrderCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }
        
        
        [HttpGet]
        public async Task<IActionResult> Get(string search = "")
        {
            //var result = _service.GetAll();
            var query = new GetAllOrdersQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetOrderByIdQuery(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateOrderCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        
        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {
            var result = await _mediator.Send(new CompleteOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPatch("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            var result = await _mediator.Send(new CancelOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }

        [HttpPatch("{id}/paymentpending")]
        public async Task<IActionResult> CSetPaymentPending(int id)
        {
            var result = await _mediator.Send(new SetAsPendingOrderCommand(id));

            if (!result.IsSucess)
            {
                return BadRequest(result.Message);
            }

            return NoContent();
        }
    }
}
