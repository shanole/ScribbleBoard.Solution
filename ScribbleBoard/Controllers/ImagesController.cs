using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ScribbleBoard.Models;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ScribbleBoard.Controllers
{
  [Authorize]
  public class ImagesController : Controller
  {
    private readonly UserManager<ApplicationUser> _userManager;
    public ImagesController(UserManager<ApplicationUser> userManager)
    {
      _userManager = userManager;
    }
    [AllowAnonymous]
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
    public async Task<ActionResult> Create(Image image)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      image.UserName = currentUser.UserName;
      image.UserId = userId;
      Image.Post(image);
      return RedirectToAction("Index");
    }
    [AllowAnonymous]
    public IActionResult Details(int id)
    {
      var image = Image.GetDetails(id);
      return View(image);
    }
    // deleting an editing should only be allowed if you're logged in as the correct user
    public IActionResult Delete(int id)
    {
      var image = Image.GetDetails(id);
      return View(image);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      Image.Delete(id);
      return RedirectToAction("Index");
    }
    public IActionResult Edit(int id)
    {
      var image = Image.GetDetails(id);
      return View(image);
    }
    [HttpPost]
    public IActionResult Details(int id, Image image)
    {
      image.ImageId = id;
      Image.Put(image);
      return RedirectToAction("Details", id);
    }
  }
}