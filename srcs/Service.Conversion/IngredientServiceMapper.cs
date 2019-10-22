using AutoMapper;
using Common.DataTypes;
using Food.Dal.Models;
using Food.IService.IngredientHandlers.Commands;
using Food.IService.IngredientHandlers.Models;

namespace Service.Conversion
{
    public class IngredientServiceMapper : Profile
    {
        public IngredientServiceMapper()
        {
            CreateMap<CreateIngredientCommand, Ingredient>();
            CreateMap<Ingredient, IngredientDto>();

        }
    }
}
