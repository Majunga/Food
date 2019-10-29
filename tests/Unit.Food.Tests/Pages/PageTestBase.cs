using Common.Conversion;
using Food.IService;
using Majunga.RazorModal;
using Moq;
using Service.Conversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unit.Food.Tests.Pages
{
    public class PageTestBase
    {
        public PageTestBase()
        {
            this.MockModalService = new Mock<ModalService>();
            this.MockDomainServices = new Mock<IServices>();

            var mapper = new ConversionConfiguration().MapperConfig.CreateMapper();
            this.Converter = new AutoMapperConversionService(mapper);
        }

        public Mock<ModalService> MockModalService { get; private set; }
        public Mock<IServices> MockDomainServices { get; private set; }
        public AutoMapperConversionService Converter { get; private set; }

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
