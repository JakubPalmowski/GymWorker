﻿namespace TrainingAndDietApp.Common.DTOs.Exercise
{
    public class ExerciseDto
    {
        public int Id_Exercise { get; private set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Exercise_steps { get; set; }
        public byte[]? Image { get; set; }
        public int? Id_Trainer { get; set; }
    }
}
