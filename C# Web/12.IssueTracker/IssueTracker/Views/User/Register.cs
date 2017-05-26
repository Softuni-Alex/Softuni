using DataTransferObjects.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utility.Utilities;

namespace IssueTracker.Views.User
{
    public class Register : IRenderable<HashSet<RegistrationVerificationErrorViewModel>>
    {
        public HashSet<RegistrationVerificationErrorViewModel> Model { get; set; }

        public string Render()
        {
            StringBuilder renderHtml = new StringBuilder();
            StringBuilder errorBuilder = new StringBuilder();

            foreach (var registrationVerificationErrorViewModel in this.Model)
            {
                errorBuilder.Append(registrationVerificationErrorViewModel);
            }

            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Header));
            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Menu));
            renderHtml.Append(errorBuilder);
            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Register));
            renderHtml.AppendLine(File.ReadAllText(ViewBuilder.DefaultPath + ViewBuilder.Footer));

            return renderHtml.ToString();
        }
    }
}
