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

        [Required(ErrorMessage ="Wprowadź imię")]
        public string name { get; set; }

        [Required(ErrorMessage = "Wprowadź nazwisko")]
        public string lastName { get; set; }

        public List<Friend> AllFriends { get; set; }
    }
}