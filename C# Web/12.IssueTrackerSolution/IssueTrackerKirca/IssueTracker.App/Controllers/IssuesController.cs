using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.App.Controllers
{
    using BindingModels;
    using Data;
    using Security;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;

    public class IssuesController : Controller
    {
        private AuthenticationManager authenticationManager;
        private IssuesService issuesService;

        public IssuesController()
        {
            this.issuesService = new IssuesService();
            this.authenticationManager = new AuthenticationManager(new IssuesContext());
        }

        [HttpGet]
        public IActionResult<HashSet<IssueViewModel>> All(HttpSession session, HttpResponse response, string status = null, string query = null)
        {
            if (!this.authenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            HashSet<IssueViewModel> issuesVm = this.issuesService.RetrieveAllIssues(status, query);

            return View(issuesVm);
        }

        [HttpGet]
        public IActionResult New(HttpSession session, HttpResponse response)
        {
            if (!this.authenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            return View();
        }

        [HttpPost]
        public IActionResult New(HttpSession session, HttpResponse response, CreateIssueBindingModel cibm)
        {
            if (!this.authenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            this.issuesService.CreateIssue(cibm);

            Redirect(response, "/issues/all");
            return null;
        }

        [HttpGet]
        public IActionResult Edit(int id, HttpSession session, HttpResponse response)
        {
            if (!this.authenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.authenticationManager.IsCurrentUserPost(id, session))
            {
                Redirect(response, "/issues/all");
                return null;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, EditIssueBindingModel eibm, HttpSession session, HttpResponse response)
        {
            if (!this.authenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.authenticationManager.IsCurrentUserPost(id, session))
            {
                Redirect(response, "/issues/all");
                return null;
            }

            this.issuesService.EditIssue(id, eibm);

            Redirect(response, "/issues/all");
            return null;
        }

        [HttpGet]
        public IActionResult Delete(int id, HttpSession session, HttpResponse response)
        {
            if (!this.authenticationManager.IsAuthenticated(session))
            {
                Redirect(response, "/users/login");
                return null;
            }

            if (!this.authenticationManager.IsCurrentUserPost(id, session))
            {
                Redirect(response, "/issues/all");
                return null;
            }

            this.issuesService.DeleteIssue(id);
            Redirect(response, "/issues/all");
            return null;
        }
    }
}
