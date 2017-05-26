namespace HotelBookingSystem.Views.Venues
{
    using Infrastructure;
    using Models;
    using System.Text;

    public class Add : View
    {
        public Add(Venue venue)
            : base(venue)
        {
            // https://awesomecommentphotos.files.wordpress.com/2013/08/1003531_560612187329667_1660736981_n.jpg?w=326
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("The venue {0} with ID {1} has been created successfully.", venue.Name, venue.Id).AppendLine();
        }
    }
}