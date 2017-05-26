namespace SharpStore.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public string BuyerName { get; set; }

        public string BuyerAddress { get; set; }

        public string BuyerPhone { get; set; }

        public DeliveryType DeliveryType { get; set; }
    }

    public enum DeliveryType
    {
        Express, Economic
    }
}
