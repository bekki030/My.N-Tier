using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamGradingCriteria;
using N_Tier.Application.Services;

namespace N_Tier.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamGradingCriteriaController : ControllerBase
{
    private readonly IExamGradingCriteriaService _examGradingCriteriaService;

    public ExamGradingCriteriaController(IExamGradingCriteriaService examGradingCriteriaService)
    {
        _examGradingCriteriaService = examGradingCriteriaService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateExamGradingCriteriaResponseModel>> CreateAsync(
        [FromBody] CreateExamGradingCriteriaModel createExamGradingCriteriaModel)
    {
        if (createExamGradingCriteriaModel == null)
        {
            return BadRequest("Exam grading criteria model is null.");
        }

        var response = await _examGradingCriteriaService.CreateAsync(createExamGradingCriteriaModel);

        return Ok(ApiResult<CreateExamGradingCriteriaResponseModel>.Success(response));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ExamGradingCriteriaResponseModel>>> GetAllByListIdAsync(Guid id)
    {
        var gradingCriteriaList = await _examGradingCriteriaService.GetAllByListIdAsync(id);

        if (gradingCriteriaList == null || !gradingCriteriaList.Any())
        {
            return NotFound($"No grading criteria found for Exam ID: {id}");
        }

        return Ok(ApiResult<IEnumerable<ExamGradingCriteriaResponseModel>>.Success(gradingCriteriaList));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateExamGradingCriteriaResponseModel>> UpdateAsync(
        Guid id,
        [FromBody] UpdateExamGradingCriteriaModel updateExamGradingCriteriaModel)
    {
        if (updateExamGradingCriteriaModel == null)
        {
            return BadRequest("Update model is null.");
        }

        try
        {
            var response = await _examGradingCriteriaService.UpdateAsync(id, updateExamGradingCriteriaModel);
            return Ok(ApiResult<UpdateExamGradingCriteriaResponseModel>.Success(response));
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Grading criteria with ID {id} not found.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel>> DeleteAsync(Guid id)
    {
        try
        {
            var response = await _examGradingCriteriaService.DeleteAsync(id);
            return Ok(ApiResult<BaseResponseModel>.Success(response));
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Grading criteria with ID {id} not found.");
        }
    }
}
