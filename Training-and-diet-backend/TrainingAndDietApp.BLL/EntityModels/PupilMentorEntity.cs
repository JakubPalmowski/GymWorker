using Training_and_diet_backend.Models;

namespace TrainingAndDietApp.BLL.Models
{
    public class PupilMentorEntity
    {
        // do zmiany
        public virtual User Mentor { get; set; }

        public PupilEntity PupilEntity { get; set; }
    }
}
