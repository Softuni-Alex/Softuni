using System.Collections.Generic;

namespace DataTransferObjects.ViewModels
{
    public class IssueViewModel
    {
        public IssueViewModel()
        {
            this.Issues = new HashSet<IssueViewModel>();
        }

        public LoggedInUserViewModel LoggedInUserViewModel { get; set; }

        public HashSet<IssueViewModel> Issues { get; set; }
    }
}
