namespace IssueTracker.App.ViewModels
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string message)
        {
            this.Message = message;
        }
        public string Message { get; set; }

        public override string ToString()
        {
            return "<div class=\"alert alert-danger alert-dismissable\">\r\n " +
                   " <a href=\"\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\r\n " +
                   $" <strong>Error!</strong> \"{this.Message}\"\r\n</div>";
        }
    }
}
