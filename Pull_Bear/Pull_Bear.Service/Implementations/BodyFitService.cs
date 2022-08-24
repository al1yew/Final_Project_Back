using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Extensions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class BodyFitService : IBodyFitService
    {
        private readonly IBodyFitRepository _bodyFitRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public BodyFitService(IBodyFitRepository bodyFitRepository, IMapper mapper, IWebHostEnvironment env)
        {
            _bodyFitRepository = bodyFitRepository;
            _mapper = mapper;
            _env = env;
        }

        public IQueryable<BodyFitListVM> GetAllAsync(int? status)
        {
            List<BodyFitListVM> bodyFitListVMs = _mapper.Map<List<BodyFitListVM>>(_bodyFitRepository.GetAllAsync().Result);

            IQueryable<BodyFitListVM> query = bodyFitListVMs.AsQueryable();

            if (status != null && status > 0)
            {
                if (status == 1)
                {
                    query = query.Where(b => b.IsDeleted);
                }
                else if (status == 2)
                {
                    query = query.Where(b => !b.IsDeleted);
                }
            }

            return query;
        }

        public Task<BodyFitGetVM> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(BodyFitCreateVM bodyFitCreateVM)
        {
            if (await _bodyFitRepository.IsExistAsync(c => !c.IsDeleted && c.Name.ToLower() == bodyFitCreateVM.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Body Fit Already Exist By Name = {bodyFitCreateVM.Name}");

            BodyFit bodyFit = _mapper.Map<BodyFit>(bodyFitCreateVM);

            bodyFit.Image = await bodyFitCreateVM.Photo.CreateAsync(_env, "assets", "images", "bodyfit");

            await _bodyFitRepository.AddAsync(bodyFit);
            await _bodyFitRepository.CommitAsync();
        }

        public Task UpdateAsync(int? id, BodyFitUpdateVM bodyFitCreateVM)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task RestoreAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
