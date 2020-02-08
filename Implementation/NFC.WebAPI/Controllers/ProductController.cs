﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NFC.Application.Contracts;
using NFC.Common.Constants;
using NFC.Persistence.Contracts;
using NFC.Persistence.Services;
using System.Threading.Tasks;

namespace NFC.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="NFC.WebAPI.Controllers.AbstractController" />
    [ApiController]
    [Route(ApiConst.RootRoute)]
    public class ProductController : AbstractController
    {
        /// <summary>
        /// The product service
        /// </summary>
        private readonly IProductService productService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="firebaseService">The firebase service.</param>
        /// <param name="productService">The product service.</param>
        public ProductController(IMapper mapper, IProductService productService) : base(mapper)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiConst.All)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromBody] ProductPagingRequest request)
        {
            var result = await ExecuteAction(() => this.productService.GetAllPaging(request.PageNumber, request.PageSize, request.GetLastest));
            return CreatedAtAction(nameof(GetAll), result);
        }

        /// <summary>
        /// Gets the high light.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiConst.All4Home)]
        public async Task<IActionResult> GetAllProduct([FromBody] ProductPagingRequest request)
        {
            var result = await ExecuteAction(() => this.productService.GetAllPaging(request.PageNumber, request.PageSize, request.GetLastest));
            return CreatedAtAction(nameof(GetAllProduct), result);
        }

        /// <summary>
        /// Gets the highlight.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(ApiConst.Highlight)]
        public async Task<IActionResult> GetHighlight()
        {
            var result = await ExecuteAction(() => this.productService.GetHighlight());
            return CreatedAtAction(nameof(GetHighlight), result);
        }

        /// <summary>
        /// Creates the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiConst.Create)]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ProductRequest request)
        {
            var data = this.mapper.Map<ProductRequest, ProductDto>(request);
            var result = await ExecuteAction(() => this.productService.Add(data));
            return CreatedAtAction(nameof(Create), result);
        }

        /// <summary>
        /// Updates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route(ApiConst.Update)]
        public async Task<IActionResult> Update(long id, [FromBody] ProductRequest request)
        {
            var data = this.mapper.Map<ProductRequest, ProductDto>(request);
            var result = await ExecuteAction(() => this.productService.Update(id, data));
            return CreatedAtAction(nameof(Update), result);
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
        [Route(ApiConst.Delete)]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await ExecuteAction(() => this.productService.Delete(id));
            return CreatedAtAction(nameof(Delete), result);
        }
    }
}
