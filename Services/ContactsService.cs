using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ContactsService : IContactsService
    {
        private readonly ContactsContext _context;
        public ContactsService(ContactsContext c)
        {
            _context = c;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _context.Contacts.ToList();
        }

        public IEnumerable<Contact> GetContactsByID(int id)
        {
            Contact[] array = _context.Contacts.ToArray();
            var c =  from con in array
                where con.Id == id
                select con;
            return c;
        }

        public IEnumerable<Contact> GetContactsByName(Contact pattern)
        {
            var a = from name in _context.Contacts.ToList()
                where name.name == pattern.name
                select name;
            return a;
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }
        
    }
}