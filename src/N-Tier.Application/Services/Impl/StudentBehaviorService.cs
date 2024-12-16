using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.StudentBehavior;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class StudentBehaviorService : IStudentBehaviorService
{
    private readonly IStudentBehaviorRepository _repository;
    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IStudentRepository _studentRepository;

    public StudentBehaviorService(IMapper mapper, IStudentBehaviorRepository repository, IEmployeeRepository employeeRepository, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _employeeRepository = employeeRepository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateStudentBehaviorResponseModel> CreateAsync(CreateStudentBehaviorModel createStudentBehaviorModel,
        CancellationToken cancellationToken = default)
    {
        var student = await _studentRepository.GetFirstAsync(x=>x.Id == createStudentBehaviorModel.StudentId);
        var employee = await _employeeRepository.GetFirstAsync(x=>x.Id==createStudentBehaviorModel.EmployeeId);
        var studentBehavior = _mapper.Map<StudentBehavior>(createStudentBehaviorModel);
        studentBehavior.Student = student;
        studentBehavior.Employee = employee;
        var createdStudentBehavior = await _repository.AddAsync(studentBehavior);
        return new CreateStudentBehaviorResponseModel
        {
            Id = createdStudentBehavior.Id,
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var studentBehavior = await _repository.GetFirstAsync(x => x.Id == id);
        if (studentBehavior == null)
        {
            throw new KeyNotFoundException($"Student behavior with ID {id} not found.");
        }

        var deletedStudentBehavior = await _repository.DeleteAsync(studentBehavior);
        return new BaseResponseModel
        {
            Id = deletedStudentBehavior.Id,
        };
    }

    public async Task<IEnumerable<StudentBehaviorResponseModel>> GetAllByListIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var studentBehaviors = await _repository.GetAllAsync(x => x.Student.Id == id);
        return _mapper.Map<IEnumerable<StudentBehaviorResponseModel>>(studentBehaviors);
    }

    public async Task<UpdateStudentBehaviorResponseModel> UpdateAsync(Guid id,
        UpdateStudentBehaviorModel updateStudentBehaviorModel,
        CancellationToken cancellationToken = default)
    {
        var studentBehavior = await _repository.GetFirstAsync(x => x.Id == id);
        if (studentBehavior == null)
        {
            throw new KeyNotFoundException($"Student behavior with ID {id} not found.");
        }

        _mapper.Map(updateStudentBehaviorModel, studentBehavior);
        var updatedStudentBehavior = await _repository.UpdateAsync(studentBehavior);
        return new UpdateStudentBehaviorResponseModel
        {
            Id = updatedStudentBehavior.Id,
        };
    }
}
