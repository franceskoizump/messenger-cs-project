using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Contact> Users { get; set; }
        public Role()
        {
            Users = new List<Contact>();
        }        
    }
}