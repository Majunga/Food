namespace Food.IService.RecipeHandlers.Commands
{
    public class UpdateRecipeCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description {get;set;}
    }
}
