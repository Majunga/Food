using Common.Conversion;
using Common.Exceptions.NotFound;
using Food.Dal;
using Food.IService.RecipeHandlers.Commands;

namespace Food.Service.RecipeHandlers.Commands
{
    public class UpdateRecipeCommandHandler : CommandHandlerBase<UpdateRecipeCommand>
    {
        public UpdateRecipeCommandHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override void Handle(UpdateRecipeCommand command)
        {
            var entity = this.UnitOfWork.RecipeRepository.Read(command.Id) ?? throw new RecipeNotFoundException();

            this.Map(command, entity);

            this.UnitOfWork.SaveChanges();
        }
    }
}
