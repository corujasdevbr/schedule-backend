using CorujasDev.Schedulive.Application.DTOs;
using CorujasDev.Schedulive.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;

namespace Corujasdev.Schedule.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        [Authorize()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var brandItem = _userService.GetById(id);
                if (brandItem == null)
                {
                    return NotFound();
                }

                return Ok(brandItem);
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        

        [HttpGet]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            try
            {
                var list = _userService.GetAll();

                return Ok(list);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        

        [HttpPut]
        [Route("{id}")]
        [Authorize()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(UserDTO user, Guid id)
        {
            try
            {
                var brandItem = _userService.GetById(id);
                if (brandItem == null)
                {
                    return NotFound();
                }

                _userService.Update(user, id);

                return StatusCode(204, user);

            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}