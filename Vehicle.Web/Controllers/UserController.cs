using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel;
using System.Net;
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


        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("Add new profile")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Invalid paramater format")]
        [SwaggerResponse((int)HttpStatusCode.OK, "User profile added", typeof(UserModel))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, "Something wrong")]
        public IActionResult Register(UserModel userModel)
        {
            //if (ModelState.IsValid)
            //{
                var user = _mapper.Map<User>(userModel);
                try
                {
                    var response =_userService.Add(user);
                    var result = _mapper.Map<UserModel>(user);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            //}

            return BadRequest();
        }
    }
}
