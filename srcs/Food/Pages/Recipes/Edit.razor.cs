using Food.IService;
using Food.IService.RecipeHandlers.Commands;
using Food.Models.Recipes;
using Microsoft.AspNetCore.Components;

namespace Food.Pages.Recipes
{
    public class EditBase : ComponentBase
    {
        [Inject]
        protected IServices DomainServices { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected string Title { get; set; }

        protected RecipeViewModel Model { get; set; } = new RecipeViewModel();

        protected override void OnInitialized()
        {
            this.Title = "Create Recipe";
        }

        public void Save()
        {
            var command = this.DomainServices.Convert<CreateRecipeCommand>(this.Model);
            this.DomainServices.RunCommand(command);

            NavigationManager.NavigateTo("recipes");
        }
    }
}
