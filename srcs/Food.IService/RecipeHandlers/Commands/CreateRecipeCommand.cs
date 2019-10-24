using System.ComponentModel.DataAnnotations;

namespace Food.IService.RecipeHandlers.Commands
{
    public class CreateRecipeCommand
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public int? Id { get; set; }
    }
}
