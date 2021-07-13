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
using System.Security;
using X.PagedList;

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
    // you have to install PagedList.mvc
    // this will take pageSize and pageNumber parameters
    // public ActionResult Index()
    // {
    //   // this will take pageSize and pageNumber parameters
    //   var allImages = Image.GetAll();
    //   // and then it will return a PagedList which has .PageCount and .PageNumber properties
    //   return View(allImages);
    // }
    public ActionResult Index(int? page)
    {
      // this will take pageSize and pageNumber parameters
      int pageNumber = (page ?? 1);
      var allImages = Image.GetAll(1,30);
      // and then it will return a PagedList which has .PageCount and .PageNumber properties
      return View(allImages.ToPagedList(pageNumber, 6));
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
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      if (userId == image.UserId)
      {
        return View(image);
      }
      // idk some sort of error handling here
      return View("Error");
    }
    // need to secure Post routes
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
      Image.Delete(id);
      return RedirectToAction("Index");
    }
    public IActionResult Edit(int id)
    {
      var image = Image.GetDetails(id);
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      if (userId == image.UserId)
      {
        return View(image);
      }
      // idk some sort of error handling here
      return View("Error");
    }
    // need to secure Post routes
    [HttpPost]
    public async Task<ActionResult> Details(int id, Image image)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      image.UserName = currentUser.UserName;
      image.UserId = userId;
      image.ImageId = id;
      Image.Put(image);
      return RedirectToAction("Details", id);
    }
    // create custom uri
    [AllowAnonymous]
    [Route("/profiles/{user}")]
    public IActionResult UserGallery(string user)
    {
      var userImages = Image.GetImagesByUser(user);
      ViewBag.UserName = user;
      return View(userImages);
    }
  }
}