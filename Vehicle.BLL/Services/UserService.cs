using AutoMapper;
using System.Collections.Generic;
using System.Linq;
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

        public User Add(User user)
        {
            var existingUser = _uow.UserRepository.GetById(user.Id);
            
            if(existingUser is not null)
            {
                throw new UserException("User already exists");
            }

            var userDb = _mapper.Map<UserDb>(user);
            var result = _uow.UserRepository.Create(userDb);
            return _mapper.Map<User>(result);
        }

        public void Delete(User user)
        {
            var userDb = _mapper.Map<UserDb>(user);
            _uow.UserRepository.Delete(userDb);
        }

        public void DeleteById(int id)
        {
            var existingUser = _uow.UserRepository.GetById(id);

            if (existingUser is null)
            {
                throw new UserException("User not found");
            }

            _uow.UserRepository.DeleteById(id);
        }

        public IEnumerable<User> GetAll()
        {
            var result = _uow.UserRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<User>>(result);
        }

        public User GetById(int id)
        {
            var result = _uow.UserRepository.GetById(id);
            return _mapper.Map<User>(result);
        }

        public User Update(User user)
        {
            // Check for duplicate phone numbers
            if (user.UserPhoneNumbers != null && user.UserPhoneNumbers.Any(n => user.UserPhoneNumbers.Count(p => p.CheckPhoneNumberForDuplicate(n)) > 1))
            {
                throw new UserException("Duplicate phone numbers");
            }

            var result = _uow.UserRepository.Update(_mapper.Map<UserDb>(user));
            return _mapper.Map<User>(result);
        }
    }
}
