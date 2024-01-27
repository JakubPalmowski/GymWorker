namespace TrainingAndDietApp.Application.CQRS.Responses.Diet
{
public class DietListResponse
{
    public int IdDiet { get; set; }
    public string Name { get; set; }
    public string CustomName { get; set; }
    public DateTime EndDate { get; set; }

}
}
