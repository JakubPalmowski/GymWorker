using TrainingAndDietApp.BLL.Models;

namespace TrainingAndDietApp.BLL.EntityModels
{
    public class ExerciseEntity
    {
        public int IdExercise { get; set; }
        public int? IdTrainer { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string ExerciseSteps { get; set; }
        public byte[]? Image { get; set; }
        public TrainerEntity? Trainer { get; set; }
        public virtual ICollection<TraineeExerciseEntity> TraineeExercises { get; set; }
    }
}
