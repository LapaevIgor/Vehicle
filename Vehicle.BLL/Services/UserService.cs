using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.BLL.Exceptions;
using Vehicle.BLL.Models;
using Vehicle.BLL.Services.Interfaces;
using Vehicle.DAL.Entities;
using Vehicle.DAL.Interfaces;

namespace Vehicle.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UserService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<User> AddAsync(User user)
        {
            var existingUser = await _uow.UserRepository.GetByIdAsync(user.Id);
            
            if(existingUser is not null)
            {
                throw new UserException("User already exists");
            }

            var userDb = _mapper.Map<UserDb>(user);
            var result = await _uow.UserRepository.CreateAsync(userDb);
            return _mapper.Map<User>(result);
        }

        public async Task DeleteAsync(User user)
        {
            var userDb = _mapper.Map<UserDb>(user);
            await _uow.UserRepository.DeleteAsync(userDb);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var existingUser = await _uow.UserRepository.GetByIdAsync(id);

            if (existingUser is null)
            {
                throw new UserException("User not found");
            }

            await _uow.UserRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var result = await _uow.UserRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<User>>(result);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var result = await _uow.UserRepository.GetByIdAsync(id);
            return _mapper.Map<User>(result);
        }

        public async Task<User> UpdateAsync(User user)
        {
            // Check for duplicate phone numbers
            if (user.UserPhoneNumbers != null && user.UserPhoneNumbers.Any(n => user.UserPhoneNumbers.Count(p => p.CheckPhoneNumberForDuplicate(n)) > 1))
            {
                throw new UserException("Duplicate phone numbers");
            }

            var result = await _uow.UserRepository.UpdateAsync(_mapper.Map<UserDb>(user));
            return _mapper.Map<User>(result);
        }
    }
}
