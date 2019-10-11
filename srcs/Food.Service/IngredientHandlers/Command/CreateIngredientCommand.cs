using System;
using Common.Conversion;
using Food.Dal;
using Food.IService.IngredientHandlers.Command;

namespace Food.Service.IngredientHandlers.Command
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
