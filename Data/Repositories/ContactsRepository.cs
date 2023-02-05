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

        /*public void DeleteContact(Contact i)
        {
            context.Contacts.Remove(i);
            context.SaveChanges();
        }*/

        /*public void EditItem(Contact updatedItem)
        {
            //1. get the original item from the db

            var originalItem = GetContact(updatedItem.Id); //the Id should never be allowed to change

            //2. update the details which were supposed to be updated one by one

            originalItem.Name = updatedItem.Name;
            originalItem.PhotoPath = updatedItem.PhotoPath;
            originalItem.Price = updatedItem.Price;
            originalItem.Stock = updatedItem.Stock;
            originalItem.Description = updatedItem.Description;
            originalItem.CategoryId = updatedItem.CategoryId; //we change the foreign key NOT  the navigational property

            context.SaveChanges();
        }*/

    }
}
