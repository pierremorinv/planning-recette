using planningRecette.Domain.Enums;

namespace planningRecette.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public UnitOfMeasureEnum Unit { get; set; }

        public bool IsInPantry { get; set; }

        public decimal? Density { get; set; }

        public decimal? AveragePieceWeight { get; set; }

        public AisleEnum Aisle { get; set; }
    }
}