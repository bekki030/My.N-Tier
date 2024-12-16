using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Subject;
using N_Tier.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.API.Controllers
{
    public class SubjectController : ApiController
    {
        private readonly ISubjectServise _subjectService;

        public SubjectController(ISubjectServise subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync( CreateSubjectModel createSubjectModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _subjectService.CreateAsync(createSubjectModel);
           return Ok(ApiResult<CreateSubjectResponseModel>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSubjectAsync(Guid id)
        {
            var subjects = await _subjectService.GetAllSubjectAsync(id);

            return Ok(ApiResult<IEnumerable<SubjectResponseModel>>.Success(subjects));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _subjectService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to delete subject.", error = ex.Message });
            }
        }
    }
}
