using Common.Conversion;
using Common.Exceptions.NotFound;
using Food.Dal;
using Food.IService.IngredientHandlers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Food.Service.IngredientHandlers.Commands
{
    public class UpdateIngredientCommandHandler : CommandHandlerBase<UpdateIngredientCommand>
    {
        public UpdateIngredientCommandHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override void Handle(UpdateIngredientCommand command)
        {
            var entity = this.UnitOfWork.IngredientRepository.Read(command.Id) ?? throw new IngredientNotFoundException(command.Id);
            
            this.Map(command, entity);

            this.UnitOfWork.SaveChanges();
        }
    }
}
