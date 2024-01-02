using TrainingAndDietApp.DAL.Enums;

namespace TrainingAndDietApp.DAL.EntityModels
{
    public class UserQuery
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public string? SortBy { get; set; }
        public SortDirection? SortDirection { get; set; }
        public string? GymCityPhrase { get; set; }
        public string? GymNamePhrase { get; set; }
        
    }
}
