namespace BangaloreUniversityLearningSystem.Models
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Utilities;

    public class User
    {
        private string hashedPassword;

        private string username;

        public User(string username, string password, Role role)
        {
            this.Username = username;
            this.HashPassword = password;
            this.Role = role;
            this.Courses = new List<Course>();
        }

        public string Username
        {
            get
            {
                return this.username;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("The username must be at least 5 symbols long.");
                }

                this.username = value;
            }
        }

        public string HashPassword
        {
            get
            {
                return this.hashedPassword;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 6)
                {
                    throw new ArgumentException("The password must be at least 6 symbols long.");
                }

                string passwordHash = HashUtilities.HashPassword(value);
                this.hashedPassword = passwordHash;
            }
        }

        public Role Role { get; private set; }

        public IList<Course> Courses { get; private set; }
    }
}