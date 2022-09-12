using AutoMapper;
using Pull_Bear.Core;
using Pull_Bear.Core.Models;
using Pull_Bear.Service.Interfaces;
using Pull_Bear.Service.ViewModels.ContactVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Contact(ContactCreateVM contactCreateVM)
        {
            Contact contact = _mapper.Map<Contact>(contactCreateVM);

            await _unitOfWork.ContactRepository.AddAsync(contact);
            await _unitOfWork.CommitAsync();
        }
    }
}
