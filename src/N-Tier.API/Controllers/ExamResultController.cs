using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamResult;
using N_Tier.Application.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : ControllerBase
    {
        private readonly IExamResultService _examResultService;

        public ExamResultController(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateExamResultResponseModel>> CreateAsync(
            [FromBody] CreateExamResultModel createExamResultModel)
        {
            if (createExamResultModel == null)
            {
                return BadRequest("Exam result model is null.");
            }

            var response = await _examResultService.CreateAsync(createExamResultModel);

            return Ok(ApiResult<CreateExamResultResponseModel>.Success(response));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponseModel>> DeleteAsync(Guid id)
        {
            try
            {
                var response = await _examResultService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponseModel>.Success(response));
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Exam result with ID {id} not found.");
            }
        }

        [HttpGet("list/{id}")]
        public async Task<ActionResult<IEnumerable<ExamResultResponseModel>>> GetAllByListIdAsync(Guid id)
        {
            var results = await _examResultService.GetAllByListIdAsync(id);

            if (results == null)
            {
                return NotFound($"No exam results found for List ID {id}.");
            }

            return Ok(ApiResult<IEnumerable<ExamResultResponseModel>>.Success(results));
        }
    }
}
