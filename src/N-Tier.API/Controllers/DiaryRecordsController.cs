using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.DiaryRecords;
using N_Tier.Application.Services;

namespace N_Tier.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiaryRecordsController : ControllerBase
{
    private readonly IDiaryRecordsService _diaryRecordsService;

    public DiaryRecordsController(IDiaryRecordsService diaryRecordsService)
    {
        _diaryRecordsService = diaryRecordsService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateDiaryRecordsResponseModel>> CreateAsync(
        [FromBody] CreateDiaryRecordsModel createDiaryRecordsModel)
    {
        if (createDiaryRecordsModel == null)
        {
            return BadRequest("Diary record model is null.");
        }

        var response = await _diaryRecordsService.CreateAsync(createDiaryRecordsModel);

        return Ok(ApiResult<CreateDiaryRecordsResponseModel>.Success(response));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<DiaryRecordsResponseModel>>> GetAllByListIdAsync(
        Guid id)
    {
        var records = await _diaryRecordsService.GetAllByListIdAsync(id);

        if (records == null || !records.Any())
        {
            return NotFound($"No diary records found for ID: {id}");
        }

        return Ok(ApiResult<IEnumerable<DiaryRecordsResponseModel>>.Success(records));
    }

    [HttpGet("details/{id}")]
    public async Task<ActionResult<DiaryRecordsResponseModel>> GetByIdAsync(
        Guid id)
    {
        var records = await _diaryRecordsService.GetAllByListIdAsync(id);
        var record = records.FirstOrDefault();
        if (record == null)
        {
            return NotFound($"Diary record with ID {id} not found.");
        }

        return Ok(ApiResult<IEnumerable<DiaryRecordsResponseModel>>.Success(records));
    }
}
