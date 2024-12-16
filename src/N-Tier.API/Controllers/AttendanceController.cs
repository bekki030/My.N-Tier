using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Attendance;
using N_Tier.Application.Services;

namespace N_Tier.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateAttendanseResponseModel>> CreateAsync(
        [FromBody] CreateAttendanceModel createAttendanceModel)
    {
        if (createAttendanceModel == null)
        {
            return BadRequest("Attendance model is null.");
        }

        var response = await _attendanceService.CreateAsync(createAttendanceModel);

        return Ok(ApiResult<CreateAttendanseResponseModel>.Success(response));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<AttendanceResponseModel>>> GetAllByListIdAsync(
        Guid id)
    {
        var attendances = await _attendanceService.GetAllByListIdAsync(id);

        if (attendances == null || !attendances.Any())
        {
            return NotFound($"No attendance records found for ID: {id}");
        }

        return Ok(ApiResult<IEnumerable<AttendanceResponseModel>>.Success(attendances));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateAttendanceResponseModel>> UpdateAsync(
        Guid id,
        [FromBody] UpdateAttendanceModel updateAttendanceModel)
    {
        if (updateAttendanceModel == null)
        {
            return BadRequest("Update model is null.");
        }

        try
        {
            var updatedAttendance = await _attendanceService.UpdateAsync(id, updateAttendanceModel);
            return Ok(ApiResult<UpdateAttendanceResponseModel>.Success(updatedAttendance));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("details/{id}")]
    public async Task<ActionResult<AttendanceResponseModel>> GetByIdAsync(
        Guid id)
    {
        var attendances = await _attendanceService.GetAllByListIdAsync(id);
        var attendance = attendances.FirstOrDefault();
        if (attendance == null)
        {
            return NotFound($"Attendance with ID {id} not found.");
        }

        return Ok(ApiResult<IEnumerable<AttendanceResponseModel>>.Success(attendances));
    }
}
