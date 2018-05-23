using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IContactsService
    {
        IEnumerable<Contact> GetContactsByID(int id);
        IEnumerable<Contact> GetContactsByName(Contact pattern);
        IEnumerable<Contact> GetAllContacts();
        IEnumerable<Message> GetAllMessages();
    }
}