using System;
using Common.Conversion;
using Food.Dal;
using Food.Dal.Models;
using Food.IService.IngredientHandlers.Commands;

namespace Food.Service.IngredientHandlers.Commands
{
    public class DeleteIngredientCommandHandler : CommandHandlerBase<DeleteIngredientCommand>
    {
        public DeleteIngredientCommandHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override void Handle(DeleteIngredientCommand command)
        {
            this.UnitOfWork.IngredientRepository.Delete(command.IngredientId);
            this.UnitOfWork.SaveChanges();
        }
    }
}