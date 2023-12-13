namespace Training_and_diet_backend.DTOs
{
    public class GetUsersDTO
    {
        public int Id_trainer { get; set; }
        public string Name { get; set; }
        public string Last_name { get; set; }
        public string Phone_number { get; set; }
        public string Bio { get; set; }

        public string City { get; set; }

        public int Opinion_number { get; set; }
        public decimal Rate { get; set; }

    }

}
