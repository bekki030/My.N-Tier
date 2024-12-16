using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamResult;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ExamResultService : IExamResultService
{
    private readonly IExamResultRepository _repository;
    private readonly IMapper _mapper;
    private readonly IExamRepository _examRepository;
    private readonly IStudentRepository _studentRepository;

    public ExamResultService(IMapper mapper, IExamResultRepository repository, IExamRepository examRepository, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _examRepository = examRepository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateExamResultResponseModel> CreateAsync(CreateExamResultModel createExamResultModel,
        CancellationToken cancellationToken = default)
    {
        var exam = await _examRepository.GetFirstAsync(x => x.Id == createExamResultModel.ExamId);
        var student = await _studentRepository.GetFirstAsync(x=>x.Id == createExamResultModel.StudentId);
        var examResult = _mapper.Map<ExamResult>(createExamResultModel);
        examResult.Student = student;
        examResult.Exam = exam;
        var createdExamResult = await _repository.AddAsync(examResult);
        return new CreateExamResultResponseModel
        {
            Id = createdExamResult.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var examResult = await _repository.GetFirstAsync(x => x.Id == id);
        if (examResult == null)
        {
            throw new KeyNotFoundException($"Exam result with ID {id} not found.");
        }

        var deletedExamResult = await _repository.DeleteAsync(examResult);
        return new BaseResponseModel
        {
            Id = deletedExamResult.Id,
        };
    }

    public async Task<IEnumerable<ExamResultResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var exam = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<ExamResultResponseModel>>(exam);
    }
}
