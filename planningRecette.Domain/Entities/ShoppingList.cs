namespace planningRecette.Domain.Entities
{
    public class ShoppingList
    {
        public int Id { get; set; }

        public DateTime GeneratedAt { get; set; }

        public DateOnly PeriodStart { get; set; }

        public DateOnly PeriodEnd { get; set; }

        public List<ShoppingListItem> Items { get; set; } = [];
    }
}