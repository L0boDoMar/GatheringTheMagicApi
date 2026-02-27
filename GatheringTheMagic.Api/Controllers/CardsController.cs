using GatheringTheMagic.Application.UseCases.Cards;
using GatheringTheMagic.Application.UseCases.Cards.GetAllCard;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GatheringTheMagic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllCardsResponse>> GetAll(string itemsPerPage, string page, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllCardsRequest(itemsPerPage,page), cancellationToken);
            return Ok(response);
        }
    }
}
