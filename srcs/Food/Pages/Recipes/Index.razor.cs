using Food.IService;
using Food.IService.RecipeHandlers.Commands;
using Food.IService.RecipeHandlers.Queries;
using Food.IService.RecipeHandlers.Queries;
using Food.Models.Recipes;
using Food.Models.Recipes;
using Majunga.RazorModal;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Food.Pages.Recipes
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        protected IServices DomainServices { get; set; }

        protected IEnumerable<RecipeViewModel> recipes = new List<RecipeViewModel>();

        protected override void OnInitialized()
        {
            LoadRecipesList();
        }

        public void LoadRecipesList()
        {
            var recipesDto = DomainServices.RunQuery(new GetAllRecipesQuery());
            var recipeViews = DomainServices.Convert<List<RecipeViewModel>>(recipesDto);
            OrderBy(recipeViews, asc);
        }

        #region list ordering

        private bool asc = true;
        public void Reorder()
        {
            asc = !asc;
            OrderBy(recipes, asc);
        }

        private void OrderBy(IEnumerable<RecipeViewModel> recipeViews, bool ascending)
        {
            if (recipeViews == null) return;

            if (ascending)
            {
                recipes = recipeViews.OrderBy(m => m.Name);
            }
            else
            {
                recipes = recipeViews.OrderByDescending(m => m.Name);
            }
        }

        #endregion
    }
}
