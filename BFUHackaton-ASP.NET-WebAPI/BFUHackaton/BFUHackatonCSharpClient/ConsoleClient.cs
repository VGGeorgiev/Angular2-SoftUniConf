namespace BFUHackatonCSharpClient
{
    using System;
    using System.Net.Http;
    using BFUHackaton.Models;
    using System.Collections.Generic;

    public class ConsoleClient
    {
        public static void Main()
        {
            var requester = new HttpRequester("http://localhost:32427/api/");
            var teams = requester.Make<IEnumerable<TeamDataModel>>(HttpMethod.Get, "teams", "AzmgklFep8EzHdNNaimMO0YCPEB7fY0FStA9DCaJL_tmE2ztHu84uwD0mvoIVFvaieueAGh87QZzW1VFivBxkrrHONdsd5DFp5HLlgREMDn4l9L3TtG42i4TcS-XT9IFvH7wAbTvEu2oXsU4aaIKgJhWS81wJQdRuAUQrF1oNbms_dzkViwJjEdMjJ66Oaothu0g0TcybG0gZrotC9bauqMUifV6Bap3fN9Wixx85qOixOB_yHxqcI6YZlD7nfJwIuwWXxBKudzAS93ez8QJtSuOOTE-q-V8xsA2U4Mh-TF7HJxIhLwRaAABDSpH-Aukn12EJ1nL-WpxWJZVODgIl7yaF9tBjUD1ciadPZPjMVB1-TrwseZWeNRGZm45ND6sM4BHndMHfcFx8dAXZTuBXHkdeHYXEWHGxW7CCaB9NGU2ZiataNMdRf6Pil3GrATmWCId1vUM8kZw2-aakoGOxzEjAlxHJ7VTLmLnAwXCMpWoIyqZTQSPOerN8cuGdLBK").Result;

            foreach (var team in teams)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}
