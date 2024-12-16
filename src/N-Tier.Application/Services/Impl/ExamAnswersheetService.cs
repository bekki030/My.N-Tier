using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamAnswersheet;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ExamAnswersheetService : IExamAnswersheetService
{
    private readonly IExamAnswersheetRepository _repository;
    private readonly IMapper _mapper;
    private readonly IExamSessionRepository _sessionRepository;
    private readonly IStudentRepository _studentRepository;

    public ExamAnswersheetService(IMapper mapper, IExamAnswersheetRepository repository, IExamSessionRepository sessionRepository, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _sessionRepository = sessionRepository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateExamAnswersheetResponseModel> CreateAsync(CreateExamAnswersheetModel createExamAnswerModel,
        CancellationToken cancellationToken = default)
    {
        var examsesion = await _sessionRepository.GetFirstAsync(x => x.Id == createExamAnswerModel.ExamSessionId);
        var student = await _studentRepository.GetFirstAsync(x => x.Id == createExamAnswerModel.StudentId);
        var answersheet = _mapper.Map<ExamAnswersheet>(createExamAnswerModel);
        answersheet.Student = student;
        answersheet.Session = examsesion;
        var createdAnswersheet = await _repository.AddAsync(answersheet);
        return new CreateExamAnswersheetResponseModel
        {
            Id = createdAnswersheet.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var answersheet = await _repository.GetFirstAsync(x => x.Id == id);
        if (answersheet == null)
        {
            throw new KeyNotFoundException($"Exam answersheet with ID {id} not found.");
        }

        var deletedAnswersheet = await _repository.DeleteAsync(answersheet);
        return new BaseResponseModel
        {
            Id = deletedAnswersheet.Id,
        };
    }

    public async Task<IEnumerable<ExamAnswersheetResponseModel>> GetAllByListIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var answersheets = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<ExamAnswersheetResponseModel>>(answersheets);
    }

    public async Task<UpdateExamAnswersheetResposeModel> UpdateAsync(Guid id, UpdateExamAnswersheetModel updateExamAnswerModel,
        CancellationToken cancellationToken = default)
    {
        var answersheet = await _repository.GetFirstAsync(x => x.Id == id);
        if (answersheet == null)
        {
            throw new KeyNotFoundException($"Exam answersheet with ID {id} not found.");
        }

        _mapper.Map(updateExamAnswerModel, answersheet);
        var updatedAnswersheet = await _repository.UpdateAsync(answersheet);
        return new UpdateExamAnswersheetResposeModel
        {
            Id = updatedAnswersheet.Id,
        };
    }
}
