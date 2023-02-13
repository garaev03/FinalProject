using Core.Entities.Concrets;
using Core.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Implementations
{
    public class TEntityRepository<T, Context> : ITEntityRepository<T>
        where T : Entity
        where Context : IdentityDbContext<AppUser>
    {
        private readonly Context _db;

        public TEntityRepository(Context db)
        {
            _db = db;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp, params string[]? includes)
        {
            IQueryable<T> query = _db.Set<T>().Where(exp);
            if (includes is not null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, params string[]? includes)
        {
            var db = _db.Set<T>();
            if (includes is not null)
                foreach (var item in includes) { db.Include(item); }

            T? model = await db.FirstOrDefaultAsync(x => x.Id == id);
            if (model is not null && model.isDeleted)
                model = null;
            return model;
        }


        public async Task CreateAsync(T model)
        {
            await _db.Set<T>().AddAsync(model);
        }

        public void DeleteAsync(T model)
        {
            model.isDeleted = true;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
