namespace Exceptions.Models.Exams
{
    using System;

    public class CSharpExam : IExam
    {
        private const int MaxScores = 100;

        private const int MinScores = 0;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < MinScores || value > MaxScores)
                {
                    throw new ArgumentOutOfRangeException("Exam scores should be non negative");
                }

                this.score = value;
            }
        }

        public ExamResult Check()
        {
            return new ExamResult(this.Score, MinScores, MaxScores, "Exam results calculated by score.");
        }
    }
}