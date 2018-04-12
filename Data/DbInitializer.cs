using WebApplication1.Models;
using System;
using System.Linq;

namespace WebApplication1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ContactsContext context)
        {
            context.Database.EnsureCreated();

            if (context.Contacts.Any())
            {
                return;
            }

            var notebook = new Contact[]
            {
                new Contact {name = "Egor"},
                new Contact {name = "krendel"},
                new Contact {name = "Bulat Oku"},
                new Contact {name = "Java"},
                new Contact {name = "Simeon"},
                new Contact {name = "Alex"},
                new Contact {name = "Katya"}
            };
            foreach (var c in notebook)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();
        }
    }
}