using TrainingAndDietApp.BLL.Models;

namespace TrainingAndDietApp.BLL.EntityModels
{
    public class TrainingPlanEntity
    {
        public int IdTrainingPlan { get; set; }
        public int IdTrainer { get; set; }

        public string Name { get; set; }
        public string CustomName { get; set; }

        public string Type { get; set; }
    
        public DateTime StartDate { get; set; }
     
        public DateTime EndDate => StartDate.AddDays(7 * NumberOfWeeks);

        public int NumberOfWeeks { get; set; }

        public int PlanDuration => (EndDate - StartDate).Days;

        public virtual TrainerEntity TrainerEntity { get; set; }
        public virtual PupilEntity? Pupil { get; set; }

        public virtual ICollection<TraineeExerciseEntity> TraineeExercises { get; set; }
    }
}
