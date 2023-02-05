using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Presentation1.Controllers
{
    public class ContactsController : Controller
    {
        private ContactsServices contactsService;
        private IWebHostEnvironment host;

        public ContactsController(ContactsServices _contactsService, IWebHostEnvironment _host)
        {
            contactsService = _contactsService;
            host = _host;
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateContactViewModel myModel = new CreateContactViewModel();
            
            return View(myModel);
        }

        [HttpPost]
        public IActionResult Create(CreateContactViewModel data/*, IFormFile file*/)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contactsService.AddContact(data);

                    ViewBag.Message = "Contact was successfully inserted in database";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Contact wasn't inserted successfully. Please check your inputs";
            }

            return View();
        }

        public IActionResult List()
        {
            var list = contactsService.GetContacts();
            return View(list);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                contactsService.DeleteContact(id);
                TempData["message"] = "Contact has been deleted";

            }
            catch (Exception ex)
            {
                TempData["error"] = "Contact has not been deleted";
            }
            return RedirectToAction("List");
        }
    }
}
