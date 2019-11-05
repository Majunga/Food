using Food.ViewModels.Recipes;
using Microsoft.AspNetCore.Components;

namespace Food.Pages.Recipes
{
    public class GridViewBase : ComponentBase
    {
        [Inject]
        protected IGridViewModel GridViewModel { get; set; }

        protected override void OnInitialized()
        {
            this.GridViewModel.LoadGrid();
        }
    }
}
