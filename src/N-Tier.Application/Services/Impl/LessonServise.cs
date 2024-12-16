using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Lesson;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class LessonServise : ILessonServise
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IGroupRepository _groupRepository;
        public LessonServise(ILessonRepository lessonRepository,IMapper mapper, ISubjectRepository subjectRepository, IEmployeeRepository employeeRepository, IGroupRepository groupRepository)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _subjectRepository = subjectRepository;
            _employeeRepository = employeeRepository;
            _groupRepository = groupRepository;
        }

        public async Task<CreateLessonResponseModel> CreateAsync(CreateLessonModel createLessonModel, CancellationToken cancellationToken = default)
        {
            var subject = await _subjectRepository.GetFirstAsync(x=>x.Id == createLessonModel.SubjectId);
            var group = await _groupRepository.GetFirstAsync(x=>x.Id==createLessonModel.GroupId);
            var employee = await _employeeRepository.GetFirstAsync(x=>x.Id == createLessonModel.EmployeeId);
            var lesson = _mapper.Map<Lesson>(createLessonModel);
            lesson.Subject = subject;
            lesson.Group = group;
            lesson.Employee = employee;
            return new CreateLessonResponseModel
            {
                Id = (await _lessonRepository.AddAsync(lesson)).Id,
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var lesson = await _lessonRepository.GetFirstAsync(x => x.Id == id);
            return new BaseResponseModel
            {
                Id = (await _lessonRepository.DeleteAsync(lesson)).Id,
            };
        }

        public async Task<IEnumerable<LessonResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var lesson = await _lessonRepository.GetFirstAsync(x=>x.Id == id);
            return _mapper.Map<IEnumerable<LessonResponseModel>>(lesson);
        }

        public async Task<UpdateLessonResponseModel> UpdateAsync(Guid id, UpdateLessonModel updateLessonModel, CancellationToken cancellationToken = default)
        {
            var lesson = await _lessonRepository.GetFirstAsync(x=>x.Id==id);
            _mapper.Map(lesson, updateLessonModel);
            return new UpdateLessonResponseModel
            {
                Id = (await _lessonRepository.UpdateAsync(lesson)).Id,
            };
        }
    }
}
