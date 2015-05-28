using BFUHackaton.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFUHackaton.Models
{
    public class UserDataModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public Gender Gender { get; set; }
    }
}