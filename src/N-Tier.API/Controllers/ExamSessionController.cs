using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamSession;
using N_Tier.Application.Services;

namespace N_Tier.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamSessionController : ControllerBase
{
    private readonly IExamSessionService _examSessionService;

    public ExamSessionController(IExamSessionService examSessionService)
    {
        _examSessionService = examSessionService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateExamSessionResponseModel>> CreateAsync(
        [FromBody] CreateExamSessionModel createExamSessionModel)
    {
        if (createExamSessionModel == null)
        {
            return BadRequest("Exam session model is null.");
        }

        var response = await _examSessionService.CreateAsync(createExamSessionModel);

        return Ok(ApiResult<CreateExamSessionResponseModel>.Success(response));
    }

    [HttpGet("list/{id}")]
    public async Task<ActionResult<IEnumerable<ExamSessionResponseModel>>> GetAllByListIdAsync(Guid id)
    {
        var examSessions = await _examSessionService.GetAllByListIdAsync(id);

        if (examSessions == null || !examSessions.Any())
        {
            return NotFound($"No exam sessions found for Exam ID {id}.");
        }

        return Ok(ApiResult<IEnumerable<ExamSessionResponseModel>>.Success(examSessions));
    }
}
