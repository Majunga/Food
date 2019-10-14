using System;
using Common.Conversion;
using Common.Exceptions.NotFound;
using Food.Dal;
using Food.IService.IngredientHandlers.Models;
using Food.IService.IngredientHandlers.Queries;

namespace Food.Service.IngredientHandlers.Queries
{
    public class GetIngredientByIdQueryHandler : QueryHandlerBase<GetIngredientByIdQuery, IngredientDto>
    {
        public GetIngredientByIdQueryHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override object Run(GetIngredientByIdQuery query)
        {
            return this.UnitOfWork.IngredientRepository.Read(query.IngredientId) ?? throw new IngredientNotFoundException(query.IngredientId);
        }
    }
}
