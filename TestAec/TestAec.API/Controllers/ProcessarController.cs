using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestAec.API.Commands;
using TestAec.API.Queries.Abstractions;
using TestAec.API.Requests;
using TestAec.Domain.Exceptions;

namespace TestAec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessarController : ControllerBase
    {
        private readonly ICardQuery CardQuery;

        public ProcessarController(ICardQuery cardQuery)
        {
            CardQuery = cardQuery;
        }


        /// <summary>
        /// Processa os dados do site Aec
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(), Produces("application/json", Type = typeof(IApplicationResult<bool>))]
        public async Task<IActionResult> Processar([FromServices] IMediator mediator, [FromBody] ProcessarDadosCommand command)
            => await mediator.Send(command);


        /// <summary>
        /// Obtém um card por id
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        [HttpGet("{cardId}"), Produces("application/json", Type = typeof(IApplicationResult<CardDetalhesViewModel>))]
        public async Task<IActionResult> ObterCardPorId([FromRoute] Guid cardId) 
            => await CardQuery.ObterCardPorId(cardId);

        /// <summary>
        /// Obtém os cards 
        /// </summary>
        /// <returns></returns>
        [HttpGet(), Produces("application/json", Type = typeof(IApplicationResult<IEnumerable<CardDetalhesViewModel>>))]
        public async Task<IActionResult> ObterCards() 
            => await CardQuery.ObterCards();
    }
}
