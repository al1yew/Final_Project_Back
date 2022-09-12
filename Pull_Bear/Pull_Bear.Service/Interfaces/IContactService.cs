using Pull_Bear.Service.ViewModels.ContactVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pull_Bear.Service.Interfaces
{
    public interface IContactService
    {
        Task Contact(ContactCreateVM contactCreateVM);
    }
}
