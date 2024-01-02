namespace TrainingAndDietApp.BLL.Models
{
    public class AddressValueObject
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public ICollection<Gym> Gyms { get; set; }
    }
}
