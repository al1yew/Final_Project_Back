using AutoMapper;
using Pull_Bear.Core.Models;
using Pull_Bear.Core.Repositories;
using Pull_Bear.Service.Exceptions;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.ColorVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;
        public ColorService(IColorRepository colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<ColorListVM>> GetAllAsync()
        {
            List<ColorListVM> colorListVMs = _mapper.Map<List<ColorListVM>>(await _colorRepository.GetAllAsync());

            return colorListVMs.AsQueryable();
        }

        public async Task<IQueryable<ColorListVM>> GetAllAsync(int? status)
        {
            List<ColorListVM> colorListVMs = _mapper.Map<List<ColorListVM>>(await _colorRepository.GetAllAsync());

            IQueryable<ColorListVM> query = colorListVMs.AsQueryable();

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

        public async Task<ColorGetVM> GetById(int? id)
        {
            Color color = await _colorRepository.GetAsync(x => x.Id == id && !x.IsDeleted);

            if (id == null)
                throw new NotFoundException($"Color Cannot be found By id = {id}");

            ColorGetVM colorGetVM = _mapper.Map<ColorGetVM>(color);

            return colorGetVM;
        }

        public async Task CreateAsync(ColorCreateVM colorCreateVM)
        {
            if (await _colorRepository.IsExistAsync(c => !c.IsDeleted
            && (c.Name.ToLower() == colorCreateVM.Name.Trim().ToLower() && c.HexCode.ToLower() == colorCreateVM.HexCode.ToLower().Trim())))
                throw new RecordDublicateException($"Color Already Exists By Name or Hexcode!");

            Color color = _mapper.Map<Color>(colorCreateVM);

            await _colorRepository.AddAsync(color);
            await _colorRepository.CommitAsync();
        }

        public async Task UpdateAsync(int? id, ColorUpdateVM colorUpdateVM)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != colorUpdateVM.Id)
                throw new BadRequestException($"Id's are not the same!");

            if (await _colorRepository.IsExistAsync(c => !c.IsDeleted
            && (c.Name.ToLower() == colorUpdateVM.Name.Trim().ToLower() && c.HexCode.ToLower() == colorUpdateVM.HexCode.ToLower().Trim())))
                throw new RecordDublicateException($"Color Already Exists By Name or Hexcode!");

            Color dbColor = await _colorRepository.GetAsync(c => !c.IsDeleted && c.Id == colorUpdateVM.Id);

            if (dbColor == null)
                throw new NotFoundException($"Color Cannot be found By id = {id}");

            dbColor.Name = colorUpdateVM.Name.Trim();
            dbColor.HexCode = colorUpdateVM.HexCode.Trim();
            dbColor.IsUpdated = true;
            dbColor.UpdatedAt = DateTime.UtcNow.AddHours(4);

            await _colorRepository.CommitAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Color dbColor = await _colorRepository.GetAsync(c => c.Id == id && !c.IsDeleted);

            if (dbColor == null)
                throw new NotFoundException($"Color Cannot be found By id = {id}");

            dbColor.IsDeleted = true;
            dbColor.DeletedAt = DateTime.UtcNow.AddHours(4);

            await _colorRepository.CommitAsync();
        }

        public async Task RestoreAsync(int? id)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            Color dbColor = await _colorRepository.GetAsync(c => c.Id == id && c.IsDeleted);

            if (dbColor == null)
                throw new NotFoundException($"Color Cannot be found By id = {id}");

            dbColor.IsDeleted = false;
            dbColor.DeletedAt = null;

            await _colorRepository.CommitAsync();
        }
    }
}
