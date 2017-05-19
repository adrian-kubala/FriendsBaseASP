using FriendsBaseASP.DataAccess;
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

        [HttpGet]
        public ActionResult InsertFriend()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertFriend(Friend friend)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(friend);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult ShowAllFriendsDetails()
        {
            return View();
        }

    }
}