using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingAndDietApp.Application.CQRS.Responses.Pupil
{
    public class PupilResponse
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email {get; set;}
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Sex { get; set; }
        public string? ImageUri { get; set; }
        public string? Bio { get; set; }
    }
}
