namespace ChepelareBookingSystem.Views.Users
{
    using System.Text;

    using ChepelareBookingSystem.Infrastructure;
    using ChepelareBookingSystem.Models;

    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        protected override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat("The user {0} has logged in.", user.Username).AppendLine();
        }
    }
}