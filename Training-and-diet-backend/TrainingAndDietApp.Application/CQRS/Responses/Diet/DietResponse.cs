using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.Application.CQRS.Responses.Diet
{
    public class DietResponse
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DietDuration { get; private set; }
        public int TotalKcal { get; set; }
    }
}
