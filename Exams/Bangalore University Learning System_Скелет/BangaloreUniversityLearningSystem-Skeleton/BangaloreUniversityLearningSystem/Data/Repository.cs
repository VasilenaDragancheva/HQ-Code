﻿namespace BangaloreUniversityLearningSystem.Data
{
    using System;
    using System.Collections.Generic;

    using BangaloreUniversityLearningSystem.Contracts;

    public class Repository<T> : IRepository<T>
    {
        private readonly List<T> items;

        public Repository()
        {
            this.items = new List<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this.items;
        }

        public T Get(int id)
        {
            T item;
            try
            {
                item = this.items[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                item = default(T);
            }

            return item;
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }
    }
}