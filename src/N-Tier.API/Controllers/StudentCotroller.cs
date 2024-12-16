using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Student;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IStudentServise _studentService;

        public StudentController(IStudentServise studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateStudentModel createStudentModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _studentService.CreateAsync(createStudentModel);
            return Ok(ApiResult<CreateStudentResponseModel>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllStudentAsync(Guid id)
        {
            var students = await _studentService.GetAllStudentAsync(id);

            return Ok(ApiResult<IEnumerable<StudentResponseModel>>.Success(students));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _studentService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to delete student.", error = ex.Message });
            }
        }
    }
}
