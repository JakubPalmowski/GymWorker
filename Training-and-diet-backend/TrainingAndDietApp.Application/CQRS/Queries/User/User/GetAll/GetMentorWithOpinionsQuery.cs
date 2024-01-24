using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Queries.User.User.GetAll;

public record GetMentorWithOpinionsQuery(string RoleName, int Id, int? IdLoggedUser) : IRequest<MentorWithOpinionResponse>
{

}

public class MentorWithOpinionResponse
{
    public int IdUser { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public int OpinionNumber { get; set; }
    public decimal TotalRate { get; set; }
    public decimal? TrainingPlanPriceFrom { get; set; }
    public decimal? TrainingPlanPriceTo { get; set; }
    public decimal? PersonalTrainingPriceFrom { get; set; }
    public decimal? PersonalTrainingPriceTo { get; set; }
    public decimal? DietPriceFrom { get; set; }
    public decimal? DietPriceTo { get; set; }
    public string? ImageUri { get; set; }
    public List<OpinionResponse> Opinions { get; set; }
    public List<MentorGymResponse> TrainerGyms { get; set; }
    public bool? Cooperation { get; set; }
    public bool? IsOpinionExists { get; set; }

}

public class OpinionResponse
{
    public string PupilName { get; set; }
    public string ImageUri { get; set; }
    public decimal Rate { get; set; }
    public string Content { get; set; }
    public string OpinionDate { get; set; }
}

public class MentorGymResponse
{
    public string Name { get; set; }
    public string CityName { get; set; }
}