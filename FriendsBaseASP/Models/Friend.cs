using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FriendsBaseASP.Models
{
    public class Friend
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public List<Friend> AllFriends { get; set; }
    }
}