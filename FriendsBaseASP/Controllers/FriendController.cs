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
            Friend friend = new Friend();
            DataAccessLayer db = new DataAccessLayer(); //calling class DBdata
            friend.AllFriends = db.SelectAllData();
            return View(friend);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Friend friend)
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
        public ActionResult Edit(string id)
        {
            Friend friend = new Friend();
            DataAccessLayer db = new DataAccessLayer(); //calling class DBdata
            return View(db.SelectDataById(id));
        }

        [HttpPost]
        public ActionResult Edit(Friend friend)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                DataAccessLayer db = new DataAccessLayer(); //calling class DBdata
                string result = db.UpdateData(friend);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            Friend objCustomer = new Friend();
            DataAccessLayer db = new DataAccessLayer(); //calling class DBdata
            return View(db.SelectDataById(id));
        }

        [HttpPost]
        public ActionResult Delete(Friend friend)
        {
            DataAccessLayer db = new DataAccessLayer();
            string result = db.DeleteData(friend);
            ViewData["result"] = result;
            ModelState.Clear(); //clearing model
            return RedirectToAction("Index");
        }

    }
}