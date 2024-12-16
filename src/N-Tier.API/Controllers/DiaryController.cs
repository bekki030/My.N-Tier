using Microsoft.AspNetCore.Mvc;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Diary;
using N_Tier.Application.Services;

namespace N_Tier.API.Controllers
{
    public class DiaryController : ApiController
    {
        private readonly IDiaryServise _diaryService;

        public DiaryController(IDiaryServise diaryService)
        {
            _diaryService = diaryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateDiaryModel createDiaryModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _diaryService.CreateAsync(createDiaryModel);
            return Ok(ApiResult<CreateDiaryResponseModel>.Success(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByListIdAsync(Guid id)
        {
            var diaries = await _diaryService.GetAllByListIdAsync(id);

            if (diaries == null)
                return NotFound();

            return Ok(ApiResult<IEnumerable<DiaryResponseModel>>.Success(diaries));
        }
    }
}
