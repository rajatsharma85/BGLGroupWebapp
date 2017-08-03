using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BGLWebApp.Models
{
    public class GithubUser
    {
        #region Properites
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Location { get; set; }
        public string AvatarUrl { get; set; }
        public string ReposUrl { get; set; }
        public List<GithubUserRepo> UserRepos { get; set; }
        #endregion
    }
}