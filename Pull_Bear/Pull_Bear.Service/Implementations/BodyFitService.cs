﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Extensions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.BodyFitVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class BodyFitService : IBodyFitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public BodyFitService(IMapper mapper, IWebHostEnvironment env, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _env = env;
            _unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<BodyFitListVM>> GetAllAsync()
        {
            List<BodyFitListVM> bodyFitListVMs = _mapper.Map<List<BodyFitListVM>>(await _unitOfWork.BodyFitRepository.GetAllAsync());

            return bodyFitListVMs.AsQueryable();
        }

        public async Task<List<BodyFitListVM>> GetMaleBodyFitsAsync()
        {
            List<BodyFitListVM> bodyFitListVMs = _mapper.Map<List<BodyFitListVM>>(await _unitOfWork.BodyFitRepository.GetAllByExAsync(c => !c.IsDeleted && c.GenderId == 2));

            return bodyFitListVMs;
        }

        public async Task<List<BodyFitListVM>> GetFemaleBodyFitsAsync()
        {
            List<BodyFitListVM> bodyFitListVMs = _mapper.Map<List<BodyFitListVM>>(await _unitOfWork.BodyFitRepository.GetAllByExAsync(c => !c.IsDeleted && c.GenderId == 1));

            return bodyFitListVMs;
        }

        public async Task<IQueryable<BodyFitListVM>> GetAllAsync(int? status, int? type)
        {
            List<BodyFitListVM> bodyFitListVMs = _mapper.Map<List<BodyFitListVM>>(await _unitOfWork.BodyFitRepository.GetAllAsync("Gender"));

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

            if (type != null && type > 0)
            {
                if (type == 1)
                {
                    query = query.Where(c => c.GenderId == 2);
                }
                else if (type == 2)
                {
                    query = query.Where(c => c.GenderId == 1);
                }
            }

            return query;
        }

        public async Task<BodyFitGetVM> GetById(int? id)
        {
            BodyFit bodyFit = await _unitOfWork.BodyFitRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (id == null)
                throw new NotFoundException($"Body Fit Cannot be found By id = {id}");

            BodyFitGetVM bodyFitGetVM = _mapper.Map<BodyFitGetVM>(bodyFit);

            return bodyFitGetVM;
        }

        public async Task CreateAsync(BodyFitCreateVM bodyFitCreateVM)
        {
            if (await _unitOfWork.BodyFitRepository.IsExistAsync(c => !c.IsDeleted
            && (c.Name.ToLower() == bodyFitCreateVM.Name.Trim().ToLower() && c.GenderId == bodyFitCreateVM.GenderId)))
                throw new RecordDublicateException($"Body Fit Already Exists By Name = {bodyFitCreateVM.Name}");

            BodyFit bodyFit = _mapper.Map<BodyFit>(bodyFitCreateVM);

            bodyFit.Image = await bodyFitCreateVM.Photo.CreateAsync(_env, "assets", "images", "bodyfit");

            await _unitOfWork.BodyFitRepository.AddAsync(bodyFit);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(int? id, BodyFitUpdateVM bodyFitUpdateVM)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != bodyFitUpdateVM.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _unitOfWork.BodyFitRepository.IsExistAsync(c => !c.IsDeleted
            && (c.Name.ToLower() == bodyFitUpdateVM.Name.Trim().ToLower() && c.GenderId == bodyFitUpdateVM.GenderId && c.Id != bodyFitUpdateVM.Id)))
                throw new RecordDublicateException($"Body Fit Already Exists By Name = {bodyFitUpdateVM.Name}");

            BodyFit dbBodyFit = await _unitOfWork.BodyFitRepository.GetAsync(c => !c.IsDeleted && c.Id == bodyFitUpdateVM.Id);

            if (dbBodyFit == null)
                throw new NotFoundException($"Body Fit Cannot be found By id = {id}");

            if (bodyFitUpdateVM.Photo != null)
            {
                FileManager.DeleteFile(_env, dbBodyFit.Image, "assets", "images", "bodyfit");

                dbBodyFit.Image = await bodyFitUpdateVM.Photo.CreateAsync(_env, "assets", "images", "bodyfit");
            }

            dbBodyFit.Name = bodyFitUpdateVM.Name.Trim();
            dbBodyFit.GenderId = bodyFitUpdateVM.GenderId;
            dbBodyFit.IsUpdated = true;
            dbBodyFit.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            BodyFit dbbodyFit = await _unitOfWork.BodyFitRepository.GetAsync(c => c.Id == id && !c.IsDeleted);

            if (dbbodyFit == null)
                throw new NotFoundException($"Body Fit Cannot be found By id = {id}");

            dbbodyFit.IsDeleted = true;
            dbbodyFit.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _unitOfWork.CommitAsync();
        }

        public async Task RestoreAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            BodyFit dbbodyFit = await _unitOfWork.BodyFitRepository.GetAsync(c => c.Id == id && c.IsDeleted);

            if (dbbodyFit == null)
                throw new NotFoundException($"Body Fit Cannot be found By id = {id}");

            dbbodyFit.IsDeleted = false;
            dbbodyFit.DeletedAt = null;

            await _unitOfWork.CommitAsync();
        }
    }
}
