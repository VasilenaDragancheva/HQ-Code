namespace Exceptions.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using global::Exceptions.Models.Exams;

    public class Student
    {
        private IList<IExam> exams;

        private string firstName;

        private string lastName;

        public Student(string firstName, string lastName, IList<IExam> exams = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public IList<IExam> Exams
        {
            get
            {
                return this.exams;
            }

            set
            {
                this.exams = value ?? new List<IExam>();
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
                if (value == null)
                {
                    throw new ArgumentNullException("Student first name");
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
                if (value == null)
                {
                    throw new ArgumentNullException("student last name");
                }

                this.lastName = value;
            }
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams == null)
            {
                // Cannot calculate average on missing exams
                throw new Exception();
            }

            if (this.Exams.Count == 0)
            {
                // No exams --> return -1;
                return -1;
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] = ((double)examResults[i].Grade - examResults[i].MinGrade)
                               / (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null)
            {
                throw new Exception("Wow! Error happened!!!");
            }

            if (this.Exams.Count == 0)
            {
                Console.WriteLine("The student has no exams!");
                return null;
            }

            IList<ExamResult> results = new List<ExamResult>();

            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }
    }
}