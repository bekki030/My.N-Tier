using AutoMapper;
using N_Tier.Application.Models;
using N_Tier.Application.Models.Subject;
using N_Tier.Core.Entities;
using N_Tier.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Tier.Application.Services.Impl
{
    public class SubjectServise : ISubjectServise
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;
        public SubjectServise(ISubjectRepository subjectRepository,IMapper mapper)
        {
            _mapper = mapper;
            _subjectRepository = subjectRepository;
        }

        public async Task<CreateSubjectResponseModel> CreateAsync(CreateSubjectModel createSubjectModel, CancellationToken cancellationToken = default)
        {
            var subject = _mapper.Map<Subject>(createSubjectModel);
            return new CreateSubjectResponseModel
            {
                Id = (await _subjectRepository.AddAsync(subject)).Id,
            };
        }

        public async Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var subject = await _subjectRepository.GetFirstAsync(x => x.Id == id);
            return new BaseResponseModel
            {
                Id = (await _subjectRepository.DeleteAsync(subject)).Id,
            };
        }

        public async Task<IEnumerable<SubjectResponseModel>> GetAllSubjectAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var subject = await _subjectRepository.GetAllAsync(x => x.Id == id);
            return _mapper.Map<IEnumerable<SubjectResponseModel>>(subject);
        }
    }
}
