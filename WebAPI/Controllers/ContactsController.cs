using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsDbContext dbContext;

        public ContactsController(ContactsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public string GetInfo()
        {
            return "Contacts API v1.0";
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            dbContext.Contacts.Add(contact);
            dbContext.SaveChanges();
            return NoContent(); 
        }

        [HttpGet("all")]
        public IActionResult GetContacts()
        {
            var result = dbContext.Contacts.ToList();
            return Ok(result);
        }
    }
}
