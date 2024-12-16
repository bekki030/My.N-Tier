using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Shift;
using N_Tier.Application.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateShiftResponseModel>> CreateAsync(
             CreateShiftModel createShiftModel)
        {
            if (createShiftModel == null)
            {
                return BadRequest("Shift model is null.");
            }

            var response = await _shiftService.CreateAsync(createShiftModel);

            return Ok(ApiResult<CreateShiftResponseModel>.Success(response));
        }

        [HttpGet("Shift/{id}")]
        public async Task<ActionResult<IEnumerable<ShiftResponseModel>>> GetAllByExamIdAsync(
            Guid id)
        {
            var shifts = await _shiftService.GetAllByListIdAsync(id);
            return Ok(ApiResult<IEnumerable<ShiftResponseModel>>.Success(shifts));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateShiftResponseModel>> UpdateAsync(
            Guid id,
             UpdateShiftModel updateShiftModel)
        {
            if (updateShiftModel == null)
            {
                return BadRequest("Updated shift model is null.");
            }

            try
            {
                var response = await _shiftService.UpdateAsync(id, updateShiftModel);
                return Ok(ApiResult<UpdateShiftResponseModel>.Success(response));
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Shift with ID {id} not found.");
            }
        }
    }
}
