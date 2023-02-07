using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class ContactsRepository : IContactsRepository
    {

        private ContactsContext context { get; set; }
       
        public ContactsRepository(ContactsContext _context)
        {
            context = _context;
        }

        public IQueryable<Contact> GetContacts()
        {
            return context.Contacts;
        }

        public Contact GetContact(int id)
        {
            return context.Contacts.SingleOrDefault(x => x.Id == id);
        }

        public void AddContact(Contact c)
        {
            context.Contacts.Add(c);
            context.SaveChanges();
        }

        public void DeleteContact(Contact c)
        {
            context.Contacts.Remove(c);
            context.SaveChanges();
        }

    }
}
