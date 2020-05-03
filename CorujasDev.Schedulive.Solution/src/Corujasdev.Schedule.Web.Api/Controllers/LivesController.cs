using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CorujasDev.Schedulive.Application.DTOs;
using CorujasDev.Schedulive.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Corujasdev.Schedule.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivesController : ControllerBase
    {
        private readonly ILiveService _liveService;

        public LivesController(ILiveService liveService)
        {
            _liveService = liveService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var brandItem = _liveService.GetById(id);

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
        public IActionResult GetAll()
        {
            try
            {
                var list = _liveService.GetAll();

                return Ok(list);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("category/{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetByCategory(Guid id)
        {
            try
            {
                var list = _liveService.GetByCategory(id);

                return Ok(list);
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(LiveDTO live)
        {
            try
            {
                var userTemp = _liveService.Add(live);

                return CreatedAtAction(nameof(GetById), new { id = userTemp.Id }, userTemp);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(LiveDTO live, Guid id)
        {
            try
            {
                var liveItem = _liveService.GetById(id);

                _liveService.Update(live, id);

                return Ok(live);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}