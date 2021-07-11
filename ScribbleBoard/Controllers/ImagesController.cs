using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ScribbleBoard.Models;
using System.Collections.Generic;
using System.Linq;

namespace ScribbleBoard.Controllers
{
    public class ImagesController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}