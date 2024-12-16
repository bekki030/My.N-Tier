using N_Tier.Core.Entities;
using N_Tier.DataAccess.Persistence;

namespace N_Tier.DataAccess.Repositories.Impl;

public class ExamInvigilatorRepository : BaseRepository<ExamInvigilator>, IExamInvigilatorRepository
{
    public ExamInvigilatorRepository(DatabaseContext databaseContext) : base(databaseContext)
    {

    }
}
