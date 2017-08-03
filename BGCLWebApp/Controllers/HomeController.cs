
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BGLWebApp.Models;
using BGLWebApp.DataAccess;
using Newtonsoft.Json.Linq;
using System.Configuration;

namespace BGLWebApp.Controllers
{
    public class DataObject
    {
        public string Name { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GitUserResults(string userName)
        {
            string user = Request.Form["UserName"];
            string apiprefix = ConfigurationManager.AppSettings["apiPrefix"].ToString();
            string _endPointUrl = apiprefix + userName;

            //Call the rest API
            string userDetailsResponse = new RESTData().GetRestData(_endPointUrl);
            if (userDetailsResponse != null)
            {

                //Parse with Newtonsoft Json
                dynamic userDetails = JObject.Parse(userDetailsResponse);

                //Create Github user object
                var githubUserDetails = new GithubUser()
                {
                    UserName = userName,
                    AvatarUrl = userDetails.avatar_url.Value,
                    DisplayName = userDetails.name.Value,
                    Location = userDetails.location.Value,
                    UserRepos = new List<GithubUserRepo>()
                };

                //Get repository url for the user
                string _reposEndPointUrl = userDetails.repos_url.Value;

                //Call the rest API to get user repo Data
                string userRepoDetailsRespnse = new RESTData().GetRestData(_reposEndPointUrl);

                //Add the user Repo details to the list

                foreach (dynamic item in JArray.Parse(userRepoDetailsRespnse))
                {
                    githubUserDetails.UserRepos.Add(new GithubUserRepo
                    {
                        RepoName = item.name.Value,
                        RepoUrl = item.url.Value,
                        RepoStartgazerCount = item.stargazers_count.Value

                    });

                }
                //Order in descending order of stargaze count and take 5 from top
                githubUserDetails.UserRepos = githubUserDetails.UserRepos.OrderByDescending(
                    m => m.RepoStartgazerCount).Take(5).ToList();

                return View(githubUserDetails);
            }

            else
            {
                return View("UserNotFound");
            }
        }

       
    }
}