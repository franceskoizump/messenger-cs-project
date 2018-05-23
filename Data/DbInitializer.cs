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

            if (context.Contacts.Any())
            {
                return;
            }

            /*var notebook = new Contact[]
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
            }*/
            context.Contacts.Add(new Contact() {name = "admin", password = "admin"});

            context.SaveChanges();
            if (context.Messages.Any())
            {
                return;
            }
            /*var  mess = new Message[]
            {
                new Message {MessageBody = "Hi", FromId = 1},
                new Message {MessageBody = "Hello", FromId = 2},
                new Message {MessageBody = "bonjure", FromId = 3},
                new Message {MessageBody = "how are you", FromId = 1},
                new Message {MessageBody = "fine", FromId = 2},
                new Message {MessageBody = "kill me please", FromId = 3},
            };
            foreach (var c in mess)
            {
                context.Messages.Add(c);
            }
            
            Console.WriteLine(context.Messages.ToArray()[5].MessageBody);*/
            context.SaveChanges();

        }
/*
        public static void InitializeMessages(MessagesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Contacts.Any())
            {
                return;
            }
            
            
            var notebook = new Message[]
            {
                new Message {MessageBody = "Hi", FromId = 1},
                new Message {MessageBody = "Hello", FromId = 2},
                new Message {MessageBody = "bonjure", FromId = 3},
                new Message {MessageBody = "how are you", FromId = 1},
                new Message {MessageBody = "fine", FromId = 2},
                new Message {MessageBody = "kill me please", FromId = 3},
            };
            foreach (var c in notebook)
            {
                context.Messages.Add(c);
            }
            context.SaveChanges();
        }
    */
    }
    
}