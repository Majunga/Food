using System;
using System.Collections.Generic;
using System.Linq;
using Food.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Food.Dal
{
    public class GenericRepository<TEntity> : GenericRepository<TEntity, int>
        where TEntity : Entity
    {
        public GenericRepository(DbContext context) : base(context)
        {
            
        }
    }

    public abstract class GenericRepository<TEntity, TKey> where TEntity : Entity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Stores an instance of <see cref="TEntity"/>
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be stored</param>
        public virtual void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            DbSet.Add(entity);
        }

        public virtual IReadOnlyCollection<TEntity> Read()
        {
            return DbSet.ToList();
        }

        public virtual TEntity Read(TKey id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Stores an instance of <see cref="TEntity"/>
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be stored</param>
        public virtual void Update(TEntity entity)
        {
            this.DbSet.Attach(entity);
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TKey id)
        {
            var entity = this.Read(id);

            if(entity == null) return;

            DbSet.Remove(entity);
        }
    }
}