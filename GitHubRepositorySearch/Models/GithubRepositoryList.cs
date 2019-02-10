using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitHubRepositorySearch.Models
{
    public class GithubRepositoryList
    {
        [JsonProperty("items")]
        public List<GithubRepositoryItem> Items { get; set; }
    }
}