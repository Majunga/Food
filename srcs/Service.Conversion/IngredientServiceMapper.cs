using AutoMapper;
using Food.Dal.Models;
using Food.IService.IngredientHandlers.Commands;
using Food.IService.IngredientHandlers.Models;
using Food.Models.Ingredients;

namespace Service.Conversion
{
    public class IngredientServiceMapper : Profile
    {
        public IngredientServiceMapper()
        {
            CreateMap<CreateIngredientCommand, Ingredient>();
            CreateMap<IngredientViewModel, CreateIngredientCommand>();

            CreateMap<Ingredient, IngredientDto>();
            CreateMap<IngredientDto, IngredientViewModel>();

            CreateMap<UpdateIngredientCommand, Ingredient>();
        }
    }
}
