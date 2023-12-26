using EmaiLMessage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmaiLMessage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Message", "From"));
            message.To.Add(new MailboxAddress("To Mesg", "To"));
            message.Subject = "Subject Gos Here";
            message.Body = new TextPart("plain")
            {
                Text = "Hello ...."
            };

            using(var client = new SmtpClient())
            {
                client.Connect("smtp-mail.outlook.com", 587,false);
                client.Authenticate("Emaile Sender", "Password");

                client.Send(message);
                client.Disconnect(true);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddDept()
        {
            return View();
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
