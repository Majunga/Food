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
            CreateMap<CreateIngredientCommand, Ingredient>()
                .ForMember(e => e.MetricQuantity, opts => opts.MapFrom(cmd => cmd.Quantity.Quantity))
                .ForMember(e => e.QuantityType, opts => opts.MapFrom(cmd => cmd.Quantity.QuantityType))
                ;
            CreateMap<Ingredient, IngredientDto>()
                .ForMember(dto => dto.Quantity, opts => opts.MapFrom(e => new IngredientQuantity(e.QuantityType, e.MetricQuantity)));
        }
    }
}
