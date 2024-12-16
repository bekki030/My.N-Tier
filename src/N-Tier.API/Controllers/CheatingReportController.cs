using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.CheatingReport;
using N_Tier.Application.Services;

namespace N_Tier.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CheatingReportController : ControllerBase
{
    private readonly ICheatingReportService _cheatingReportService;

    public CheatingReportController(ICheatingReportService cheatingReportService)
    {
        _cheatingReportService = cheatingReportService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateCheatingReportResponseModel>> CreateAsync(
        [FromBody] CreateCheatingReportModel createCheatingModel)
    {
        if (createCheatingModel == null)
        {
            return BadRequest("Cheating report model is null.");
        }

        var response = await _cheatingReportService.CreateAsync(createCheatingModel);

        return Ok(ApiResult<CreateCheatingReportResponseModel>.Success(response));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<CheatingReportResponseModel>>> GetAllByListIdAsync(
        Guid id)
    {
        var reports = await _cheatingReportService.GetAllByListIdAsync(id);

        if (reports == null || !reports.Any())
        {
            return NotFound($"No cheating reports found for ID: {id}");
        }

        return Ok(ApiResult<IEnumerable<CheatingReportResponseModel>>.Success(reports));
    }

    [HttpGet("details/{id}")]
    public async Task<ActionResult<CheatingReportResponseModel>> GetByIdAsync(
        Guid id)
    {
        var reports = await _cheatingReportService.GetAllByListIdAsync(id);
        var report = reports.FirstOrDefault();
        if (report == null)
        {
            return NotFound($"Cheating report with ID {id} not found.");
        }

        return Ok(ApiResult<IEnumerable<CheatingReportResponseModel>>.Success(reports));
    }
}
