using Billionaire.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
    public class QuizController : Controller
    {
        private readonly IConfiguration _configuration;
        private string connectionString;

        public QuizController(IConfiguration configuration)
        {
            _configuration = configuration;

            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Quiz(PlayerModel currentplayer)
        {
            Random hah = new Random();

            GameLogicModel CurrentQuestion = new GameLogicModel();
            CurrentQuestion = GetData.GetDataFromDB(currentplayer.ammount);

            //currentplayer.not_answered = Enumerable.Range(1, currentplayer.ammount).OrderBy(x => hah.Next()).ToArray();

            ViewData["Question"] = CurrentQuestion.Question;
            ViewData["Answer1"] = CurrentQuestion.Answer1;
            ViewData["Answer2"] = CurrentQuestion.Answer2;
            ViewData["Answer3"] = CurrentQuestion.Answer3;
            ViewData["Answer4"] = CurrentQuestion.Answer4;


            for (int i = 1; i < 5; i++)
            {
                if (i == (CurrentQuestion.TrueAnswer))
                {
                    ViewData["IsTrue" + i] = "true";
                }
                else
                {
                    ViewData["IsTrue" + i] = "false";
                }
            }
            ViewData["Score"] = currentplayer.score;
            ViewData["Ammount"] = currentplayer.ammount;

            TempData["score"] = currentplayer.score;
            TempData["ammount"] = currentplayer.ammount;
            TempData["not_answered"] = currentplayer.not_answered;

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
        public async Task<IActionResult> QuizView(PlayerModel currentplayer)
        {
            currentplayer.not_answered = TempData["not_answered"] as int[];
            currentplayer.ammount = (int)TempData["Ammount"];


            GameLogicModel CurrentQuestion = new GameLogicModel();
            CurrentQuestion = GetData.GetDataFromDB(currentplayer.ammount);

            if (Convert.ToString(CurrentQuestion.TrueAnswer) == currentplayer.button)
            {
                currentplayer.score = (int)TempData["score"];
                currentplayer.score += 1000000 / ((currentplayer.not_answered).Length) - 1000 *(((currentplayer.not_answered).Length)- currentplayer.ammount);
                currentplayer.ammount++;
                if (currentplayer.ammount > ((currentplayer.not_answered).Length))
                {
                    for (int i = 1; i < ((currentplayer.not_answered).Length); i++)
                    {
                        currentplayer.score += i * 1000;
                    };

                    return RedirectToAction("Win", "Win", currentplayer);
                };

                return RedirectToAction("Quiz", "Quiz", currentplayer);
            }
            else
            {
                return RedirectToAction("Win", "Win", currentplayer);
            }
        }
    }
}
