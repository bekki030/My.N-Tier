using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamAnswersheet;
using N_Tier.Application.Services;

namespace N_Tier.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamAnswersheetController : ControllerBase
{
    private readonly IExamAnswersheetService _examAnswersheetService;

    public ExamAnswersheetController(IExamAnswersheetService examAnswersheetService)
    {
        _examAnswersheetService = examAnswersheetService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateExamAnswersheetResponseModel>> CreateAsync(
        [FromBody] CreateExamAnswersheetModel createExamAnswerModel)
    {
        if (createExamAnswerModel == null)
        {
            return BadRequest("Exam answersheet model is null.");
        }

        var response = await _examAnswersheetService.CreateAsync(createExamAnswerModel);

        return Ok(ApiResult<CreateExamAnswersheetResponseModel>.Success(response));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<ExamAnswersheetResponseModel>>> GetAllByListIdAsync(Guid id)
    {
        var answersheets = await _examAnswersheetService.GetAllByListIdAsync(id);

        if (answersheets == null || !answersheets.Any())
        {
            return NotFound($"No exam answersheets found for ID: {id}");
        }

        return Ok(ApiResult<IEnumerable<ExamAnswersheetResponseModel>>.Success(answersheets));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UpdateExamAnswersheetResposeModel>> UpdateAsync(
        Guid id,
        [FromBody] UpdateExamAnswersheetModel updateExamAnswerModel)
    {
        if (updateExamAnswerModel == null)
        {
            return BadRequest("Update model is null.");
        }

        try
        {
            var response = await _examAnswersheetService.UpdateAsync(id, updateExamAnswerModel);
            return Ok(ApiResult<UpdateExamAnswersheetResposeModel>.Success(response));
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Exam answersheet with ID {id} not found.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponseModel>> DeleteAsync(Guid id)
    {
        try
        {
            var response = await _examAnswersheetService.DeleteAsync(id);
            return Ok(ApiResult<BaseResponseModel>.Success(response));
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Exam answersheet with ID {id} not found.");
        }
    }

    [HttpGet("details/{id}")]
    public async Task<ActionResult<ExamAnswersheetResponseModel>> GetByIdAsync(Guid id)
    {
        var answersheets = await _examAnswersheetService.GetAllByListIdAsync(id);
        var answersheet = answersheets.FirstOrDefault();
        if (answersheet == null)
        {
            return NotFound($"Exam answersheet with ID {id} not found.");
        }

        return Ok(ApiResult<IEnumerable<ExamAnswersheetResponseModel>>.Success(answersheets));
    }
}
