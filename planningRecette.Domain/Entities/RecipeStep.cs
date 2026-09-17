namespace planningRecette.Domain.Entities
{
    public class RecipeStep
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int Order { get; set; }

        public string? Title { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}