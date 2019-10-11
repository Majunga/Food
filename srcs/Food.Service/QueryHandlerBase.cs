using Common.Conversion;
using Food.Dal;
using IService;

namespace Food.Service
{
    public abstract class QueryHandlerBase<TQuery, TResult> : IQueryHandler<TQuery, TResult>
    {
        private readonly IConversionService _converter;
        public IUnitOfWork UnitOfWork { get; }

        protected QueryHandlerBase(IUnitOfWork unitOfWork, IConversionService converter)
        {
            _converter = converter;
            UnitOfWork = unitOfWork;
        }

        public TResult Handle(TQuery query)
        {
            var result = this.Run(query);

            return this.Convert<TResult>(result);
        }

        public abstract object Run(TQuery query);

        
        protected T Convert<T>(object source)
        {
            return (T)this._converter.Convert(source, typeof(T));
        }

        protected void Map(object source, object target)
        {
            this._converter.Map(source, target);
        }
    }
}