using System;
using System.Collections.Generic;
using System.Text;
using Common.Conversion;
using Food.Dal;
using Food.IService.IngredientHandlers.Models;
using Food.IService.IngredientHandlers.Queries;

namespace Food.Service.IngredientHandlers.Queries
{
    public class GetAllIngredientsQueryHandler : QueryHandlerBase<GetAllIngredientsQuery, IReadOnlyCollection<IngredientDto>>
    {
        public GetAllIngredientsQueryHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override object Run(GetAllIngredientsQuery query)
        {
            return this.UnitOfWork.IngredientRepository.Read();
        }
    }
}
