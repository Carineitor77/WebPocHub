using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPocHub.Dal;
using WebPocHub.Models;

namespace WebPocHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PublicPolicy")]
    public class EventsController : ControllerBase
    {
        private readonly ICommonRepository<Event> _eventsRepository;

        public EventsController(ICommonRepository<Event> repository)
        {
            _eventsRepository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Employee, Hr")]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            var events = await _eventsRepository.GetAll();

            if (events.Count <= 0)
            {
                return NotFound();
            }

            return Ok(events);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Employee, Hr")]
        public async Task<ActionResult<Event>> GetDetails(int id)
        {
            var e = await _eventsRepository.GetDetails(id);
            return e == null ? NotFound() : Ok(e);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Employee, Hr")]
        public async Task<ActionResult> Create(Event? e)
        {
            var result = await _eventsRepository.Insert(e);

            if (result != null)
            {
                return CreatedAtAction("GetDetails", new { id = e.EventId }, e);
            }

            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Employee, Hr")]
        public async Task<ActionResult> Update(Event e)
        {
            var result = await _eventsRepository.Update(e);

            if (result != null)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Hr")]
        public async Task<ActionResult> Delete(int id)
        {
            var e = await _eventsRepository.GetDetails(id);

            if (e == null)
            {
                return NotFound();
            }
            else
            {
                await _eventsRepository.Delete(e.EventId);
                return NoContent();
            }
        }
    }
}
