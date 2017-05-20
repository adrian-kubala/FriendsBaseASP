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
                DataAccessLayer db = new DataAccessLayer();
                string result = db.InsertData(friend);
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
            Friend friend = new Friend();
            DataAccessLayer db = new DataAccessLayer(); //calling class DBdata
            friend.AllFriends = db.SelectAllData();
            return View(friend);
        }

        [HttpGet]
        public ActionResult EditFriend(string id)
        {
            Friend friend = new Friend();
            DataAccessLayer db = new DataAccessLayer(); //calling class DBdata
            return View(db.SelectDataById(id));
        }

        [HttpPost]
        public ActionResult EditFriend(Friend friend)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer db = new DataAccessLayer(); //calling class DBdata
                string result = db.UpdateData(friend);
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
        public ActionResult DeleteFriend(string id)
        {
            Friend objCustomer = new Friend();
            DataAccessLayer db = new DataAccessLayer(); //calling class DBdata
            return View(db.SelectDataById(id));
        }

        [HttpPost]
        public ActionResult DeleteFriend(Friend friend)
        {
            DataAccessLayer db = new DataAccessLayer();
            string result = db.DeleteData(friend);
            ViewData["result"] = result;
            ModelState.Clear(); //clearing model
            return View();
        }

    }
}