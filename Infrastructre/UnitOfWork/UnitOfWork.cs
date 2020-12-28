using Core.Interfaces;
using Infrastructre.Context;
using Infrastructre.REpository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructre.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DataContext _context;
        private IBaseRepository<T> _entity;
        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public IBaseRepository<T> Entity
        {
            get
            {
                return _entity ?? (_entity = new BaseRepository<T>(_context));
            }
        }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
