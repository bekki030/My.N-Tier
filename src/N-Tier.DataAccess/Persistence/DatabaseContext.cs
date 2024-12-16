using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using N_Tier.Core.Common;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Identity;
using N_Tier.Shared.Services;

namespace N_Tier.DataAccess.Persistence;

public class DatabaseContext : IdentityDbContext<ApplicationUser>
{
    private readonly IClaimService _claimService;

    public DatabaseContext(DbContextOptions options, IClaimService claimService) : base(options)
    {
        _claimService = claimService;
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }


    public DbSet<TodoItem> TodoItems { get; set; }

    public DbSet<TodoList> TodoLists { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Diary> Diarys { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Attendance> Attendance {  get; set; }
    public DbSet<CheatingReport> CheatingReports { get; set; }
    public DbSet<DiaryRecords> DiaryRecords { get; set; }
    public DbSet<ExamAnswersheet> ExamAnswersheet { get; set; }
    public DbSet<ExamGradingCriteria> ExamGradingCriteria { get; set; }
    public DbSet<ExamInvigilator> ExamInvigilator { get; set; }
    public DbSet<ExamResult> ExamResult { get; set; }
    public DbSet<ExamSession> ExamSession { get; set; }
    public DbSet<Shift> Shift { get; set; }
    public DbSet<StudentBehavior> StudentBehavior { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _claimService.GetUserId();
                    entry.Entity.CreatedOn = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedBy = _claimService.GetUserId();
                    entry.Entity.UpdatedOn = DateTime.Now;
                    break;
            }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
