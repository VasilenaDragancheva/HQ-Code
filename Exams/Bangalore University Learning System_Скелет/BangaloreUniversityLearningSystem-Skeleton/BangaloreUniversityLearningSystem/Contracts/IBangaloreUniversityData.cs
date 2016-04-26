namespace BangaloreUniversityLearningSystem.Contracts
{
    using BangaloreUniversityLearningSystem.Data;

    public interface IBangaloreUniversityData
    {
        UsersRepository Users { get; }

        IRepository<Course> Courses { get; }
    }
}