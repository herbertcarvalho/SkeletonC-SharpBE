using Backend.Erp.Skeleton.Application.Interfaces.Queries;
using Backend.Erp.Skeleton.Application.Commands.Orcamento;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.DTOs.Response;
using Backend.Erp.Skeleton.Application.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    //[Authorize]
    public class OrcamentoController : BaseApiController<OrcamentoController>
    {
        private readonly IOrcamentoQueryService _queryService;

        public OrcamentoController(IMediator mediator, IOrcamentoQueryService queryService, ILogger<OrcamentoController> logger) : base(mediator, logger)
        {
            _queryService = queryService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
        public async Task<ActionResult<PaginatedResult<OrcamentoResponse>>> GetAllPagaination([FromQuery] PageOption pageOptions)
        {
            var result = await _queryService.GetAllAsync(pageOptions);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<OrcamentoResponse>> GetByIdAsync(Guid id)
        {
            var result = await _queryService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> PostAsync([FromBody] OrcamentoRequest request)
        {
            var sendRequest = new InsertOrcamentoCommand(request);
            var result = await Mediator.Send(sendRequest);

            return Created(string.Empty, result);
        }

        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] OrcamentoRequest request)
        {
            var sendRequest = new UpdateOrcamentoCommand(id, request);
            return Ok(await Mediator.Send(sendRequest));
        }

        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteOrcamentoCommand(id)));
        }
    }
}