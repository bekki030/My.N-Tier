using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Room;
using N_Tier.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.API.Controllers
{
    public class RoomController : ApiController
    {
        private readonly IRoomServise _roomService;

        public RoomController(IRoomServise roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync( CreateRoomModel createRoomModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roomService.CreateAsync(createRoomModel);
            return Ok(ApiResult<CreateRoomResponseModel>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllRoomAsync(Guid id)
        {
            var rooms = await _roomService.GetAllRoomAsync(id);

            return Ok(ApiResult<IEnumerable<RoomResponseModel>>.Success(rooms));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateRoomModel updateRoomModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _roomService.UpdateAsync(id, updateRoomModel);
                return Ok(ApiResult<UpdateRoomResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update room.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _roomService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to delete room.", error = ex.Message });
            }
        }
    }
}
