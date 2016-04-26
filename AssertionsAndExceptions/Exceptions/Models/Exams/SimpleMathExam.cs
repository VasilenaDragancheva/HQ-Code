namespace Exceptions.Models.Exams
{
    using System;
    using System.Collections.Generic;

    public class SimpleMathExam : IExam
    {
        private const int MaxScores = 6;

        private const int MinScores = 2;

        private int problemsSolved;

        private Dictionary<int, int> resultTable = new Dictionary<int, int> { { 0, 2 }, { 1, 4 }, { 2, 6 } };

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value < 0 || value > 2)
                {
                    throw new ArgumentOutOfRangeException("Count of solved prpoblem should be postive. and less than 2");
                }

                this.problemsSolved = value;
            }
        }

        public ExamResult Check()
        {
            return new ExamResult(this.resultTable[this.ProblemsSolved], MinScores, MaxScores, "Results");
        }
    }
}