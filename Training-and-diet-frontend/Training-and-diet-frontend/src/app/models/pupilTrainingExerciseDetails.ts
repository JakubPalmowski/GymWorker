export interface PupilTrainingExercise{
    idTraineeExercise:number;
    seriesNumber: number,
    repetitionsNumber: string,
    comments: string,
    idExercise: number,
    idTrainingPlan:number
    // join z tabelki exercise
    exerciseName:string;
    details:string;
    ExerciseStep:string;
}