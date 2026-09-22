using planningRecette.Domain.Base;
using planningRecette.Domain.Enums;

namespace planningRecette.Domain.Entities
{
    public class RecipeLine : BaseEntity
    {
        public int RecipeId { get; set; }

        public int? SubRecipeId { get; set; }

        public int? IngredientId { get; set; }

        public decimal Quantity { get; set; }

        public UnitOfMeasureEnum Unit { get; set; }
    }
}