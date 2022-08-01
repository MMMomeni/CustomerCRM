using CustomerCRM.Core.Contracts.Repository;
using CustomerCRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        /* We must implement a constructor here in order to pass a dbContext into it and retrive
         * DbSet from it's properties (this is also called DI, Dependancy Injection, which means 
         * declare the object outside and initialize in this constructor
         */
        CustomerCrmDbContext dbContext;
        public BaseRepositoryAsync(CustomerCrmDbContext _context)
        {
            dbContext = _context;
        }
        public async Task<int> DeleteAsync(int id)
        {
            /* FindAsync(id) here works as Where(x=>x.id==id).FirstOrDefault()
             * SaveChangesAsync() works as "commit" and applies "Unit of Work"
             */
            var entity = await dbContext.Set<T>().FindAsync(id);
            dbContext.Set<T>().Remove(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            /* Since "entity" is a reference type, this line will modify the entity
             * which will affect all reference instaces of entity */
            dbContext.Entry<T>(entity).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync();
        }
    }
}
