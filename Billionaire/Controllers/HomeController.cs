using Billionaire.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Billionaire.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> AmountSend(PlayerModel get)
        {
            PlayerModel currentplayer = new PlayerModel();
            currentplayer = get;

            var rnd = new Random();
            currentplayer.not_answered = Enumerable.Range(1, 22).OrderBy(x => rnd.Next()).Take(get.ammount).ToArray();
            currentplayer.ammount = 1;
            return RedirectToAction("Quiz", "Quiz",  currentplayer );
        }



    }
}
