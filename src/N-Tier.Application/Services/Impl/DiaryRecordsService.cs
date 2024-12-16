using AutoMapper;
using N_Tier.Application.Models.DiaryRecords;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl
{
    public class DiaryRecordsService : IDiaryRecordsService
    {
        private readonly IDiaryRecordsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IDiaryRepository _diaryRepository;

        public DiaryRecordsService(IMapper mapper, IDiaryRecordsRepository repository, ISubjectRepository subjectRepository, IDiaryRepository diaryRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _subjectRepository = subjectRepository;
            _diaryRepository = diaryRepository;
        }

        public async Task<CreateDiaryRecordsResponseModel> CreateAsync(CreateDiaryRecordsModel createDiaryRecordsModel,
            CancellationToken cancellationToken = default)
        {
            var diary = await _diaryRepository.GetFirstAsync(x => x.Id == createDiaryRecordsModel.DiaryId);
            var subject = await _subjectRepository.GetFirstAsync(x => x.Id == createDiaryRecordsModel.SubjectId);
            var diaryRecord = _mapper.Map<DiaryRecords>(createDiaryRecordsModel);
            diaryRecord.Diary = diary;
            diaryRecord.Subject = subject;
            var createdRecord = await _repository.AddAsync(diaryRecord);
            return new CreateDiaryRecordsResponseModel
            {
                Id = createdRecord.Id,
            };
        }

        public async Task<IEnumerable<DiaryRecordsResponseModel>> GetAllByListIdAsync(Guid id,
            CancellationToken cancellationToken = default)
        {
            var diaryRecords = await _repository.GetAllAsync(x => x.Id == id);
            return _mapper.Map<IEnumerable<DiaryRecordsResponseModel>>(diaryRecords);
        }
    }
}
