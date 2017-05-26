namespace IssueTracker.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModels;
    using Models;
    using Models.Enums;
    using ViewModels;

    public class IssuesService : Service
    {
        public HashSet<IssueViewModel> RetrieveAllIssues(string status, string query)
        {
            User currentUser = this.LoginRepository.RetrieveCurrentlyLogged();
            HashSet<IssueViewModel> issuesVm = new HashSet<IssueViewModel>();
            List<Issue> allIssues = this.IssueRepository.All().ToList();
            if (status != null && status != "All")
            {
                allIssues = allIssues.Where(i => i.Status.ToString() == status).ToList();
            }

            if (query != null)
            {
                query = WebUtility.UrlDecode(query);
                allIssues = allIssues.Where(i => i.Name.ToLower().Contains(query.ToLower())).ToList();
            }

            ConfigureIssueMapper(currentUser);
            foreach (Issue issue in allIssues)
            {
                IssueViewModel ivm = Mapper.Map<IssueViewModel>(issue);

                issuesVm.Add(ivm);
            }

            return issuesVm;
        }

        public void CreateIssue(CreateIssueBindingModel cibm)
        {
            Issue issueEntity = new Issue()
            {
                Name = cibm.Name,
                Priority = (Priority) Enum.Parse(typeof(Priority), cibm.Priority),
                Status = (Status) Enum.Parse(typeof(Status), cibm.Status),
                Author = this.LoginRepository.RetrieveCurrentlyLogged(),
                CreatedOn = DateTime.Now
            };

            this.IssueRepository.Insert(issueEntity);
            this.SaveChanges();
        }

        public void EditIssue(int id, EditIssueBindingModel eibm)
        {
            Issue issueEntity = this.IssueRepository.Find(id);
            issueEntity.Name = eibm.Name;
            issueEntity.Priority = (Priority) Enum.Parse(typeof(Priority), eibm.Priority);
            issueEntity.Status = (Status)Enum.Parse(typeof(Status), eibm.Status);

            this.SaveChanges();
        }

        public void DeleteIssue(int id)
        {
            Issue issueEntity = this.IssueRepository.Find(id);
            this.IssueRepository.Delete(issueEntity);

            this.SaveChanges();
        }

        private void ConfigureIssueMapper(User currentUser)
        {
            Mapper.Initialize(action =>
                action.CreateMap<Issue, IssueViewModel>()
                    .ForMember(issue => issue.Priority, config => config.MapFrom(x => x.Priority.ToString()))
                    .ForMember(issue => issue.IsEditable, config => config.MapFrom(x => currentUser.Role == Role.Administrator || currentUser.Issues.Contains(x)))
                    .ForMember(issue => issue.Status, config => config.MapFrom(x => x.Status.ToString()))
                    .ForMember(issue => issue.Author, config => config.MapFrom(x => x.Author.Role == Role.Administrator ? "Admin" : x.Author.Username))
            );
        }
    }
}
