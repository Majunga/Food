using Common.Conversion;
using Food.Dal;
using Food.IService.RecipeHandlers.Commands;

namespace Food.Service.RecipeHandlers.Commands
{
    public class DeleteRecipeCommandHandler : CommandHandlerBase<DeleteRecipeCommand>
    {
        public DeleteRecipeCommandHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override void Handle(DeleteRecipeCommand command)
        {
            this.UnitOfWork.RecipeRepository.Delete(command.RecipeId);
            this.UnitOfWork.SaveChanges();
        }
    }
}
