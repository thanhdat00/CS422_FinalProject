using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Queries;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
{
    [Route("/api/products")]
    [Produces("application/json")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existing products.
        /// </summary>
        /// <returns>List of products.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<ProductResource>), 200)]
        public async Task<QueryResultResource<ProductResource>> ListAsync([FromQuery] ProductsQueryResource query)
        {
            var productsQuery = _mapper.Map<ProductsQueryResource, ProductsQuery>(query);
            var queryResult = await _productService.ListAsync(productsQuery);

            var resource = _mapper.Map<QueryResult<Product>, QueryResultResource<ProductResource>>(queryResult);
            return resource;
        }

        [HttpGet("sortbyprice")]
        public async Task<List<ProductResource>> SortProductByPriceAsync()
        {
            var products = await _productService.SortProduct("price");
            var resource = _mapper.Map<List<Product>, List<ProductResource>> (products);
            return resource;
        }

        [HttpGet("sortbyname")]
        public async Task<List<ProductResource>> SortProductByNameAsync()
        {
            var products = await _productService.SortProduct("name");
            var resource = _mapper.Map<List<Product>, List<ProductResource>>(products);
            return resource;
        }

        [HttpGet("sortbyquantity")]
        public async Task<List<ProductResource>> SortProductByQuantityAsync()
        {
            var products = await _productService.SortProduct("quantity");
            var resource = _mapper.Map<List<Product>, List<ProductResource>>(products);
            return resource;
        }

        [HttpGet("sortbyrating")]
        public async Task<List<ProductResource>> SortProductByRatingAsync()
        {
            var products = await _productService.SortProduct("rating");
            var resource = _mapper.Map<List<Product>, List<ProductResource>>(products);
            return resource;
        }
        /// <summary>
        /// Saves a new product.
        /// </summary>
        /// <param name="resource">Product data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
        {
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.SaveAsync(product);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        /// <summary>
        /// Updates an existing product according to an identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <param name="resource">Product data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
        {
            var product = _mapper.Map<SaveProductResource, Product>(resource);
            var result = await _productService.UpdateAsync(id, product);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(productResource);
        }

        /// <summary>
        /// Deletes a given product according to an identifier.
        /// </summary>
        /// <param name="id">Product identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var categoryResource = _mapper.Map<Product, ProductResource>(result.Resource);
            return Ok(categoryResource);
        }
    }
}