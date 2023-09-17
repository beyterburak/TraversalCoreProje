using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    [Route("/[controller]/[action]")]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDTO model)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.TAdd(new ContactUs()
                {
                    Subject = model.Subject,
                    MessageBody = model.MessageBody,
                    Mail = model.Mail,
                    Status = true,
                    Name = model.Name,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                });

                return RedirectToAction("Index", "Default");
            }
            return View(model);
        }
    }
}
