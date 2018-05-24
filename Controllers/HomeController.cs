﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCaching.Internal;
 using Remotion.Linq.Clauses;
 using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactsContext _context;
        // GET: Contacts/ListOfContacts
        public HomeController(ContactsContext c)
        {
            _context = c;
        }
        
        [Authorize]
        public IActionResult Index()
        {
            var a = _context.Contacts.ToArray();
            ViewBag.array = a;
            ViewBag.Role = User.IsInRole("Admin");
            return View();
            
        }
        [HttpGet][Authorize]
        public IActionResult AddContact()
        {
            return View();
        }
        [HttpGet][Authorize]
        public IActionResult FindContact()
        {
            ViewBag.array = new Contact[0];
            return View();
        }

        [HttpPost][Authorize]
        public IActionResult AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost][Authorize]
        public IActionResult Index(Message message)
        {
            message.FromId = _context.Contacts.ToArray().FirstOrDefault(nm => nm.name == User.Identity.Name).Id;;
            
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost][Authorize]
        public IActionResult GetDetails(int id, Message message)
        {
            message.FromId = _context.Contacts.ToArray().FirstOrDefault(nm => nm.name == User.Identity.Name).Id;;
            message.ToId = id;
            _context.Messages.Add(new Message()
            {
                FromId = message.FromId,
                MessageBody = message.MessageBody,
                ToId = message.ToId
            }); ;
            _context.SaveChanges();
            var array = _context.Contacts.ToArray();
            ViewBag.array = array;
            ViewBag.Role = User.IsInRole("Admin");
            var c =  from con in array
                where con.Id == id
                select con;
            ViewBag.Messages = from mes in _context.Messages.ToList()
                where mes.FromId == id && mes.ToId == message.FromId || mes.ToId == id && mes.FromId == message.FromId
                select mes;
            ViewBag.Myid = _context.Contacts.ToArray().FirstOrDefault(nm => nm.name == User.Identity.Name).Id;
            ViewBag.contact = c.FirstOrDefault();

            return View();
            
        }
        
        
        
        [HttpPost][Authorize]
        public IActionResult FindContact(Contact pattern)
        {
            var a = from name in _context.Contacts.ToArray()
                where name.name == pattern.name
                select name;
            ViewBag.array = a;
            return View();
        }
        
        [HttpGet][Authorize]
        public IActionResult GetDetails(int id)
        {
            int FromId = _context.Contacts.ToArray().FirstOrDefault(nm => nm.name == User.Identity.Name).Id;;
            Contact[] array = _context.Contacts.ToArray();
            var c =  from con in array
                               where con.Id == id
                               select con;
            ViewBag.Messages = from mes in _context.Messages.ToList()
                where mes.FromId == id && mes.ToId == FromId || mes.ToId == id && mes.FromId == FromId
                select mes;
            ViewBag.Myid = _context.Contacts.ToArray().FirstOrDefault(nm => nm.name == User.Identity.Name).Id;
            ViewBag.array = _context.Contacts.ToArray();
            ViewBag.contact = c.FirstOrDefault();
            ViewBag.Role = User.IsInRole("Admin");

            ViewBag.size = _context.Contacts.ToArray().Length;
            return View();
        }
        
        [HttpGet][Authorize]
        public ActionResult Delete(int id)
        {
            var b = _context.Contacts.Find(id);
            if (b != null)
            {
                _context.Contacts.Remove(b);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}