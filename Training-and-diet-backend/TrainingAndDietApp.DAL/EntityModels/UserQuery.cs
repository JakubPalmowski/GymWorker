namespace Training_and_diet_backend.Models
{
    public class UserQuery
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public string? SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
        public string? GymCityPhrase { get; set; }
        public string? GymNamePhrase { get; set; }
        
    }
}
