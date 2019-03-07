using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;
using SessionControllerData;

namespace SSGeek.Web.Controllers
{
    public class ForumController : SessionController
    {
        IForumPostDAL ForumPostDal;

        public ForumController(IForumPostDAL IForumDAL)
        {
            ForumPostDal = IForumDAL;
        }

        public IActionResult Index()
        {
            var posts = ForumPostDal.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewPost(ForumPost post)
        {
            IActionResult result = null;

            TempData["Username"] = post.Username;

            if (!ModelState.IsValid)
            {
                result = View("NewPost");
            }
            else
            {
                ForumPostDal.SaveNewPost(post);
                result = RedirectToAction("Index", "Forum");
            }

            return result;
        }
    }
}