﻿namespace IntelExchange.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}