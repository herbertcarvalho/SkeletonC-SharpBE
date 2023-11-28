using Backend.Erp.Skeleton.Application.Commands.Produto;
using Backend.Erp.Skeleton.Application.DTOs.Request;
using Backend.Erp.Skeleton.Application.DTOs.Response;
using Backend.Erp.Skeleton.Application.Extensions;
using Backend.Erp.Skeleton.Application.Interfaces.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    //[Authorize]
    public class ProdutoController : BaseApiController<ProdutoController>
    {
        private readonly IProdutoQueryService _queryService;

        public ProdutoController(IMediator mediator, IProdutoQueryService queryService, ILogger<ProdutoController> logger) : base(mediator, logger)
        {
            _queryService = queryService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Find))]
        public async Task<ActionResult<PaginatedResult<ProdutoResponse>>> GetAllPagaination([FromQuery] PageOption pageOptions)
        {
            var result = await _queryService.GetAllAsync(pageOptions, default);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<ProdutoResponse>> GetByIdAsync(Guid id)
        {
            var result = await _queryService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> PostAsync([FromBody] ProdutoRequest request)
        {
            var sendRequest = new InsertProdutoCommand(default, request);
            var result = await Mediator.Send(sendRequest);

            return Created(string.Empty, result);
        }

        [HttpPut("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] ProdutoRequest request)
        {
            var sendRequest = new UpdateProdutoCommand(id, request);
            return Ok(await Mediator.Send(sendRequest));
        }

        [HttpDelete("{id}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteProdutoCommand(id)));
        }
    }
}