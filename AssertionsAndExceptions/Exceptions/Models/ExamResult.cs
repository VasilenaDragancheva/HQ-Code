namespace Exceptions.Models
{
    using System;

    public class ExamResult
    {
        private string comment;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.ValidateGrades(grade, minGrade, maxGrade);
            this.Comments = comments;
        }

        public int Grade { get; private set; }

        public int MaxGrade { get; private set; }

        public int MinGrade { get; private set; }

        public string Comments
        {
            get
            {
                return this.comment;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("comment", "There is no comment input");
                }

                this.comment = value;
            }
        }

        private void ValidateGrades(int grade, int minGrade, int maxGrade)
        {
            if (grade < 0 || minGrade < 0 || maxGrade < 0)
            {
                throw new ArgumentOutOfRangeException("grades", "All grades should be positives");
            }

            if (minGrade >= maxGrade)
            {
                throw new ArgumentException("Min grade should be smaller than max grade ");
            }

            if (grade < minGrade || grade > maxGrade)
            {
                throw new ArgumentOutOfRangeException("currentGrade", "Current grade should be in range of min and max grade");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
        }
    }
}