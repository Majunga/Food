using AutoMapper;
using Food.Dal.Models;
using Food.IService.RecipeHandlers.Commands;
using Food.IService.RecipeHandlers.Models;

namespace Service.Conversion
{
    public class RecipeServiceMapper : Profile
    {
        public RecipeServiceMapper()
        {
            CreateMap<CreateRecipeCommand, Recipe>();
            CreateMap<Recipe, RecipeDto>();
        }
    }
}
