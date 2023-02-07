using Application.ViewModels;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ContactsServices
    {
        private ContactsRepository cr;
        public ContactsServices(ContactsRepository _contactRepository)
        {
            cr = _contactRepository;
        }

        public void AddContact(CreateContactViewModel contact)
        {
            if (cr.GetContacts().Any(myContact => myContact.MobileNo == contact.MobileNo))
                throw new Exception("Contact with the same mobile number already exists!");
            else
            {
                cr.AddContact(new Domain.Models.Contact()
                {
                    Name = contact.Name,
                    Surname = contact.Surname,
                    MobileNo = contact.MobileNo,
                    PicturePath = contact.PicturePath
                });
            }
        }

        public void DeleteContact(int id)
        {
            var contact = cr.GetContact(id);
            if (contact != null)
                cr.DeleteContact(contact);
        }

        public IQueryable<ContactViewModel> GetContacts()
        {
            var list = from c in cr.GetContacts() 
                       select new ContactViewModel()
                       {
                           Id = c.Id,
                           Name = c.Name,
                           Surname = c.Surname,
                           MobileNo= c.MobileNo,
                           PicturePath = c.PicturePath
                       };
            return list;

        }
    }
}
