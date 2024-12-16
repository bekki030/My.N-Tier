using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.ExamInvigilator;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ExamInvigilatorService : IExamInvigilatorService
{
    private readonly IExamInvigilatorRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IExamRepository _examRepository;

    public ExamInvigilatorService(IMapper mapper, IExamInvigilatorRepository repository, IEmployeeRepository employeeRepository, IExamRepository examRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _employeeRepository = employeeRepository;
        _examRepository = examRepository;
    }

    public async Task<CreateExamInvigilatorResponseModel> CreateAsync(CreateExamInvigilatorModel createExamInvigilatorModel,
        CancellationToken cancellationToken = default)
    {
        var exam = await _examRepository.GetFirstAsync(x => x.Id == createExamInvigilatorModel.ExamId);
        var employee = await _employeeRepository.GetFirstAsync(x => x.Id == createExamInvigilatorModel.EmployeeId);
        var invigilator = _mapper.Map<ExamInvigilator>(createExamInvigilatorModel);
        invigilator.Exam = exam;
        invigilator.Employee = employee;
        var createdInvigilator = await _repository.AddAsync(invigilator);
        return new CreateExamInvigilatorResponseModel
        {
            Id = createdInvigilator.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var invigilator = await _repository.GetFirstAsync(x => x.Id == id);
        if (invigilator == null)
        {
            throw new KeyNotFoundException($"Exam invigilator with ID {id} not found.");
        }

        var deletedInvigilator = await _repository.DeleteAsync(invigilator);
        return new BaseResponseModel
        {
            Id = deletedInvigilator.Id,
        };
    }

    public async Task<IEnumerable<ExamInvigilatorResponseModel>> GetAllByListIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var invigilators = await _repository.GetAllAsync(x => x.Exam.Id == id);
        return _mapper.Map<IEnumerable<ExamInvigilatorResponseModel>>(invigilators);
    }

    public async Task<UpdateExamInvigilatorResponseModel> UpdateAsync(Guid id,
        UpdateExamInvigilatorModel updateExamInvigilatorModel,
        CancellationToken cancellationToken = default)
    {
        var invigilator = await _repository.GetFirstAsync(x => x.Id == id);
        if (invigilator == null)
        {
            throw new KeyNotFoundException($"Exam invigilator with ID {id} not found.");
        }

        _mapper.Map(updateExamInvigilatorModel, invigilator);
        var updatedInvigilator = await _repository.UpdateAsync(invigilator);
        return new UpdateExamInvigilatorResponseModel
        {
            Id = updatedInvigilator.Id,
        };
    }
}
