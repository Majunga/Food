using System;
using Common.Conversion;
using Food.Dal.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Food.Dal
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        internal readonly DbContext Context;
        private readonly IConversionService _conversionService;
        private IIngredientRepository _ingredientRepository;


        public UnitOfWork(DbContext context, IConversionService conversionService)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            _conversionService = conversionService ?? throw new ArgumentNullException(nameof(conversionService));
        }

      
        public int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return this.Context.SaveChanges(acceptAllChangesOnSuccess);
        }

        public IIngredientRepository IngredientRepository => _ingredientRepository ??= new IngredientRepository(this.Context);

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }

    
    }
}
