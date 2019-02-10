using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace GitHubRepositorySearch.Models
{
    public class GithubService
    {
        public GithubRepositoryList GetDataFromGithub(string value)
        {
            GithubRepositoryList detailist;
            string url = "https://api.github.com/search/repositories?q=";
            
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10; Win64; x64; rv:60.0) Gecko/20100101 Firefox/60.0");
                using (HttpResponseMessage response = client.GetAsync(url + value).Result)
                using (HttpContent content = response.Content)
                {
                    string textResult = response.Content.ReadAsStringAsync().Result;
                    string result =  content.ReadAsStringAsync().Result;
                    detailist = JsonConvert.DeserializeObject<GithubRepositoryList>(result);
                }
            }

            return detailist;
        }
        
    }    
}