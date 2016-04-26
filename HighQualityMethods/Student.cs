namespace Methods
{
    using System;

    public class Student
    {
        private DateTime birthDate;

        private string firstName;

        private string lastName;

        private string nativeTown;

        public Student(string firstName, string lastName, string nativeTown, DateTime birthdate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NativeTown = nativeTown;
            this.DateOfBirth = birthdate;
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                if (value.Year < 1900 || value > DateTime.Today)
                {
                    throw new ArgumentOutOfRangeException("Datebirth is not valid!");
                }

                this.birthDate = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name can not be null!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name can not be null!");
                }

                this.lastName = value;
            }
        }

        public string NativeTown
        {
            get
            {
                return this.nativeTown;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Native town can not be null!");
                }

                this.nativeTown = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            bool isOlder = this.DateOfBirth.CompareTo(other.DateOfBirth) == -1;
            return isOlder;
        }
    }
}