using DataTransferObjects.BindingModels;
using DataTransferObjects.Enumerations;
using DbEntities.Models;
using RepositoryLayer.Interfaces;
using ServiceLayer.Interfaces;
using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Security;

namespace ServiceLayer.Services
{
    public class IssueService : BaseService, IIssueService
    {
        private SignInManager manager;

        public IssueService(IIssueTrackerData data, SignInManager manager)
            : base(data)
        {
            this.manager = manager;
        }

        public void Add(HttpSession session, AddIssueBindingModel model)
        {
            this.CheckIfNull(model);

            var firstOrDefault = this.Data.Logins.Query().FirstOrDefault(u => u.SessionId == session.Id && u.IsActive);

            if (firstOrDefault != null)
            {
                var getAuthor = firstOrDefault.UserId;

                var issue = new Issue()
                {
                    Name = model.Name,
                    PriorityId = model.PriorityId,
                    StatusId = model.StatusId,
                    CreationDate = DateTime.Today,
                    AuthorId = getAuthor
                };

                this.Data.Issue.Add(issue);
            }
            if (firstOrDefault == null)
            {
                throw new ArgumentNullException(nameof(firstOrDefault), "You should first log in!");
            }
            this.Data.SaveChanges();
        }

        public List<Issue> All()
        {
            var issues = this.Data.Issue.Query().ToList();

            return issues;
        }

        public void getsmth()
        {
            var id = this.Data.Issue.Query().Select(u => u.PriorityId);

            string value = Enum.GetName(typeof(IssueStatusTypes), id);
        }
    }
}
