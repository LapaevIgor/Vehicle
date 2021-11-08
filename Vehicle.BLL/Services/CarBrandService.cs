using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.BLL.Exceptions;
using Vehicle.BLL.Models;
using Vehicle.BLL.Services.Interfaces;
using Vehicle.DAL.Entities;
using Vehicle.DAL.Interfaces;

namespace Vehicle.BLL.Services
{
    public class CarBrandService : ICarBrandService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public CarBrandService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CarBrand> AddAsync(CarBrand carBrand)
        {
            var existingCarBrand = await _uow.CarBrandRepository.GetByNameAsync(carBrand.Name);

            if (existingCarBrand is not null)
            {
                throw new CarBrandException("Car brand already exists");
            }

            var carBrandDb = _mapper.Map<CarBrandDb>(carBrand);
            var result = await _uow.CarBrandRepository.CreateAsync(carBrandDb);
            return _mapper.Map<CarBrand>(result);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var existingCarBrand = await _uow.CarBrandRepository.GetByIdAsync(id);

            if (existingCarBrand is null)
            {
                throw new CarBrandException("Car brand not found");
            }

            await _uow.CarBrandRepository.DeleteByIdAsync(id);
        }
        
        public async Task DeleteByNameAsync(string name)
        {
            var existingCarBrand = await _uow.CarBrandRepository.GetByNameAsync(name);

            if (existingCarBrand is null)
            {
                throw new CarBrandException("Car brand not found");
            }

            await _uow.CarBrandRepository.DeleteByNameAsync(name);
        }

        public async Task<IEnumerable<CarBrand>> GetAllAsync()
        {
            var result = await _uow.CarBrandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarBrand>>(result);
        }

        public async Task<CarBrand> GetByIdAsync(int id)
        {
            var result = await _uow.CarBrandRepository.GetByIdAsync(id);
            return _mapper.Map<CarBrand>(result);
        }

        public async Task<CarBrand> GetByNameAsync(string name)
        {
            var result = await _uow.CarBrandRepository.GetByNameAsync(name);
            return _mapper.Map<CarBrand>(result);
        }

        public async Task<CarBrand> UpdateAsync(CarBrand carBrand)
        {
            var existingNameCarBrand = await _uow.CarBrandRepository.GetByNameAsync(carBrand.Name);

            //check for duplicate name of car brand
            if (existingNameCarBrand is not null)
            {
                throw new CarBrandException("Car brand with the same name already exists");
            }

            var result = await _uow.CarBrandRepository.UpdateAsync(_mapper.Map<CarBrandDb>(carBrand));
            return _mapper.Map<CarBrand>(result);
        }
    }
}
