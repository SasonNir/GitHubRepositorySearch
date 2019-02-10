using GitHubRepositorySearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitHubRepositorySearch.Controllers
{
    public class GitHubController : Controller
    {
        // GET: GitHub
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetDataFromGithub(string inputSearch)
        {
            GithubService githubService = new GithubService();
            return new JsonResult() { Data = githubService.GetDataFromGithub(inputSearch), JsonRequestBehavior = JsonRequestBehavior.DenyGet };
        }

        [HttpPost]
        public JsonResult SaveDataRepository(string rowIndex, string repositoryName, string repositoryOwner)
        {
            bool successToSave = false;
            if (!string.IsNullOrWhiteSpace(repositoryName) && !string.IsNullOrWhiteSpace(repositoryOwner))
            {
                Dictionary<string, GithubRepositoryItem> choosenReporitories = null;
                if (Session["choosenReporitories"] != null)
                {
                    choosenReporitories = (Dictionary<string, GithubRepositoryItem>)Session["choosenReporitories"];
                }
                else
                {
                    choosenReporitories = new Dictionary<string, GithubRepositoryItem>();
                }

                if (!choosenReporitories.ContainsKey(rowIndex))
                {
                    GithubRepositoryOwner owner = new GithubRepositoryOwner();
                    owner.AvatarOwner = repositoryOwner;

                    choosenReporitories.Add(rowIndex, new GithubRepositoryItem { Name = repositoryName, Owner = owner });
                }

                Session.Add("choosenReporitories", choosenReporitories);

                successToSave = true;
            }

            return new JsonResult() { Data = successToSave, JsonRequestBehavior = JsonRequestBehavior.DenyGet };
        }
    }
}