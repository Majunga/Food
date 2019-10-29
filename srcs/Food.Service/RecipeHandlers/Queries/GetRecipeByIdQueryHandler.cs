using Common.Conversion;
using Common.Exceptions.NotFound;
using Food.Dal;
using Food.IService.RecipeHandlers.Models;
using Food.IService.RecipeHandlers.Queries;
using System;

namespace Food.Service.RecipeHandlers.Queries
{
    public class GetRecipeByIdQueryHandler : QueryHandlerBase<GetRecipeByIdQuery, RecipeDto>
    {
        public GetRecipeByIdQueryHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override object Run(GetRecipeByIdQuery query)
        {
            return this.UnitOfWork.RecipeRepository.Read(query.RecipeId) ?? throw new RecipeNotFoundException(query.RecipeId);
        }
    }
}
