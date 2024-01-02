using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.BLL.Models
{
    public class PupilMentor
    {
        // do zmiany
        public virtual User Mentor { get; set; }

        public Pupil Pupil { get; set; }
    }
}
