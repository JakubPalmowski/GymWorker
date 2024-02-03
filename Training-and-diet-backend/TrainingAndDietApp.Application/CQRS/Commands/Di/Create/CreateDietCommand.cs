using MediatR;

namespace TrainingAndDietApp.Application.CQRS.Commands.Di.Create
{
    public class CreateDietCommand 
    {
        public string Name { get; set; }
        public string CustomName { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public int? NumberOfWeeks { get; set; }
        public int? TotalKcal { get; set; }


    }

    public class CreateDietResponse
    {
        public int IdDiet { get; set; }
    }
}
