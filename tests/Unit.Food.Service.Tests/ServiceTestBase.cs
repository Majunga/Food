using Common.Conversion;
using Food.Dal;
using Food.Dal.Repositories;
using Food.Service;
using IService;
using Moq;
using Service.Conversion;

namespace Unit.Food.Service.Tests
{
    public class ServiceTestBase
    {
        public DomainServices DomainServices { get; }
        public AutoMapperConversionService Converter { get; }
        protected Mock<IUnitOfWork> MockUnitOfWork { get; }
        public Mock<IIngredientRepository> MockIngredientRepository { get; }

        public ServiceTestBase()
        {
            var mapper = new ConversionConfiguration().MapperConfig.CreateMapper();
            this.Converter = new AutoMapperConversionService(mapper);

            this.MockUnitOfWork = new Mock<IUnitOfWork>();
            this.MockIngredientRepository = new Mock<IIngredientRepository>();

            this.MockUnitOfWork.SetupGet(m => m.IngredientRepository).Returns(() => this.MockIngredientRepository.Object);

            this.DomainServices = new DomainServices(this.MockUnitOfWork.Object, this.Converter);
        }

        protected void RunCommand<TCommand>(TCommand command)
        {
            this.DomainServices.RunCommand(command);
        }
        
        protected TResult RunQuery<TResult>(IQuery<TResult> query)
        {
            return this.DomainServices.RunQuery(query);
        }


        protected T Convert<T>(object source)
        {
            return (T)this.Converter.Convert(source, typeof(T));
        }

        protected void Map(object source, object target)
        {
            this.Converter.Map(source, target);
        }
    }
}
