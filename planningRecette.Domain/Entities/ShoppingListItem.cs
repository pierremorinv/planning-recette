using planningRecette.Domain.Enums;

namespace planningRecette.Domain.Entities

{
    public class ShoppingListItem
    {
        public int Id { get; set; }

        public int ShoppingListId { get; set; }
        public int IngredientId { get; set; }
        public decimal TotalQuantity { get; set; }
        public UnitOfMeasureEnum Unit { get; set; }

        public bool IsChecked { get; set; }

        public bool IsManuallyAdded { get; set; }
    }
}