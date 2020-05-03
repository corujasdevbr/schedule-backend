using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Corujasdev.Schedule.Web.Api.Setup;
using CorujasDev.Schedulive.Application.DTOs;
using CorujasDev.Schedulive.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Corujasdev.Schedule.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IUserService _userService;
        private IConfiguration _config;

        public AccountController(IUserService userService, IConfiguration config)
        {
            _userService = userService;
            _config = config;
        }

        [HttpPost]
        [Route("login")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login(LoginDTO login)
        {
            try
            {
                var user = _userService.GetUserByEmailAndPassword(login.Email, login.Password);

                if (user == null)
                    return NotFound();

                var jwt = new JwtService(_config);
                var token = jwt.GenerateSecurityToken(user);

                return Ok(token);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var userItem = _userService.GetById(id);
                if (userItem == null)
                {
                    return NotFound();
                }

                return Ok(userItem);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("forgoutpassword/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ForgouPassword(string id)
        {
            try
            {
                var userItem = _userService.ForgoutPassword(new Guid(id));

                return Ok(userItem);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(UserDTO user)
        {
            try
            {
                var userTemp = _userService.Add(user);

                return CreatedAtAction(nameof(GetById), new { id = userTemp.Id }, userTemp);

            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}