using DataTransferObjects.BindingModels;
using DataTransferObjects.ViewModels;
using RepositoryLayer;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using System;
using Utility.Security;

namespace IssueTracker.Controllers
{
    public class IssueController : Controller
    {
        private readonly IIssueService service;
        //make an interface
        private readonly SignInManager singInManager;

        public IssueController()
        {
            this.singInManager = new SignInManager(new IssueTrackerData());
            this.service = new IssueService(new IssueTrackerData(), this.singInManager);
        }

        [HttpGet]
        public IActionResult<IssueViewModel> All()
        {
            try
            {
                var issues = this.service.All();

                var issueViewModel = new IssueViewModel();

                foreach (var issue in issues)
                {
                    issueViewModel.Id = issue.Id;
                    issueViewModel.Date = DateTime.Today;
                    issueViewModel.Name = issue.Name;
                }

                return this.View(issueViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception($"Exeption of type: {ex.GetType().Name} and Message: {ex.Message} has been thrown.");
            }
            //            return null;
            //            //display issuecollectionviewmodel
            //            //display issues - > query them
            //            //user from session
            //            //display issueviewModel
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public void Add(HttpResponse response, HttpSession session, AddIssueBindingModel model)
        {
            try
            {
                this.service.Add(session, model);
                this.Redirect(response, "/issue/all");
            }
            catch (Exception ex)
            {
                throw new Exception($"Exeption of type: {ex.GetType().Name} and Message: {ex.Message} has been thrown.");
            }
        }
    }
}
