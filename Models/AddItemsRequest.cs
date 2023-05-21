namespace InventrySystemAPI.Models
{
    public class AddItemsRequest
    {
        public string? ItemsName { get; set; }
        public int ItemsQuantity { get; set; }
        public string? ItemsType { get; set; }
        public int Price { get; set; }
    }
}
