
using System.Linq.Expressions;

namespace WebQuanLyBanHang.Repository.Interface
{
    public interface IRepository<TEnty> where TEnty : class
    {
        TEnty Get(Expression<Func<TEnty, bool>> expression);
        IQueryable<TEnty> GetAll();
        IQueryable<TEnty> GetAll(Expression<Func<TEnty, bool>> expression);
        Task<bool> CheckWord(Expression<Func<TEnty, bool>> expression);
        void Add(TEnty entity);
        void AddRange(IEnumerable<TEnty> entities);
        void Remove(TEnty entity);
        void RemoveRange(IEnumerable<TEnty> entities);
        void Update(TEnty entity);
        void UpdateRange(IEnumerable<TEnty> entities);
        Task<TEnty> GetAsync(Expression<Func<TEnty, bool>> expression, CancellationToken cancellationToken = default);
        Task<IEnumerable<TEnty>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEnty>> GetAllAsync(Expression<Func<TEnty, bool>> expression, CancellationToken cancellationToken = default);
        Task AddAsync(TEnty entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEnty> entities, CancellationToken cancellationToken = default);
       
    }

}
