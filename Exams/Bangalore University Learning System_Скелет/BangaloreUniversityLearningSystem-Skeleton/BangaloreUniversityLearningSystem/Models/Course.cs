﻿namespace BangaloreUniversityLearningSystem
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Models;

    public class Course
    {
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.Students = new List<User>();
            this.Lectures = new List<Lecture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException("The course name must be at least 5 symbols long.");
                }

                this.name = value;
            }
        }

        public IList<Lecture> Lectures { get; set; }

        public IList<User> Students { get; set; }

        public void AddLecture(Lecture lecture)
        {
            this.Lectures.Add(lecture);
        }

        public void AddStudent(User student)
        {
            this.Students.Add(student);
            student.Courses.Add(this);
        }
    }
}