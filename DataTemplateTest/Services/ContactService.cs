using DataTemplateTest.Model;
using System.Collections.Generic;

namespace DataTemplateTest.Services
{
    public class ContactService
    {
        public List<Contact> GetAll()
        {
            return new List<Contact>
            {
                new Contact
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    PhoneNr = "+48500400200"
                }
            };
        }

        public void Add(Contact c)
        {

        }

        public void Update(Contact c)
        {

        }

    }
}
