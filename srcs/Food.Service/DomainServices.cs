using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Common.Conversion;
using Common.Exceptions.NotFound;
using Food.Dal;
using Food.IService;

namespace Food.Service
{
    public class DomainServices : IServices
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IConversionService _converter;

        public DomainServices(IUnitOfWork unitOfWork, IConversionService converter)
        {
            this._unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this._converter = converter ?? throw new ArgumentNullException(nameof(converter));
        }

        public void RunCommand<TCommand>(TCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var commandHandler = typeof(CommandHandlerBase<TCommand>).Assembly.GetTypes().FirstOrDefault(t => t.IsSubclassOf(typeof(CommandHandlerBase<TCommand>)) && !t.IsAbstract);

            if (commandHandler == null)
            {
                throw new CommandHandlerNotFoundException();
            }

            var handler = (ICommandHandler<TCommand>)Activator.CreateInstance(commandHandler, this._unitOfWork, this._converter);

            handler.Handle(command);
        }

        public TResult RunQuery<TResult>(IQuery<TResult> query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            var handlerType = typeof(QueryHandlerBase<,>);

            var types = handlerType.Assembly.GetTypes();
            var queryHandler = types.FirstOrDefault(t => t.BaseType != null &&
                                                         (!t.IsAbstract && t.BaseType.GetGenericArguments().Contains(query.GetType())));

            if (queryHandler == null)
            {
                throw new QueryHandlerNotFoundException();
            }

            dynamic handler = Activator.CreateInstance(queryHandler, this._unitOfWork, this._converter);

            return handler.Handle((dynamic)query);
        }

        
        public T Convert<T>(object source)
        {
            return (T)this._converter.Convert(source, typeof(T));
        }

        public void Map(object source, object target)
        {
            this._converter.Map(source, target);
        }
    }
}
