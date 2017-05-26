namespace DataTransferObjects.ViewModels
{
    public class RegistrationVerificationErrorViewModel
    {
        public string Message { get; set; }

        public override string ToString()
        {
            string template =
                $"<div class=\"alert alert-danger alert-dismissable\">\n  <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\n  <strong>Error!</strong> \"{this.Message}\"\n</div>";

            return template;
        }
    }
}
