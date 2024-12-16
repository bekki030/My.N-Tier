using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Lesson;
using N_Tier.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.API.Controllers
{
    public class LessonController : ApiController
    {
        private readonly ILessonServise _lessonService;

        public LessonController(ILessonServise lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync( CreateLessonModel createLessonModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _lessonService.CreateAsync(createLessonModel);
            return Ok(ApiResult<CreateLessonResponseModel>.Success(result));
        }

        // Get all lessons by list ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByListIdAsync(Guid id)
        {
            var lessons = await _lessonService.GetAllByListIdAsync(id);

            return Ok(ApiResult<IEnumerable<LessonResponseModel>>.Success(lessons));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateLessonModel updateLessonModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _lessonService.UpdateAsync(id, updateLessonModel);
                return Ok(ApiResult<UpdateLessonResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update lesson.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _lessonService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to delete lesson.", error = ex.Message });
            }
        }
    }
}
