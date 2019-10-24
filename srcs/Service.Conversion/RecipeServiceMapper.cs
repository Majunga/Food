using AutoMapper;
using Food.Dal.Models;
using Food.IService.RecipeHandlers.Commands;

namespace Service.Conversion
{
    public class RecipeServiceMapper : Profile
    {
        public RecipeServiceMapper()
        {
            CreateMap<CreateRecipeCommand, Recipe>();
        }
    }
}
