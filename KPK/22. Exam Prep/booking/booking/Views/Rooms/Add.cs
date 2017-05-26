namespace HotelBookingSystem.Views.Rooms
{
    using Infrastructure;
    using Models;
    using System.Text;

    public class Add : View
    {
        public Add(Room room)
            : base(room)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var room = this.Model as Room;
            viewResult.AppendFormat("The room with ID {0} has been created successfully.", room.Id).AppendLine();
        }
    }
}