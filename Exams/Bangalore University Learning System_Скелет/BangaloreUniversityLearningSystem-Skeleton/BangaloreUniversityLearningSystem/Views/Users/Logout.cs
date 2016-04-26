namespace BangaloreUniversityLearningSystem.Views.Users
{
    using System.Text;

    using BangaloreUniversityLearningSystem.Models;

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        public override void BuildViewResult(StringBuilder viewResult)
        {
            User user = this.Model as User;
            viewResult.AppendFormat("User {0} logged out successfully.", user.Username).AppendLine();
        }
    }
}