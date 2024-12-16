using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamGradingCriteria;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ExamGradingCriteriaService : IExamGradingCriteriaService
{
    private readonly IExamGradingCriteriaRepository _repository;
    private readonly IMapper _mapper;
    private readonly IExamRepository _examRepository;

    public ExamGradingCriteriaService(IMapper mapper, IExamGradingCriteriaRepository repository, IExamRepository examRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _examRepository = examRepository;
    }

    public async Task<CreateExamGradingCriteriaResponseModel> CreateAsync(
        CreateExamGradingCriteriaModel createExamGradingCriteriaModel,
        CancellationToken cancellationToken = default)
    {
        var exam = await _examRepository.GetFirstAsync(x => x.Id == createExamGradingCriteriaModel.ExamId);
        var gradingCriteria = _mapper.Map<ExamGradingCriteria>(createExamGradingCriteriaModel);
        gradingCriteria.Exam = exam;
        var createdCriteria = await _repository.AddAsync(gradingCriteria);
        return new CreateExamGradingCriteriaResponseModel
        {
            Id = createdCriteria.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var gradingCriteria = await _repository.GetFirstAsync(x => x.Id == id);
        if (gradingCriteria == null)
        {
            throw new KeyNotFoundException($"Exam grading criteria with ID {id} not found.");
        }

        var deletedCriteria = await _repository.DeleteAsync(gradingCriteria);
        return new BaseResponseModel
        {
            Id = deletedCriteria.Id,
        };
    }

    public async Task<IEnumerable<ExamGradingCriteriaResponseModel>> GetAllByListIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var gradingCriteriaList = await _repository.GetAllAsync(x => x.Exam.Id == id);
        return _mapper.Map<IEnumerable<ExamGradingCriteriaResponseModel>>(gradingCriteriaList);
    }

    public async Task<UpdateExamGradingCriteriaResponseModel> UpdateAsync(Guid id,
        UpdateExamGradingCriteriaModel updateExamGradingCriteriaModel,
        CancellationToken cancellationToken = default)
    {
        var gradingCriteria = await _repository.GetFirstAsync(x => x.Id == id);
        if (gradingCriteria == null)
        {
            throw new KeyNotFoundException($"Exam grading criteria with ID {id} not found.");
        }

        _mapper.Map(updateExamGradingCriteriaModel, gradingCriteria);
        var updatedCriteria = await _repository.UpdateAsync(gradingCriteria);
        return new UpdateExamGradingCriteriaResponseModel
        {
            Id = updatedCriteria.Id,
        };
    }
}
