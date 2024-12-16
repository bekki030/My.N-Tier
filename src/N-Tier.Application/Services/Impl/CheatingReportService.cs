using AutoMapper;
using N_Tier.Application.Models.CheatingReport;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl;

public class CheatingReportService : ICheatingReportService
{
    private readonly ICheatingReportRepository _repository;
    private readonly IMapper _mapper;
    private readonly IExamSessionRepository _sessionRepository;
    private readonly IStudentRepository _studentRepository;

    public CheatingReportService(IMapper mapper, ICheatingReportRepository repository, IExamSessionRepository sessionRepository, IStudentRepository studentRepository)
    {
        _mapper = mapper;
        _repository = repository;
        _sessionRepository = sessionRepository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateCheatingReportResponseModel> CreateAsync(CreateCheatingReportModel createCheatingModel,
        CancellationToken cancellationToken = default)
    {
        var examsession = await _sessionRepository.GetFirstAsync(x=>x.Id == createCheatingModel.ExamSessionId);
        var student  = await _studentRepository.GetFirstAsync(x => x.Id == createCheatingModel.StudentId);
        var cheatingReport = _mapper.Map<CheatingReport>(createCheatingModel);
        cheatingReport.Session = examsession;
        cheatingReport.Student = student;
        var createdReport = await _repository.AddAsync(cheatingReport);
        return new CreateCheatingReportResponseModel
        {
            Id = createdReport.Id,
        };
    }

    public async Task<IEnumerable<CheatingReportResponseModel>> GetAllByListIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var reports = await _repository.GetAllAsync(x => x.Id == id);
        return _mapper.Map<IEnumerable<CheatingReportResponseModel>>(reports);
    }
}
