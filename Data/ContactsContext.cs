using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
    
namespace WebApplication1.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
        }
        
        public DbSet<Contact> Contacts { get; set; }
        
    }
}