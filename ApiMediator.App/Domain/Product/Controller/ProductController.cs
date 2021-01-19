using ApiMediator.App.Domain.Product.DTOs;
using ApiMediator.App.Domain.Product.Handlers.Commands;
using ApiMediator.Core.Base.Controller;
using Microsoft.AspNetCore.Mvc;
using SimpleSoft.Mediator;
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

        //[HttpGet]
        //public async Task<IEnumerable<ProductModel>> SearchAsync([FromQuery] string filterQ, [FromQuery] int? skip, [FromQuery] int? take, CancellationToken ct)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpGet("{id:guid}")]
        //public async Task<ProductModel> GetByIdAsync([FromRoute] Guid id, CancellationToken ct)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateProductDTO dto, CancellationToken ct)
        {
            var result = await mediator.SendAsync(new CreateProductCommand(dto.Name, dto.Price), ct);

            return Ok(result);
        }

        //[HttpPut("{id:guid}")]
        //public async Task UpdateAsync([FromRoute] Guid id, [FromBody] UpdateProductModel model, CancellationToken ct)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpDelete("{id:guid}")]
        //public async Task DeleteAsync([FromRoute] Guid id, CancellationToken ct)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
