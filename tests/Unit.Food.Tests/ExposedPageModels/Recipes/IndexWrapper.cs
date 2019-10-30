using Food.IService;
using Food.Models.Recipes;
using Food.Pages.Recipes;
using Majunga.RazorModal;
using System.Collections.Generic;

namespace Unit.Food.Tests.ExposedPageModels.Recipes
{
    public class IndexWrapper : IndexBase
    {
        public IndexWrapper(IServices domainServices)
        {
            this.xDomainServices = domainServices;
        }

        public IServices xDomainServices { get => DomainServices; set => DomainServices = value; }

        public IEnumerable<RecipeViewModel> Recipes => recipes;

        public void xOnInitialized()
        {
            base.OnInitialized();
        }
    }
}
