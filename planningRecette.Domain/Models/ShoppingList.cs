using planningRecette.Domain.Base;

namespace planningRecette.Domain.Entities
{
    public class ShoppingList : BaseEntity
    {
        public DateTime GeneratedAt { get; set; }

        public DateOnly PeriodStart { get; set; }

        public DateOnly PeriodEnd { get; set; }

        public List<ShoppingListItem> Items { get; set; } = [];
    }
}