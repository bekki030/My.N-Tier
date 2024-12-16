using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Employee;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeServise _employeeService;

        public EmployeeController(IEmployeeServise employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateEmployeeModel createEmployeeModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _employeeService.CreateAsync(createEmployeeModel);
            return Ok(ApiResult<CreateEmployeeResponseModel>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByListIdAsync(Guid id)
        {
            var employees = await _employeeService.GetAllByListIdAsync(id);

            if (employees == null)
                return NotFound();

            return Ok(ApiResult<IEnumerable<EmployeeResponseModel>>.Success(employees));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateEmployeeModel updateEmployeeModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _employeeService.UpdateAsync(id, updateEmployeeModel);
                return Ok(ApiResult<UpdateEmployeeResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update employee.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _employeeService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to delete employee.", error = ex.Message });
            }
        }
    }
}
