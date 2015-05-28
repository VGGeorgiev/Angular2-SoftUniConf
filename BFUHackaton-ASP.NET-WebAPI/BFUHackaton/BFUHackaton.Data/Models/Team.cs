using System.ComponentModel.DataAnnotations;
namespace BFUHackaton.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        private ICollection<ApplicationUser> users;

        public Team()
        {
            this.users = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<ApplicationUser> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
