using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Exam;
using N_Tier.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.API.Controllers
{
    public class ExamController : ApiController
    {
        private readonly IExamServise _examService;

        public ExamController(IExamServise examService)
        {
            _examService = examService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateExamModel createExamModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _examService.CreateAsync(createExamModel);
            return Ok(ApiResult<CreateExamResponseModel>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByListIdAsync(Guid id)
        {
            var exams = await _examService.GetAllByListIdAsync(id);

            if (exams == null)
                return NotFound();

            return Ok(ApiResult<IEnumerable<ExamResponseModel>>.Success(exams));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateExamModel updateExamModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _examService.UpdateAsync(id, updateExamModel);
                return Ok(ApiResult<UpdateExamResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update exam.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _examService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to delete exam.", error = ex.Message });
            }
        }
    }
}
