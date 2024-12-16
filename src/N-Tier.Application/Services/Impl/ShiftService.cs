using AutoMapper;
using N_Tier.Application.Models.Exam;
using N_Tier.Application.Models.Shift;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class ShiftService : IShiftService
{
    private readonly IExamRepository _repository;
    private readonly IMapper _mapper;

    public ShiftService(IMapper mapper, IExamRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<CreateShiftResponseModel> CreateAsync(CreateShiftModel createExamModel,
        CancellationToken cancellationToken = default)
    {
        var exam = _mapper.Map<Exam>(createExamModel);
        var createdExam = await _repository.AddAsync(exam);
        return new CreateShiftResponseModel
        {
            Id = createdExam.Id,
        };
    }

    public async Task<IEnumerable<ShiftResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var exam = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<ShiftResponseModel>>(exam);
    }

    public async Task<UpdateShiftResponseModel> UpdateAsync(Guid id, UpdateShiftModel updateExamModel,
        CancellationToken cancellationToken = default)
    {
        var exam = await _repository.GetFirstAsync(x => x.Id == id);
        if (exam == null)
        {
            throw new KeyNotFoundException($"Exam with ID {id} not found.");
        }

        _mapper.Map(updateExamModel, exam);
        var updatedExam = await _repository.UpdateAsync(exam);
        return new UpdateShiftResponseModel
        {
            Id = updatedExam.Id,
        };
    }
}
