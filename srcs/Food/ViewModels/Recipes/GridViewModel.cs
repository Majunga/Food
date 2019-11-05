using Food.IService;
using Food.IService.RecipeHandlers.Queries;
using Food.Models.Recipes;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Food.ViewModels.Recipes
{
    public interface IGridViewModel
    {
        IEnumerable<RecipeViewModel> Model { get; set; }
        void LoadGrid();
        void Reorder(string columnName);
        void GotoEditPage(int? recipeId = null);
    }

    public class GridViewModel : IGridViewModel
    {
        private readonly NavigationManager _navigationManager;
        private readonly IServices _domainService;

        public GridViewModel(NavigationManager navigationManager, IServices domainService)
        {
            this._navigationManager = navigationManager;
            this._domainService = domainService;
        }

        public IEnumerable<RecipeViewModel> Model { get; set; } = new List<RecipeViewModel>();

        public void LoadGrid()
        {
            var recipesDto = this._domainService.RunQuery(new GetAllRecipesQuery());
            var recipeViews = this._domainService.Convert<List<RecipeViewModel>>(recipesDto);
            this.OrderBy(recipeViews, asc);
        }

        public void GotoEditPage(int? recipeId = null)
        {
            if (recipeId.HasValue)
            {
                this._navigationManager.NavigateTo($"recipes/edit/{recipeId}");
            }
            else
            {
                this._navigationManager.NavigateTo("recipes/edit");
            }
        }

        #region list ordering

        private bool asc = true;
        public void Reorder(string columnName)
        {
            asc = !asc;
            this.OrderBy(Model, asc, columnName);
        }

        private void OrderBy(IEnumerable<RecipeViewModel> recipeViews, bool ascending, string columnName = nameof(RecipeViewModel.Name))
        {
            if (recipeViews == null) return;

            if (ascending)
            {
                if (columnName == nameof(RecipeViewModel.Name))
                {
                    this.Model = recipeViews.OrderBy(m => m.Name);
                }

                if (columnName == nameof(RecipeViewModel.Description))
                {
                    this.Model = recipeViews.OrderBy(m => m.Description);
                }
            }
            else
            {
                if (columnName == nameof(RecipeViewModel.Name))
                {
                    this.Model = recipeViews.OrderByDescending(m => m.Name);
                }

                if (columnName == nameof(RecipeViewModel.Description))
                {
                    this.Model = recipeViews.OrderBy(m => m.Description);
                }
            }
        }

        #endregion
    }
}
