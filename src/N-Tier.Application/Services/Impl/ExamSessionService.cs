using AutoMapper;
using N_Tier.Application.Models.ExamSession;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ExamSessionService : IExamSessionService
{
    private readonly IExamSessionRepository _repository;
    private readonly IMapper _mapper;
    private readonly IExamRepository _examRepository;

    public ExamSessionService(IMapper mapper, IExamSessionRepository repository, IExamRepository examRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _examRepository = examRepository;
    }

    public async Task<CreateExamSessionResponseModel> CreateAsync(CreateExamSessionModel createExamSessionModel,
        CancellationToken cancellationToken = default)
    {
        var exam = await _examRepository.GetFirstAsync(x => x.Id == createExamSessionModel.ExamId);
        var examSession = _mapper.Map<ExamSession>(createExamSessionModel);
        examSession.Exam = exam;
        var createdExamSession = await _repository.AddAsync(examSession);
        return new CreateExamSessionResponseModel
        {
            Id = createdExamSession.Id,
        };
    }

    public async Task<IEnumerable<ExamSessionResponseModel>> GetAllByListIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var examSessions = await _repository.GetAllAsync(x => x.Exam.Id == id);
        return _mapper.Map<IEnumerable<ExamSessionResponseModel>>(examSessions);
    }
}
