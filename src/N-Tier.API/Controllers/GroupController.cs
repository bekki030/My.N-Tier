using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Group;
using N_Tier.Application.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace N_Tier.API.Controllers
{
    public class GroupController : ApiController
    {
        private readonly IGroupServise _groupService;

        public GroupController(IGroupServise groupService)
        {
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateGroupModel createGroupModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _groupService.CreateAsync(createGroupModel);
            return Ok(ApiResult<CreateGroupResponseModel>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllGroupAsync(Guid id)
        {
            var groups = await _groupService.GetAllGroupAsync(id);

            return Ok(ApiResult<IEnumerable<GroupResponseModel>>.Success(groups));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateGroupModel updateGroupModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _groupService.UpdateAsync(id, updateGroupModel);
                return Ok(ApiResult<UpdateGroupResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to update group.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _groupService.DeleteAsync(id);
                return Ok(ApiResult<BaseResponseModel>.Success(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Failed to delete group.", error = ex.Message });
            }
        }
    }
}
