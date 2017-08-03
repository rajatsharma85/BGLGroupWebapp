using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BGLWebApp.Models
{
    public class GithubUserRepo
    {
        public string RepoName { get; set; }
        public string RepoUrl { get; set; }
        public long RepoStartgazerCount { get; set; }
    }
}