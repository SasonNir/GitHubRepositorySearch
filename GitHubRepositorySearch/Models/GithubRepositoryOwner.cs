using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubRepositorySearch.Models
{
    public class GithubRepositoryOwner
    {
        [JsonProperty("avatar_url")]
        public string AvatarOwner { get; set; }
    }
}