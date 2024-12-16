using AutoMapper;
using N_Tier.Application.Models.Diary;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl
{
    public class DiaryServise : IDiaryServise
    {
        private readonly IDiaryRepository _diaryRepository;
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IStudentRepository _studentRepository;
        public DiaryServise(IDiaryRepository diaryRepository, IMapper mapper, ISubjectRepository subjectRepository, IStudentRepository studentRepository)
        {
            _diaryRepository = diaryRepository;
            _mapper = mapper;
            _subjectRepository = subjectRepository;
            _studentRepository = studentRepository;
        }
        public async Task<CreateDiaryResponseModel> CreateAsync(CreateDiaryModel createDiaryModel, CancellationToken cancellationToken = default)
        {
            var subject = await _subjectRepository.GetFirstAsync(x => x.Id == createDiaryModel.SubjectId);
            var student = await _studentRepository.GetFirstAsync(x => x.Id == createDiaryModel.StudentId);
            var diary = _mapper.Map<Diary>(createDiaryModel);
            diary.Student = student;
            diary.Subject = subject;

            return new CreateDiaryResponseModel { Id = (await _diaryRepository.AddAsync(diary)).Id };

        }

        public async Task<IEnumerable<DiaryResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var diary = await _diaryRepository.GetAllAsync(x => x.Id == id);

            return _mapper.Map<IEnumerable<DiaryResponseModel>>(diary);
        }
    }
}
