using Food.IService;
using Food.IService.RecipeHandlers.Commands;
using Food.IService.RecipeHandlers.Queries;
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

        [Parameter]
        public int? RecipeId { get; set; }

        [Parameter]
        public bool? Success { get; set; }

        protected string Title { get; set; }

        protected RecipeViewModel Model { get; set; } = new RecipeViewModel();
        protected string CreatedSuccessfully { get; private set; }

        protected override void OnInitialized()
        {
            if (RecipeId.HasValue)
            {
                var recipeDto = this.DomainServices.RunQuery(new GetRecipeByIdQuery(RecipeId.Value));
                this.DomainServices.Map(recipeDto, this.Model);

                this.Title = "Edit Recipe";

                if (Success == true)
                {
                    this.CreatedSuccessfully = $"Recipe {this.Model.Name} created successfully";
                }
            }
            else
            {
                this.Title = "Create Recipe";
            }
        }

        public void Save()
        {
            if (this.Model.Id.HasValue)
            {
                var command = this.DomainServices.Convert<UpdateRecipeCommand>(this.Model);
                this.DomainServices.RunCommand(command);
                NavigationManager.NavigateTo($"recipes/edit/{command.Id}");
            }
            else
            {
                var command = this.DomainServices.Convert<CreateRecipeCommand>(this.Model);
                this.DomainServices.RunCommand(command);
                this.Success = true;
                NavigationManager.NavigateTo($"recipes/edit/{command.Id}/{Success}", true);
            }
        }

        public void Delete()
        {
            var command = new DeleteRecipeCommand(this.RecipeId.Value);
            this.DomainServices.RunCommand(command);

            NavigationManager.NavigateTo($"recipes");
        }
    }
}
