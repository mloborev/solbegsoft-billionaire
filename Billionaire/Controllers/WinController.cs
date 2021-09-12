using Billionaire.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Billionaire.Controllers
{
    public class WinController : Controller
    {
        // GET: WinController
        public ActionResult Win(PlayerModel currentplayer)
        {
            ViewData["Score"] = currentplayer.score;
            return View();
        }

        // GET: WinController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WinController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WinController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WinController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WinController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WinController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WinController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Home()
        {
            return Redirect("/Home/Index");
        }
    }
}
