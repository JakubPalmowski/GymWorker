using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.Application.Responses.Pupil
{
    public class PupilResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
    }
}
