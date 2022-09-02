using AutoMapper;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.TagVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class TagService : ITagService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<TagListVM>> GetAllAsync()
        {
            List<TagListVM> taglistvms = _mapper.Map<List<TagListVM>>(await _unitOfWork.TagRepository.GetAllAsync());

            return taglistvms.AsQueryable();
        }

        public async Task<IQueryable<TagListVM>> GetAllAsync(int? status)
        {
            List<TagListVM> taglistvms = _mapper.Map<List<TagListVM>>(await _unitOfWork.TagRepository.GetAllAsync());

            IQueryable<TagListVM> query = taglistvms.AsQueryable();

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

        public async Task<TagGetVM> GetById(int? id)
        {
            Tag Tag = await _unitOfWork.TagRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (id == null)
                throw new NotFoundException($"Tag Cannot be found By id = {id}");

            TagGetVM TagGetVM = _mapper.Map<TagGetVM>(Tag);

            return TagGetVM;
        }

        public async Task CreateAsync(TagCreateVM tagCreateVM)
        {
            if (await _unitOfWork.TagRepository.IsExistAsync(c => !c.IsDeleted
            && c.Name.ToLower() == tagCreateVM.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Tag Already Exists by Name = ${tagCreateVM.Name}!");

            Tag tag = _mapper.Map<Tag>(tagCreateVM);

            await _unitOfWork.TagRepository.AddAsync(tag);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int? id, TagUpdateVM tagUpdateVM)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != tagUpdateVM.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _unitOfWork.TagRepository.IsExistAsync(c => !c.IsDeleted
            && c.Name.ToLower() == tagUpdateVM.Name.Trim().ToLower()))
                throw new RecordDublicateException($"Tag Already Exists by Name = ${tagUpdateVM.Name}!");

            Tag dbTag = await _unitOfWork.TagRepository.GetAsync(c => !c.IsDeleted && c.Id == tagUpdateVM.Id);

            if (dbTag == null)
                throw new NotFoundException($"Tag Cannot be found By id = {id}");

            dbTag.Name = tagUpdateVM.Name.Trim();
            dbTag.IsUpdated = true;
            dbTag.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Tag dbTag = await _unitOfWork.TagRepository.GetAsync(c => c.Id == id && !c.IsDeleted);

            if (dbTag == null)
                throw new NotFoundException($"Tag Cannot be found By id = {id}");

            dbTag.IsDeleted = true;
            dbTag.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task RestoreAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Tag dbTag = await _unitOfWork.TagRepository.GetAsync(c => c.Id == id && c.IsDeleted);

            if (dbTag == null)
                throw new NotFoundException($"Tag Cannot be found By id = {id}");

            dbTag.IsDeleted = false;
            dbTag.DeletedAt = null;

            await _unitOfWork.CommitAsync();
        }
    }
}
