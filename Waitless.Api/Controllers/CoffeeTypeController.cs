﻿// using Ardalis.Result;
// using Waitless.BLL.Filters;
// using Waitless.Dto;
// using Microsoft.AspNetCore.Mvc;
// using Waitless.BLL.Services.BeverageTypeService;
// using Waitless.DTO.CoffeeTypeDtos;
//
// namespace Waitless.Api.Controllers
// {
//     public class CoffeeTypeController : ApiControllerBase
//     {
//         private readonly ICoffeeTypeService _coffeeCategoryService;
//
//         public CoffeeTypeController(ICoffeeTypeService coffeeCategoryService)
//         {
//             _coffeeCategoryService = coffeeCategoryService;
//         }
//
//         [HttpGet("get-all")]
//         public async Task<PagedResult<List<CoffeeTypeDto>>> GetAll([FromQuery] BeverageTypeFilter filter)
//         {
//             return await _coffeeCategoryService.GetAll(filter);
//         }
//
//         [HttpGet("get-by-id")]
//         public async Task<Result<CoffeeTypeDto>> Get(long id)
//         {
//             return await _coffeeCategoryService.GetById(id);
//         }
//
//         [HttpPost("add")]
//         [DisableRequestSizeLimit]
//         public async Task<Result> Add(AddCoffeeTypeDto dto)
//         {
//             return await _coffeeCategoryService.Add(dto);
//         }
//
//         [HttpPost("update")]
//         [DisableRequestSizeLimit]
//         public async Task<Result> Update(UpdateCoffeeTypeDto dto)
//         {
//             return await _coffeeCategoryService.Update(dto);
//         }
//
//         [HttpPost("delete")]
//         public async Task<Result> Delete(BaseDto dto)
//         {
//             return await _coffeeCategoryService.Delete(dto.Id);
//         }
//     }
// }
