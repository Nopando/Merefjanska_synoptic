using Data.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class ContactsRepository
    {

        /*private ContactsContext context { get; set; }
       
        public ContactsRepository(ContactsContext _context)
        {
            context = _context;
        }*/

        public IQueryable<Contact> GetContacts()
        {
            return null;//context.Contacts;
        }

        public void AddContact(Contact c) 
        {
            /*context.Contacts.Add(c);
            context.SaveChanges();*/
        }

        /*public Contact GetContacts(int id)
        {
            //return context.Contacts.SingleOrDefault(x => x.Id == id);
        }*/

    }
}
