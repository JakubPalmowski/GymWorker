namespace TrainingAndDietApp.Application.CQRS.Responses.MealDiet{
public class MealDietForPupilResponse
{
    public int IdMealDiet { get; set; }
    public int IdMeal { get; set; }
    public int IdDiet { get; set; }
    public string? Comments { get; set; }
    public int DayOfWeek { get; set; }
    public string HourOfMeal { get; set; }
    
    public string MealName { get; set;}
    public string Ingredients { get; set; }
    public string PrepareSteps { get; set; }
    public string Kcal { get; set; }
}

}