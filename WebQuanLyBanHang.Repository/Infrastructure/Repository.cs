﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly QuanLyBanHangDbContent _dbContext;
        private readonly DbSet<T> _entitiySet;


        public Repository(QuanLyBanHangDbContent dbContext)
        {
            _dbContext = dbContext;
            _entitiySet = _dbContext.Set<T>();
        }
        public void Add(T entity)
            => _dbContext.Add(entity);
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
            => await _dbContext.AddAsync(entity, cancellationToken);
        public void AddRange(IEnumerable<T> entities)
            => _dbContext.AddRange(entities);
        public async Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
            => await _dbContext.AddRangeAsync(entities, cancellationToken);
        public async Task<bool> CheckWord(Expression<Func<T, bool>> expression)
        {
            return await _entitiySet.Where(expression).AnyAsync();
        }
        public T Get(Expression<Func<T, bool>> expression)
            => _entitiySet.FirstOrDefault(expression);
        public IQueryable<T> GetAll()
            => _entitiySet.AsQueryable();
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
            => _entitiySet.Where(expression).AsQueryable();
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
          return await _entitiySet.ToListAsync<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.Where(expression).ToListAsync(cancellationToken);

        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
            => await _entitiySet.FirstOrDefaultAsync(expression, cancellationToken);

        public void Remove(T entity)
            => _dbContext.Remove(entity);
        public void RemoveRange(IEnumerable<T> entities)
            => _dbContext.RemoveRange(entities);

        public void Update(T entity)
            => _dbContext.Update(entity);
        public void UpdateRange(IEnumerable<T> entities)
            => _dbContext.UpdateRange(entities);
    }
}
