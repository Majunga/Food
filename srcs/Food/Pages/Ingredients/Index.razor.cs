﻿using Food.IService;
using Food.IService.IngredientHandlers.Commands;
using Food.IService.IngredientHandlers.Queries;
using Food.Models.Ingredients;
using Majunga.RazorModal;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Food.Pages.Ingredients
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        protected IServices DomainServices { get; set; }

        [Inject]
        protected ModalService ModalService { get; set; }

        protected IngredientViewModel Model = new IngredientViewModel();
        protected IEnumerable<IngredientViewModel> ingredients = new List<IngredientViewModel>();
        protected string ModalTitle = "Create ingredient";

        protected override void OnInitialized()
        {
            this.LoadIngredientsList();
        }

        public void LoadIngredientsList()
        {
            var ingredientsDto = this.DomainServices.RunQuery(new GetAllIngredientsQuery());
            var ingredientViews = this.DomainServices.Convert<List<IngredientViewModel>>(ingredientsDto);
            OrderBy(ingredientViews, asc);
        }

        
        public void ShowModal(string buttonClicked)
        {
            ModalTitle = $"{buttonClicked} ingredient";
            ModalService.Show();
        }

        public void SaveModal()
        {
            var command = DomainServices.Convert<CreateIngredientCommand>(Model);
            DomainServices.RunCommand(command);

            LoadIngredientsList();
            Model = new IngredientViewModel();

            ModalService.Hide();
        }

        #region list ordering

        private bool asc = true;
        public void Reorder()
        {
            OrderBy(this.ingredients, asc);
            asc = !asc;
        }

        private void OrderBy(IEnumerable<IngredientViewModel> ingredientViews, bool asc)
        {
            if (asc)
            {
                this.ingredients = ingredientViews.OrderBy(m => m.Name);
            }
            else
            {
                this.ingredients = ingredientViews.OrderByDescending(m => m.Name);
            }
        }

        #endregion
    }
}
