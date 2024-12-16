using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Exam;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class ExamServise : IExamServise
    {
        private readonly IExamRepository _repository;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly ISubjectRepository _subjectRepository;
        public ExamServise(IMapper mapper,IExamRepository examRepository, IGroupRepository groupRepository, IRoomRepository roomRepository, ISubjectRepository subjectRepository)
        {
            _mapper = mapper;
            _repository = examRepository;
            _groupRepository = groupRepository;
            _roomRepository = roomRepository;
            _subjectRepository = subjectRepository;
        }

        public async Task<CreateExamResponseModel> CreateAsync(CreateExamModel creatExamModel, CancellationToken cancellationToken = default)
        {
            var group = await _groupRepository.GetFirstAsync(x=>x.Id == creatExamModel.GroupId);
            var room = await _roomRepository.GetFirstAsync(x=>x.Id==creatExamModel.RoomId);
            var subject = await _subjectRepository.GetFirstAsync(x=>x.Id == creatExamModel.SubjectId);
            var exam = _mapper.Map<Exam>(creatExamModel);
            exam.Subject = subject;
            exam.Room = room;
            exam.Group = group;
            return new CreateExamResponseModel
            {
                Id = (await _repository.AddAsync(exam)).Id,
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var exam = await _repository.GetFirstAsync(x => x.Id == id);
            return new BaseResponseModel
            {
                Id = (await _repository.DeleteAsync(exam)).Id,
            };
        }

        public async Task<IEnumerable<ExamResponseModel>> GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var exam = await _repository.GetAllAsync(x => x.Id == id);
            return _mapper.Map<IEnumerable<ExamResponseModel>>(exam);
        }

        public async Task<UpdateExamResponseModel> UpdateAsync(Guid id, UpdateExamModel updateExamModel, CancellationToken cancellationToken = default)
        {
            var exam = await _repository.GetFirstAsync(x=>x.Id == id);
            _mapper.Map(exam, updateExamModel);
            return new UpdateExamResponseModel
            {
                Id = (await _repository.UpdateAsync(exam)).Id,
            };
        }
    }
}
