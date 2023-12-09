namespace Training_and_diet_backend.DTOs
{
    public class GetTrainerWithOpinionsByIdDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public int Opinion_number { get; set; }
        public decimal TotalRate { get; set; }
        public List<OpinionDTO> Opinions { get; set; }


    }

}
