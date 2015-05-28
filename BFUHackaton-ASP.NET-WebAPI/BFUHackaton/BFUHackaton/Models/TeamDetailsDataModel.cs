namespace BFUHackaton.Models
{
    using System;
    using System.Collections.Generic;

    public class TeamDetailsDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime RegistrationDate { get; set; }

        public IEnumerable<UserDataModel> Users { get; set; }
    }
}