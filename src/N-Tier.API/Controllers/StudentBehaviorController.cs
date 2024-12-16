using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.StudentBehavior;
using N_Tier.Application.Services;

namespace N_Tier.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentBehaviorController : ControllerBase
{
    private readonly IStudentBehaviorService _studentBehaviorService;

    public StudentBehaviorController(IStudentBehaviorService studentBehaviorService)
    {
        _studentBehaviorService = studentBehaviorService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateStudentBehaviorResponseModel>> CreateAsync(
        CreateStudentBehaviorModel createStudentBehaviorModel)
    {
        if (createStudentBehaviorModel == null)
        {
            return BadRequest("Student behavior model is null.");
        }

        var response = await _studentBehaviorService.CreateAsync(createStudentBehaviorModel);

        return Ok(ApiResult<CreateStudentBehaviorResponseModel>.Success(response));
    }

    [HttpGet("student/{id}")]
    public async Task<ActionResult<IEnumerable<StudentBehaviorResponseModel>>> GetAllByStudentIdAsync(
        Guid id)
    {
        var behaviors = await _studentBehaviorService.GetAllByListIdAsync(id);
        return Ok(ApiResult<IEnumerable<StudentBehaviorResponseModel>>.Success(behaviors));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateStudentBehaviorResponseModel>> UpdateAsync(
        Guid id,
         UpdateStudentBehaviorModel updateStudentBehaviorModel)
    {
        if (updateStudentBehaviorModel == null)
        {
            return BadRequest("Updated student behavior model is null.");
        }

        try
        {
            var response = await _studentBehaviorService.UpdateAsync(id, updateStudentBehaviorModel);
            return Ok(ApiResult<UpdateStudentBehaviorResponseModel>.Success(response));
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Student behavior with ID {id} not found.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel>> DeleteAsync(
        Guid id)
    {
        try
        {
            var response = await _studentBehaviorService.DeleteAsync(id);
            return Ok(ApiResult<BaseResponseModel>.Success(response));
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Student behavior with ID {id} not found.");
        }
    }
}
