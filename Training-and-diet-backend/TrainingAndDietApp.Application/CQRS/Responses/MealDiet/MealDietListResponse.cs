namespace TrainingAndDietApp.Application.CQRS.Responses.MealDiet{
public class MealDietListResponse
{
    public int IdMealDiet { get; set; }
    public int IdMeal { get; set; }
    public int DayOfWeek { get; set; }
    public string HourOfMeal { get; set; }
    public string Name { get; set; }

}
}
