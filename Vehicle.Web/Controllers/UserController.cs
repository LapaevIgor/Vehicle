using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Vehicle.BLL.Models;
using Vehicle.BLL.Services.Interfaces;
using Vehicle.ViewModels.Users;

namespace Vehicle.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get users", Description = "Get all users")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Search users found", typeof(IEnumerable<UserModel>))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Search users doesn't exist")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();
            var users = _mapper.Map<IEnumerable<UserModel>>(result);
            return users == null ? NotFound() : Ok(users);
        }

        [HttpGet, Route("{id}")]
        [SwaggerOperation(Summary = "Get user by id", Description = "Get user by id")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Search user found", typeof(UserModel))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Search user doesn't exist")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            var users = _mapper.Map<UserModel>(result);
            return users == null ? NotFound() : Ok(users);
        }

        /// <summary>
        /// Add user
        /// </summary>
        /// <param name="userModel">User model</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Add user", Description = "Add user")]
        [SwaggerResponse((int)HttpStatusCode.OK, "User profile added", typeof(UserModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IActionResult> AddAsync(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userService.AddAsync(_mapper.Map<User>(userModel));
                    var result = _mapper.Map<UserModel>(user);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update user", Description = "Update user")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Profile updated", typeof(UserModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Ivalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task<IActionResult> UpdateAsync(int id, UserModel userModel)
        {
            if (userModel is not null && ModelState.IsValid)
            {
                try
                {
                    var user = _mapper.Map<User>(userModel);
                    user.Id = id;
                    var result = await _userService.UpdateAsync(user);
                    return Ok(_mapper.Map<UserModel>(result));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return BadRequest();
        }

        [HttpDelete, Route("{id})")]
        [SwaggerOperation(Summary = "Delete user by id", Description = "Delete user by id")]
        [SwaggerResponse((int)HttpStatusCode.OK, "User deleted", typeof(UserModel))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public async Task DeleteByIdAsync(int id)
        {
            await _userService.DeleteByIdAsync(id);
        }
    }
}
