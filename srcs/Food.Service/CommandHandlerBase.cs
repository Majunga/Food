using Common.Conversion;
using Food.Dal;
using Food.IService;

namespace Food.Service
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
    {
        private readonly IConversionService _converter;
        public IUnitOfWork UnitOfWork { get; }

        protected CommandHandlerBase(IUnitOfWork unitOfWork, IConversionService converter)
        {
            _converter = converter;
            UnitOfWork = unitOfWork;
        }

        public abstract void Handle(TCommand command);
        
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