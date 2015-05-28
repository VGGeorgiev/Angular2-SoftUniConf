using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BFUHackaton.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddUserToTeamBindingModel
    {
        [Required(ErrorMessage = "TeamId is required")]
        public int TeamId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
    }
}