using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactsContext _context;
        // GET: Contacts/ListOfContacts
        public ContactsController(ContactsContext c)
        {
            _context = c;
        }

        public IActionResult Index()
        {
            var a = _context.Contacts.ToArray();
            ViewBag.array = a;
            return View(a);
        }
        
        
        public IActionResult ListOfContacts()
        {
            var ContactAlesha = new Contact() {name = "Alesha Popovic"};
            ViewData["Alex"] = ContactAlesha;
            return View();
        }
    }
}