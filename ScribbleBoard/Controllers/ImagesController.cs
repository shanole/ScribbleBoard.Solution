using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ScribbleBoard.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ScribbleBoard.Controllers
{
    public class ImagesController : Controller
    {
        public ActionResult Index()
        {
            var allImages = Image.GetAll();
            return View(allImages);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Image image)
        {
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // var currentUser = await _userManager.FindByIdAsync(userId);
            // image.User = currentUser;
            // image.UserId = userId;
            Image.Post(image);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var image = Image.GetDetails(id);
            return View(image);
        }
    }
}