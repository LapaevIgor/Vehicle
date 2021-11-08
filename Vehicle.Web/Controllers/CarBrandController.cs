using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Vehicle.BLL.Models;
using Vehicle.BLL.Services.Interfaces;
using Vehicle.ViewModels.CarBrands;

namespace Vehicle.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarBrandController : ControllerBase
    {
        private readonly ICarBrandService _carBrandService;
        private readonly IMapper _mapper;

        public CarBrandController(ICarBrandService carBrandService, IMapper mapper)
        {
            _carBrandService = carBrandService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get car brands", Description = "Get all car brands")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Search car brands found", typeof(IEnumerable<CarBrandModel>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Search car brands doesn't exist")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _carBrandService.GetAllAsync();
            var carBrands = _mapper.Map<IEnumerable<CarBrandModel>>(result);
            return carBrands == null ? NotFound() : Ok(carBrands);
        }

        [HttpGet, Route("{name}")]
        [SwaggerOperation(Summary = "Get car brand by name", Description = "Get car brand by name")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Search car brand found", typeof(CarBrandModel))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Search car brand doesn't exist")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var result = await _carBrandService.GetByNameAsync(name);
            var carBrand = _mapper.Map<CarBrandModel>(result);
            return carBrand == null ? NotFound() : Ok(carBrand);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add car brand", Description = "Add car brand")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Car brand added", typeof(CarBrandModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IActionResult> AddAsync(CarBrandModel carBrandModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var carBrand = await _carBrandService.AddAsync(_mapper.Map<CarBrand>(carBrandModel));
                    var result = _mapper.Map<CarBrandModel>(carBrand);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update car brand", Description = "Update car brand")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Car brand updated", typeof(CarBrandModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IActionResult> UpdateAsync(int id, CarBrandModel carBrandModel)
        {
            if (carBrandModel is not null && ModelState.IsValid)
            {
                try
                {
                    var carBrand = _mapper.Map<CarBrand>(carBrandModel);
                    carBrand.Id = id;
                    var result = await _carBrandService.UpdateAsync(carBrand);
                    return Ok(_mapper.Map<CarBrandModel>(result));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpDelete, Route("{name})")]
        [SwaggerOperation(Summary = "Delete car brand by name", Description = "Delete car brand by name")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Car brand deleted")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task DeleteByNameAsync(string name)
        {
            await _carBrandService.DeleteByNameAsync(name);
        }
    }
}
