namespace planningRecette.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Servings { get; set; }

        public List<RecipeStep> Steps { get; set; } = [];

        public List<RecipeLine> RecipeLines { get; set; } = [];
    }
}