using AutoMapper;
using Food.Dal.Models;
using Food.IService.RecipeHandlers.Commands;
using Food.IService.RecipeHandlers.Models;
using Food.Models.Recipes;

namespace Service.Conversion
{
    public class RecipeServiceMapper : Profile
    {
        public RecipeServiceMapper()
        {
            CreateMap<CreateRecipeCommand, Recipe>();
            CreateMap<UpdateRecipeCommand, Recipe>();
            CreateMap<Recipe, RecipeDto>();
            CreateMap<RecipeDto, RecipeViewModel>();
            CreateMap<RecipeViewModel, CreateRecipeCommand>();
            CreateMap<RecipeViewModel, UpdateRecipeCommand>();
        }
    }
}
