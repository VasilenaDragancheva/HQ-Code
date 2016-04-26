namespace ChepelareBookingSystem.Interfaces
{
    using ChepelareBookingSystem.Models;

    public interface IUserRepository : IRepository<User>
    {
        User GetByUsername(string username);
    }
}