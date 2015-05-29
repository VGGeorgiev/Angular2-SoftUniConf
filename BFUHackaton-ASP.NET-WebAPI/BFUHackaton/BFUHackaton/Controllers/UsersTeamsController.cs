namespace BFUHackaton.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Data;
    using Models;

    public class UsersTeamsController : ApiController
    {
        private ApplicationDbContext data;

        public UsersTeamsController()
        {
            this.data = new ApplicationDbContext();
        }

        /// <summary>
        ///     Gets the users in team
        /// </summary>
        /// <param name="id">Team id</param>
        /// <returns>Users in team</returns>
        public IHttpActionResult Get(int id)
        {
            var team = this.data.Teams.Find(id);
            if (team != null)
            {
                var users = team.Users.Select(x => new UserDataModel
                {
                    Id = x.Id,
                    Username = x.UserName,
                    Email = x.Email,
                    Gender = x.Gender,
                    FullName = x.FullName
                });

                return this.Ok(users);
            }

            return this.BadRequest("No existing team with this id");
        }

        public IHttpActionResult Post(AddUserToTeamBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var team = this.data.Teams.Find(model.TeamId);
                if (team != null)
                {
                    var user = this.data.Users.FirstOrDefault(x => x.UserName == model.Username);
                    if (user != null)
                    {
                        team.Users.Add(user);
                        this.data.SaveChanges();

                        return this.Ok();
                    }
                }
            }

            return this.BadRequest(this.ModelState);
        }
    }
}