namespace Training_and_diet_backend.DTOs.User
{
    public class PupilDto
    {
         public string Name { get; set; }
        public string Last_name { get; set; }
         public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
    }
}