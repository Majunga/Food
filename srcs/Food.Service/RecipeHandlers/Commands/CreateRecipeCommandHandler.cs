using Common.Conversion;
using Food.Dal;
using Food.Dal.Models;
using Food.IService.RecipeHandlers.Commands;

namespace Food.Service.RecipeHandlers.Commands
{
    public class CreateRecipeCommandHandler : CommandHandlerBase<CreateRecipeCommand>
    {
        public CreateRecipeCommandHandler(IUnitOfWork unitOfWork, IConversionService converter) : base(unitOfWork, converter)
        {
        }

        public override void Handle(CreateRecipeCommand command)
        {
            var entity = this.Convert<Recipe>(command);
            this.UnitOfWork.RecipeRepository.Create(entity);

            this.UnitOfWork.SaveChanges();
            command.Id = entity.Id;
        }
    }
}
