using N_Tier.Application.Models.Exam;
using N_Tier.Application.Models;
using N_Tier.Application.Models.CheatingReport;

namespace N_Tier.Application.Services;

public interface ICheatingReportService
{
    Task<CreateCheatingReportResponseModel> CreateAsync(CreateCheatingReportModel createCheatingModel,
CancellationToken cancellationToken = default);

    Task<IEnumerable<CheatingReportResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);
}
