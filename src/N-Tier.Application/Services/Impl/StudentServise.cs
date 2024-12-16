using AutoMapper;
using Microsoft.EntityFrameworkCore;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Student;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;

namespace N_Tier.Application.Services.Impl
{
    public class StudentServise : IStudentServise
    {
        private readonly IStudentRepository _studentServise;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupServise;
        public StudentServise(IStudentRepository studentRepository, IMapper mapper, IGroupRepository groupServise)
        {
            _mapper = mapper;
            _studentServise = studentRepository;
            _groupServise = groupServise;
        }

        public async Task<CreateStudentResponseModel> CreateAsync(CreateStudentModel createStudentModel, CancellationToken cancellationToken = default)
        {
            var group = await _groupServise.GetFirstAsync(x => x.Id == createStudentModel.GroupId);
            var student = _mapper.Map<Student>(createStudentModel);
            student.Group = group;
            return new CreateStudentResponseModel
            {
                Id = (await _studentServise.AddAsync(student)).Id,
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var student = await _studentServise.GetFirstAsync(x => x.Id == id);
            return new BaseResponseModel
            {
                Id = (await _studentServise.DeleteAsync(student)).Id,
            };
        }

        public async Task<IEnumerable<StudentResponseModel>> GetAllStudentAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var student = await _studentServise.GetAllAsync(x => x.Id == id, include: q => q.Include(x => x.Person));
            return _mapper.Map<IEnumerable<StudentResponseModel>>(student);
        }
    }
}
