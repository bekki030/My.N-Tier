using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Event;
using N_Tier.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.API.Controllers
{
    public class EventController : ApiController
    {
        private readonly IEventServise _eventService;

        public EventController(IEventServise eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateEventModel createEventModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _eventService.CreateAsync(createEventModel);
            return Ok(ApiResult<CreateEventResponseModel>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByListIdAsync(Guid id)
        {
            var events = await _eventService.GetAllByListIdAsync(id);

            if (events == null)
                return NotFound();

            return Ok(ApiResult<IEnumerable<EventResponseModel>>.Success(events));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateEventModel updateEventModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _eventService.UpdateAsync(id, updateEventModel);
                return Ok(ApiResult<UpdateEventResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update event.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _eventService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to delete event.", error = ex.Message });
            }
        }
    }
}
