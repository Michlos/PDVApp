﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PDVApp.Api.DTOs;
using PDVApp.Api.Services;

namespace PDVApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
    {
        var productsDto = await _productService.GetProducts();
        if (productsDto is null)
            return NotFound("No products found.");
        return Ok(productsDto);
    }

    [HttpGet("{id: int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDTO>> Get(int id)
    {
        var productDto = await _productService.GetProductById(id);
        if (productDto is null)
            return NotFound("No product found.");
        return Ok(productDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDTO productDto)
    {
        //if (productDto is null)
        //    return BadRequest("Invalid Data");
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _productService.AddProduct(productDto);
        return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id }, productDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProductDTO productDto)
    {
        //if (id != productDto.Id)
        //    return BadRequest("Invalid Data");
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _productService.UpdateProduct(productDto);
        return Ok(productDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var productDto = await _productService.GetProductById(id);
        if (productDto is null)
            return NotFound("No product found.");
        await _productService.RemoveProduct(id);
        return Ok(productDto);
    }

}
