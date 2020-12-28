using Core.Interfaces;
using Infrastructre.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructre.REpository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext context;
        private DbSet<T> table = null;
        public BaseRepository(DataContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public void Delete(object id)
        {
               T existing = GetById(id);
            table.Remove(existing);

        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T entity)
        {
             table.Add(entity);

        }
        public void Update(T entity)
        {
            table.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

        }
    }
}
