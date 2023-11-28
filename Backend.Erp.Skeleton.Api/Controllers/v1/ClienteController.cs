using Backend.Erp.Skeleton.Application.Commands.Cliente;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.DTOs.Response;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Application.Interfaces.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    //[Authorize]
    public class ClienteController : BaseApiController<ClienteController>
    {
        private readonly IClienteQueryService _queryService;

        public ClienteController(IMediator mediator, IClienteQueryService queryService, ILogger<ClienteController> logger) : base(mediator, logger)
        {
            _queryService = queryService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
        public async Task<ActionResult<PaginatedResult<ClienteResponse>>> GetAllPagaination([FromQuery] PageOption pageOptions)
        {
            var result = await _queryService.GetAllAsync(pageOptions);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<ClienteResponse>> GetByIdAsync(Guid id)
        {
            var result = await _queryService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("{doc}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<OrcamentoResponse>> GetByDocAsync(string doc)
        {
            var result = await _queryService.GetByDocAsync(doc);
            return Ok(result);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> PostAsync([FromForm] ClienteRequest request, IFormFile file)
        {
            var sendRequest = new InsertClienteCommand(file, request);
            var result = await Mediator.Send(sendRequest);

            return Created(string.Empty, result);
        }

        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] ClienteRequest request)
        {
            var sendRequest = new UpdateClienteCommand(id, request);
            return Ok(await Mediator.Send(sendRequest));
        }

        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteClienteCommand(id)));
        }
    }
}