using Common.Conversion;
using Food.IService;
using Majunga.RazorModal;
using Microsoft.AspNetCore.Components;
using Moq;
using Service.Conversion;

namespace Unit.Food.Tests.Pages
{
    public class PageTestBase
    {
        public PageTestBase()
        {
            this.MockModalService = new Mock<ModalService>();
            this.MockDomainServices = new Mock<IServices>();
            this.MockNavigationManager = new Mock<NavigationManager>();

            var mapper = new ConversionConfiguration().MapperConfig.CreateMapper();
            this.Converter = new AutoMapperConversionService(mapper);
        }

        public Mock<ModalService> MockModalService { get; private set; }
        public Mock<IServices> MockDomainServices { get; private set; }
        public Mock<NavigationManager> MockNavigationManager { get; }
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
