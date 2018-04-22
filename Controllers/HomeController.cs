using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var a = _context.Contacts.ToArray();
            ViewData["array"] = a;
            ViewBag.array = a;
            return View();
        }
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult GetDetails(int id )
        {
            Contact[] array = _context.Contacts.ToArray();
            var c =  from con in array
                               where con.Id == id
                               select con;
            foreach (var a in c)
            {
                ViewBag.contact = a;
            }

            ViewBag.size = _context.Contacts.ToArray().Length;
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Contact b = _context.Contacts.Find(id);
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