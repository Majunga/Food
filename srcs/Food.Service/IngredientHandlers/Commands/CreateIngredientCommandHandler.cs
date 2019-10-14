using System;
using Common.Conversion;
using Food.Dal;
using Food.Dal.Models;
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
            var entity = this.Convert<Ingredient>(command);

            this.UnitOfWork.IngredientRepository.Create(entity);

            this.UnitOfWork.SaveChanges();

            command.Id = entity.Id;
        }
    }
}
