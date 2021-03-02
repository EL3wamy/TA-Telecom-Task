using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TATelecomTask.Domain;
using TATelecomTask.Enums;
using TATelecomTask.Models;

namespace TATelecomTask.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IContactLogRepo _contactLogRepo;

        public HomeController(IContactLogRepo contactLogRepo)
        {
            _contactLogRepo = contactLogRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage(AddContactLogInputModel model)
        {
            try
            {
                var result = await _contactLogRepo.AddContanctLogAsync(model.Message);

                if (result)
                {
                    TempData["Status"] = SendStatus.Sended.ToString();
                }
                else
                {
                    TempData["Status"] = SendStatus.NotSended.ToString();
                }
            }

            catch (Exception)
            {
                TempData["Status"] = SendStatus.NotSended;
                return RedirectToAction("index");
            }

            return RedirectToAction("index");
        }

        public IActionResult Privacy()
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
