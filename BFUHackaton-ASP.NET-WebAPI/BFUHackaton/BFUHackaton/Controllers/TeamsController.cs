namespace BFUHackaton.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using BFUHackaton.Models;
    using BFUHackaton.Data.Models;

    [Authorize]
    public class TeamsController : ApiController
    {
        private ApplicationDbContext data;

        public TeamsController()
        {
            this.data = new ApplicationDbContext();
        }

        public IHttpActionResult Get()
        {
            var teams = this.data.Teams
                .Select(x => new TeamDataModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return this.Ok(teams);
        }

        public IHttpActionResult Get(int id)
        {
            var team = this.data.Teams
                .Where(x => x.Id == id)
                .Select(x => new TeamDetailsDataModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    RegistrationDate = x.RegistrationDate,
                    Users = x.Users.Select(u => new UserDataModel
                    {
                        Id = u.Id,
                        Email = u.Email,
                        FullName = u.FullName,
                        Gender = u.Gender,
                        Username = u.UserName
                    })
                })
                .FirstOrDefault();

            return this.Ok(team);
        }

        public IHttpActionResult Post(TeamBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var team = new Team()
                {
                    Name = model.Name,
                    RegistrationDate = DateTime.Now
                };

                this.data.Teams.Add(team);
                this.data.SaveChanges();

                return this.Created("/teams/" + team.Id, team);
            }

            return this.BadRequest(this.ModelState);
        }

        public IHttpActionResult Put(int id, TeamBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var team = this.data.Teams.Find(id);
                if (team != null)
                {
                    team.Name = model.Name;
                    this.data.SaveChanges();

                    return this.Ok(team);
                }
            }

            return this.BadRequest(this.ModelState);
        }

        public IHttpActionResult Delete(int id)
        {
            var team = this.data.Teams.Find(id);
            if (team != null)
            {
                this.data.Teams.Remove(team);
                this.data.SaveChanges();

                return this.Ok(team);
            }

            return this.BadRequest();
        }
    }
}