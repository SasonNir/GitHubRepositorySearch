using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubRepositorySearch.Models
{
    public class GithubRepositoryItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("owner")]
        public GithubRepositoryOwner Owner { get; set; }
    }
}