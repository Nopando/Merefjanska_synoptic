using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class ContactsContext : DbContext
    {

        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }

    }
}
