using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
    
namespace WebApplication1.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
            
        }

        public string GetNameById(int Id)
        {
            var a = (from name in Contacts.ToList() 
                        where name.Id == Id 
                        select name.name).FirstOrDefault();
            return a;
        }
        
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }

        
    }
}