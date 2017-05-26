using DataTransferObjects.BindingModels;
using DbEntities.Models;
using SimpleHttpServer.Models;
using System.Collections.Generic;

namespace ServiceLayer.Interfaces
{
    public interface IIssueService
    {
        void Add(HttpSession session, AddIssueBindingModel model);

        List<Issue> All();
    }
}
