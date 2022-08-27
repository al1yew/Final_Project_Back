using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.SizeVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IMapper _mapper;

        public SizeService(ISizeRepository sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public IQueryable<SizeListVM> GetAllAsync(int? status)
        {
            List<SizeListVM> sizeListVMs = _mapper.Map<List<SizeListVM>>(_sizeRepository.GetAllAsync().Result);

            IQueryable<SizeListVM> query = sizeListVMs.AsQueryable();

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

        public async Task<SizeGetVM> GetById(int? id)
        {
            Size size = await _sizeRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (id == null)
                throw new NotFoundException($"Size Cannot be found By id = {id}");

            SizeGetVM sizeGetVM = _mapper.Map<SizeGetVM>(size);

            return sizeGetVM;
        }

        public async Task CreateAsync(SizeCreateVM sizeCreateVM)
        {
            if (await _sizeRepository.IsExistAsync(c => !c.IsDeleted
            && c.Name.ToLower() == sizeCreateVM.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Size Already Exists by Name = ${sizeCreateVM.Name}!");

            Size size = _mapper.Map<Size>(sizeCreateVM);

            await _sizeRepository.AddAsync(size);
            await _sizeRepository.CommitAsync();
        }

        public async Task UpdateAsync(int? id, SizeUpdateVM sizeUpdateVM)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != sizeUpdateVM.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _sizeRepository.IsExistAsync(c => !c.IsDeleted
            && c.Name.ToLower() == sizeUpdateVM.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Size Already Exists by Name = ${sizeUpdateVM.Name}!");

            Size dbSize = await _sizeRepository.GetAsync(c => !c.IsDeleted && c.Id == sizeUpdateVM.Id);

            if (dbSize == null)
                throw new NotFoundException($"Size Cannot be found By id = {id}");

            dbSize.Name = sizeUpdateVM.Name.Trim();
            dbSize.IsUpdated = true;
            dbSize.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _sizeRepository.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Size dbSize = await _sizeRepository.GetAsync(c => c.Id == id && !c.IsDeleted);

            if (dbSize == null)
                throw new NotFoundException($"Size Cannot be found By id = {id}");

            dbSize.IsDeleted = true;
            dbSize.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _sizeRepository.CommitAsync();
        }

        public async Task RestoreAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Size dbSize = await _sizeRepository.GetAsync(c => c.Id == id && c.IsDeleted);

            if (dbSize == null)
                throw new NotFoundException($"Size Cannot be found By id = {id}");

            dbSize.IsDeleted = false;
            dbSize.DeletedAt = null;

            await _sizeRepository.CommitAsync();
        }
    }
}
