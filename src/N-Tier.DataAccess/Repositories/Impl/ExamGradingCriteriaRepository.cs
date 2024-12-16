using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class ExamGradingCriteriaRepository : BaseRepository<ExamGradingCriteria>, IExamGradingCriteriaRepository
{
    public ExamGradingCriteriaRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
