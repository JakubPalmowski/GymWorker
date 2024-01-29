namespace TrainingAndDietApp.Application.CQRS.Responses.Diet{
public class DietMentorResponse
{
        public int IdDiet { get; set; }
        public int IdDietician { get; set; }
        public int? IdPupil { get; set; } 
        public string Name { get; set; }
        public string CustomName { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfWeeks { get; set; }
        public int TotalKcal { get; set; }
        public string? PupilName { get; set; }
        public string? PupilLastName { get; set; }

}
}
