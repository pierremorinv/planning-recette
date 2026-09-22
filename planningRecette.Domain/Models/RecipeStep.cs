using planningRecette.Domain.Base;

namespace planningRecette.Domain.Entities
{
    public class RecipeStep : BaseEntity
    {
        public int RecipeId { get; set; }

        public int Order { get; set; }

        public string? Title { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}