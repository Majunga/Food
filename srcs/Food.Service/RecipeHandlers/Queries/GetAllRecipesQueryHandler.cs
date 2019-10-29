using Common.Conversion;
using Food.Dal;
using Food.IService.RecipeHandlers.Models;
using Food.IService.RecipeHandlers.Queries;
using System;
using System.Collections.Generic;

namespace Food.Service.RecipeHandlers.Queries
{
    public class GetAllRecipesQueryHandler : QueryHandlerBase<GetAllRecipesQuery, IReadOnlyCollection<RecipeDto>>
    {
        public GetAllRecipesQueryHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override object Run(GetAllRecipesQuery query)
        {
            return this.UnitOfWork.RecipeRepository.Read();
        }
    }
}
