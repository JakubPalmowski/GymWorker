namespace TrainingAndDietApp.Application.CQRS.Responses.Diet{
public class DietPupilResponse
{
        public int IdDiet { get; set; }
        public int IdDietician { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime EndDate { get; set; }
        public string DieticianName { get; set; }
        public string DieticianLastName { get; set; }
}
}
