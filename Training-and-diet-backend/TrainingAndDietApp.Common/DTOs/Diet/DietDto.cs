using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.Common.DTOs.Diet
{
    public class DietDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DietDuration { get; private set; }
        public int TotalKcal { get; set; }
    }
}
