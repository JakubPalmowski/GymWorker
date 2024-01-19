using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.Application.CQRS.Responses
{
    public class UserResponse<T>
    {
        public List<MentorList> Items { get; set; }
        public int TotalPages { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }
        public int TotalItemsCount { get; set; }

        public UserResponse(List<MentorList> items, int totalCount, int pageNumber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            ItemsFrom = 9 * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + 9 - 1;
            TotalPages = (int)Math.Ceiling(totalCount / (double)9);
        }
    }

    public class MentorList
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public int OpinionNumber { get; set; }
        public decimal Rate { get; set; }
        public string RoleName { get; set; }
        public decimal? TrainingPlanPriceFrom { get; set; }
        public decimal? TrainingPlanPriceTo { get; set; }
        public decimal? PersonalTrainingPriceFrom { get; set; }
        public decimal? PersonalTrainingPriceTo { get; set; }
        public decimal? DietPriceFrom { get; set; }
        public decimal? DietPriceTo { get; set; }
        public string? ImageUri { get; set; }
    }
}
