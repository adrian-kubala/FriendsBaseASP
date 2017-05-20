using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FriendsBaseASP.Models
{
    public class Friend
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="Insert name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Insert last name")]
        public string lastName { get; set; }

        public List<Friend> AllFriends { get; set; }
    }
}