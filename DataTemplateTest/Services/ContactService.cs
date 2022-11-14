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
                    PhoneNr = "+48500400200",
                    Image = @"C:\Users\AdamFierek\Pictures\test.bmp"
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
