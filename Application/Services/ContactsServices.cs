using Application.ViewModels;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class ContactsServices
    {

        private ContactsRepository ir;
        public ContactsServices(ContactsRepository _contactRepository)
        {
            ir = _contactRepository;
        }

        public void AddContact(CreateContactViewModel contact)
        {
            if (ir.GetContacts().Any(myContact => myContact.MobileNo == contact.MobileNo))
                throw new Exception("Contact with the same mobile number already exists!");
            else
            {
                ir.AddContact(new Domain.Models.Contact()
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
            var contact = ir.GetContact(id);
            if (contact != null)
                ir.DeleteContact(contact);
        }

        public IQueryable<ContactViewModel> GetContacts()
        {
            var list = from i in ir.GetContacts() 
                       select new ContactViewModel()
                       {
                           Id = i.Id,
                           Name = i.Name,
                           Surname = i.Surname,
                           MobileNo= i.MobileNo,
                           PicturePath = i.PicturePath
                       };
            return list;

        }

/*        public void EditContact(int id, CreateContactViewModel updatedContact)
        {
            ir.EditContact(
                new Domain.Models.Contact()
                {
                    Id = id,
                    Name = updatedContact.Name,
                    Surname = updatedContact.Surname,
                    MobileNo = updatedContact.MobileNo,
                    PicturePath = updatedContact.PicturePath
                });
        }*/
    }
}
