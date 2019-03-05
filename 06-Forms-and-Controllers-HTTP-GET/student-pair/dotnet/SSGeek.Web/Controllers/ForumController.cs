using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class ForumController : Controller
    {
        IForumPostDAL ForumPostDal;

        public ForumController(IForumPostDAL IForumDAL)
        {
            ForumPostDal = IForumDAL;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewPost(ForumPost post)
        {
            return View();
        }
    }
}