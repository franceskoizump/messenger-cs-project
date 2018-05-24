﻿using WebApplication1.Models;
using System;
using System.Linq;

namespace WebApplication1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ContactsContext context)
        {
            context.Database.EnsureCreated();

            Role AdminRole = new Role(){Name = "Admin"};
            context.Contacts.Add(new Contact() {name = "admin", password = "admin", Role = AdminRole});
            if (!context.Roles.Any())
            {
                context.Roles.Add(AdminRole);
                context.Roles.Add(new Role() {Name = "User"});
                
            }


            context.SaveChanges();

        }
   }
}