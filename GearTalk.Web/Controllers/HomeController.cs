using GearTalk.Web.Models;
using GearTalk.Web.Models.Domain;
using GearTalk.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace GearTalk.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarReview _carReviewRepository;
        private readonly ICarCategory _carCategoryRepository;

        public HomeController(
            ILogger<HomeController> logger,
            ICarReview carReview,
            ICarCategory carCategory)
        {
            _logger = logger;
            _carReviewRepository = carReview;
            _carCategoryRepository = carCategory;
        }

        // ======================
        // HOME
        // ======================
        public async Task<IActionResult> Index()
        {
            var carReviews = await _carReviewRepository.GetAllAsync();
            return View(carReviews);
        }

        // ======================
        // PRIVACY
        // ======================
        public IActionResult Privacy()
        {
            return View();
        }

        // ======================
        // CONTACT PAGE
        // ======================
        public IActionResult ContactUs()
        {
            return View();
        }

        // ======================
        // SEND EMAIL
        // ======================
        [HttpPost]
        public async Task<IActionResult> SendEmail(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactUs", model);
            }

            try
            {
                var fromAddress = "your@gmail.com";
                var toAddress = "your@email.com";

                var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "New Contact Message - GearTalk",
                    Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage:\n{model.Message}"
                };

                var smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("your@gmail.com", "APP_PASSWORD"),
                    EnableSsl = true
                };

                await smtp.SendMailAsync(message);

                TempData["Success"] = "Message sent successfully!";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
                TempData["Error"] = "Something went wrong. Try again.";
            }

            return RedirectToAction("ContactUs");
        }

        // ======================
        // ERROR
        // ======================
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}