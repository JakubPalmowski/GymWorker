namespace TrainingAndDietApp.Application.CQRS.Responses.Diet
{
public class DietPupilListResponse
{
    public int IdDiet { get; set; }
    public int IdDietician { get; set; }
    public string Name { get; set; }
    public DateTime EndDate { get; set; }
    public string DieticianName { get; set; }
    public string DieticianLastName { get; set; }
}
}
