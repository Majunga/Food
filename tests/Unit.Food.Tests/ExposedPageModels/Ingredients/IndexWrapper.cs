using Food.IService;
using Food.Models.Ingredients;
using Food.Pages.Ingredients;
using Majunga.RazorModal;
using System.Collections.Generic;

namespace Unit.Food.Tests.ExposedPageModels.Ingredients
{
    public class IndexWrapper : IndexBase
    {
        internal IngredientViewModel xModel { get => base.Model; set => base.Model = value; }

        public ModalService xModalService { get => base.ModalService; set => base.ModalService = value; }
        public IServices xDomainServices { get => base.DomainServices; set => base.DomainServices = value; }

        public IEnumerable<IngredientViewModel> Ingredients => base.ingredients;
        public string xModalTitle => base.ModalTitle;

        public void xOnInitialized()
        {
            base.OnInitialized();
        }
    }
}
