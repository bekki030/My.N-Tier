using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamInvigilator;
using N_Tier.Application.Services;

namespace N_Tier.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamInvigilatorController : ControllerBase
{
    private readonly IExamInvigilatorService _examInvigilatorService;

    public ExamInvigilatorController(IExamInvigilatorService examInvigilatorService)
    {
        _examInvigilatorService = examInvigilatorService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateExamInvigilatorResponseModel>> CreateAsync(
        [FromBody] CreateExamInvigilatorModel createExamInvigilatorModel)
    {
        if (createExamInvigilatorModel == null)
        {
            return BadRequest("Exam invigilator model is null.");
        }

        var response = await _examInvigilatorService.CreateAsync(createExamInvigilatorModel);

        return Ok(ApiResult<CreateExamInvigilatorResponseModel>.Success(response));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ExamInvigilatorResponseModel>>> GetAllByListIdAsync(Guid id)
    {
        var invigilators = await _examInvigilatorService.GetAllByListIdAsync(id);

        if (invigilators == null || !invigilators.Any())
        {
            return NotFound($"No invigilators found for Exam ID: {id}");
        }

        return Ok(ApiResult<IEnumerable<ExamInvigilatorResponseModel>>.Success(invigilators));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateExamInvigilatorResponseModel>> UpdateAsync(
        Guid id,
        [FromBody] UpdateExamInvigilatorModel updateExamInvigilatorModel)
    {
        if (updateExamInvigilatorModel == null)
        {
            return BadRequest("Update model is null.");
        }

        try
        {
            var response = await _examInvigilatorService.UpdateAsync(id, updateExamInvigilatorModel);
            return Ok(ApiResult<UpdateExamInvigilatorResponseModel>.Success(response));
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Invigilator with ID {id} not found.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel>> DeleteAsync(Guid id)
    {
        try
        {
            var response = await _examInvigilatorService.DeleteAsync(id);
            return Ok(ApiResult<BaseResponseModel>.Success(response));
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Invigilator with ID {id} not found.");
        }
    }
}
