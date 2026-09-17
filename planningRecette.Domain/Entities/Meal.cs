using planningRecette.Domain.Enums;

namespace planningRecette.Domain.Entities
{
    public class Meal
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public List<Recipe> Recipes { get; set; } = [];

        public int NumberOfGuests { get; set; }

        public MealSlotEnum MealSlot { get; set; }
    }
}