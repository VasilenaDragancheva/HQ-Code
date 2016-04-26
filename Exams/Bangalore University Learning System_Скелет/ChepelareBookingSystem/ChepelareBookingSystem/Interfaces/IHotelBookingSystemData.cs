namespace ChepelareBookingSystem.Interfaces
{
    using ChepelareBookingSystem.Models;

    public interface IHotelBookingSystemData
    {
        IUserRepository RepositoryWithUsers { get; }

        IRepository<Venue> RepositoryWithVenues { get; }

        IRepository<Room> RepositoryWithRooms { get; }

        IRepository<Booking> RepositoryWithBookings { get; }
    }
}