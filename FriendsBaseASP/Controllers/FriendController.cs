using FriendsBaseASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FriendsBaseASP.Controllers
{
    public class FriendController : Controller
    {
        // GET: Friend
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertFriend(Friend friend)
        {
            return View();
        }
    }
}