﻿namespace Core.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IBaseRepository<T> Entity { get; }
        void save();
    }
}
