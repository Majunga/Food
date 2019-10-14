using Service.Conversion;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Common.Conversion;
using Food.Dal;
using Food.IService;
using Food.Service;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Integration.Food.Service.Tests
{
    public class ServiceTestBase
    {
        public ServiceTestBase(ITestOutputHelper output)
        {
            var mapper = new ConversionConfiguration().MapperConfig.CreateMapper();
            this.Converter = new AutoMapperConversionService(mapper);

            var unitOfWork = CreateUnitOfWork(output);
            this.DomainServices = new DomainServices(unitOfWork, this.Converter);
        }

        protected AutoMapperConversionService Converter { get; }
        protected DomainServices DomainServices { get; }

        protected T Convert<T>(object source)
        {
            return (T)this.Converter.Convert(source, typeof(T));
        }

        protected void Map(object source, object target)
        {
            this.Converter.Map(source, target);
        }

        protected void RunCommand<TCommand>(TCommand command)
        {
            this.DomainServices.RunCommand(command);
        }

        protected TResult RunQuery<TResult>(IQuery<TResult> query)
        {
            return this.DomainServices.RunQuery(query);
        }

        private UnitOfWork CreateUnitOfWork(ITestOutputHelper output)
        {
            var type = output.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic) ?? throw new ArgumentNullException("type.GetField(\"test\", BindingFlags.Instance | BindingFlags.NonPublic)");
            var test = (ITest) testMember.GetValue(output);

            var unitOfWork = new UnitOfWork(SetupContext(test), this.Converter);
            return unitOfWork;
        }

        private DataContext SetupContext(ITest test)
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(test.DisplayName).Options;

            return new DataContext(options);
        }
    }
}
