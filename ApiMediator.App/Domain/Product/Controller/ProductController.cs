using ApiMediator.App.Domain.Product.DTOs;
using ApiMediator.App.Domain.Product.Handlers.Commands;
using ApiMediator.App.Domain.Product.Handlers.Queries;
using ApiMediator.Core.Base.Controller;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMediator.App.Domain.Product.Controller
{
    public class ProductController : BaseController
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id, CancellationToken ct)
        {
            var result = await mediator.FetchAsync(new GetProductByIdQuery(id), ct);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductDTO dto, CancellationToken ct)
        {
            var result = await mediator.SendAsync(new CreateProductCommand(dto.Name, dto.Price), ct);

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductDTO dto, CancellationToken ct)
        {
            // todo - add mapper and send model.product to command

            var result = await mediator.SendAsync(new UpdateProductCommand(id, dto.Name, dto.Price), ct);

            return Ok(result);
        }
    }
}
