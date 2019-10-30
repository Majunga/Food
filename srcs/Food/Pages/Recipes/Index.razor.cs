﻿using Food.IService;
using Food.IService.RecipeHandlers.Commands;
using Food.IService.RecipeHandlers.Queries;
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

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected IEnumerable<RecipeViewModel> recipes = new List<RecipeViewModel>();

        protected override void OnInitialized()
        {
            LoadGrid();
        }

        public void LoadGrid()
        {
            var recipesDto = DomainServices.RunQuery(new GetAllRecipesQuery());
            var recipeViews = DomainServices.Convert<List<RecipeViewModel>>(recipesDto);
            OrderBy(recipeViews, asc);
        }

        public void GotoEditPage(int? recipeId = null)
        {
            if (recipeId.HasValue)
            {
                NavigationManager.NavigateTo($"recipes/edit/{recipeId}");
            }
            else
            {
                NavigationManager.NavigateTo("recipes/edit");
            }
        }

        #region list ordering

        private bool asc = true;
        public void Reorder(string columnName)
        {
            asc = !asc;
            OrderBy(recipes, asc, columnName);
        }

        private void OrderBy(IEnumerable<RecipeViewModel> recipeViews, bool ascending, string columnName = nameof(RecipeViewModel.Name))
        {
            if (recipeViews == null) return;

            if (ascending)
            {
                if (columnName == nameof(RecipeViewModel.Name))
                {
                    recipes = recipeViews.OrderBy(m => m.Name);
                }

                if (columnName == nameof(RecipeViewModel.Description))
                {
                    recipes = recipeViews.OrderBy(m => m.Description);
                }
            }
            else
            {
                if (columnName == nameof(RecipeViewModel.Name))
                {
                    recipes = recipeViews.OrderByDescending(m => m.Name);
                }

                if (columnName == nameof(RecipeViewModel.Description))
                {
                    recipes = recipeViews.OrderBy(m => m.Description);
                }
            }
        }

        #endregion
    }
}
