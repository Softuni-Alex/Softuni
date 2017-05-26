using HotelBookingSystem.Models;

namespace HotelBookingSystem.Interfaces
{
    public interface IHotelBookingSystemData
    {
        IUserRepository UsersRepository { get; }

        IRepository<Venue> VenuesRepository { get; }

        IRepository<Room> RoomsRepository { get; }

        IRepository<Booking> BookingsRepository { get; }
    }
}