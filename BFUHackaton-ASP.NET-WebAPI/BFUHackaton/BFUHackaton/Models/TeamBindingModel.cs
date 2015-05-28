namespace BFUHackaton.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TeamBindingModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The {0} should be between {2} and {1}")]
        public string Name { get; set; }
    }
}