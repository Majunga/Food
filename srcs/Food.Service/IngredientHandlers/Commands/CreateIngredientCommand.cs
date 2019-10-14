using System;
using Common.Conversion;
using Food.Dal;
using Food.IService.IngredientHandlers.Commands;

namespace Food.Service.IngredientHandlers.Commands
{
    public class CreateIngredientCommandHandler : CommandHandlerBase<CreateIngredientCommand>
    {
        public CreateIngredientCommandHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override void Handle(CreateIngredientCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
